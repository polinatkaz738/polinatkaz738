using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TmpContrastGuard.cs — staged into every Unity app by approve-pipeline-unity.sh
// (stage 5c3, rule C.14 in CLAUDE-unity.md). Do not edit the copy inside a project;
// edit scripts/lib/unity/TmpContrastGuard.cs.
//
// WHY: every TMP label gets an outline (C.10), and by default that outline is dark.
// A dark face colour on a dark outline merges into a smudge — the label is not
// readable on any backing (ANDROID-3627: PLAY drawn Deep #12151E on the #12151E
// outline read as a black blob). enforce-text-contrast.sh fixes colours SERIALISED
// in scenes/prefabs, but labels built at runtime from C# (UiKit.Cta, VaultUi.Caption,
// label.color = Palette.X ...) never reach a scene file, so that pass cannot see them.
//
// WHAT: after any TMP text is regenerated, compare its face colour with the outline
// colour of the material it actually renders with. Below WCAG 4.5:1 the face is
// blended toward white (dark outline) or black (light outline) until it reaches 7:1.
// Hue is kept; alpha is kept. A label whose outline was deliberately switched to a
// light colour (TextReadability-style per-label material) is measured against THAT
// outline, so intentionally dark text on a light rim is left alone. Labels without
// an outline are left alone too.
public sealed class _0xfec2d141 : MonoBehaviour
{
    private static void Fix(TMP_Text _0xfa173033)
    {
        if (_0xfa173033 == null || !_0xfa173033.isActiveAndEnabled)
            return;
        Material _0x441768af = _0xfa173033.fontSharedMaterial;
        if (_0x441768af == null || !_0x441768af.HasProperty(ShaderUtilities.ID_OutlineColor) || !_0x441768af.HasProperty(ShaderUtilities.ID_OutlineWidth))
            return;
        if (_0x441768af.GetFloat(ShaderUtilities.ID_OutlineWidth) < MinOutlineWidth)
            return;
        Color _0xcb7a3999 = _0xfa173033.color;
        if (_0xcb7a3999.a <= 0f)
            return;
        Color _0xf9eee70a = _0x441768af.GetColor(ShaderUtilities.ID_OutlineColor);
        if (Ratio(_0xcb7a3999, _0xf9eee70a) >= MinRatio)
            return;
        Color _0x39a87c7f = Luminance(_0xf9eee70a) < 0.5f ? Color.white : Color.black;
        Color _0x67d13dca;
        if (Ratio(_0x39a87c7f, _0xf9eee70a) < TargetRatio)
        {
            _0x67d13dca = _0x39a87c7f;
        }
        else
        {
            // Smallest blend that reaches the target: contrast grows monotonically
            // with t, so a short bisection keeps as much of the hue as possible.
            float _0x4005ab50 = 0f;
            float _0xa114eff6 = 1f;
            for (int _0xe1d68b19 = 0; _0xe1d68b19 < 20; _0xe1d68b19++)
            {
                float _0xe2d641fb = (_0x4005ab50 + _0xa114eff6) * 0.5f;
                if (Ratio(Color.Lerp(_0xcb7a3999, _0x39a87c7f, _0xe2d641fb), _0xf9eee70a) >= TargetRatio)
                    _0xa114eff6 = _0xe2d641fb;
                else
                    _0x4005ab50 = _0xe2d641fb;
            }

            _0x67d13dca = Color.Lerp(_0xcb7a3999, _0x39a87c7f, _0xa114eff6);
        }

        _0x67d13dca.a = _0xcb7a3999.a;
        _0xfa173033.color = _0x67d13dca;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        if (_0x460b4235 != null)
            return;
        GameObject _0x2a802bd8 = new GameObject(_0x37b76f4d._0x8fdc0aec(new byte[16] { 34, 27, 6, 53, 25, 24, 2, 4, 23, 5, 2, 49, 3, 23, 4, 18 }, 118));
        _0x2a802bd8.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(_0x2a802bd8);
        _0x460b4235 = _0x2a802bd8.AddComponent<_0xfec2d141>();
    }

    private static float Ratio(Color _0x12dc9fc2, Color _0x91127962)
    {
        float _0xb0696202 = Luminance(_0x12dc9fc2);
        float _0x173eead9 = Luminance(_0x91127962);
        return (Mathf.Max(_0xb0696202, _0x173eead9) + 0.05f) / (Mathf.Min(_0xb0696202, _0x173eead9) + 0.05f);
    }

    // A lambda held in a field, never the bare method group: Plana renames the method
    // declaration but not a method-group reference (verify-unity-buttons.sh, CS0103).
    // The field keeps Add and Remove on the same delegate instance.
    private System.Action<Object> _0x178bbb07;
    // WCAG relative luminance of an sRGB colour, and the contrast ratio of two.
    private static float Luminance(Color _0x7e3605a1)
    {
        return 0.2126f * Linear(_0x7e3605a1.r) + 0.7152f * Linear(_0x7e3605a1.g) + 0.0722f * Linear(_0x7e3605a1.b);
    }

    // The event fires from inside the canvas rebuild. Changing the colour right there
    // would re-dirty the graphic mid-rebuild, which Unity rejects — so queue it and
    // apply in LateUpdate, which runs before the next frame's rebuild.
    private void _0xb07e790e(Object _0x85d08d91)
    {
        TMP_Text _0x6f08cbb8 = _0x85d08d91 as TMP_Text;
        if (_0x6f08cbb8 != null)
            this._0x1119525c.Add(_0x6f08cbb8);
    }

    private void LateUpdate()
    {
        if (this._0x1119525c.Count == 0)
            return;
        this._0xe7db017c.Clear();
        this._0xe7db017c.AddRange(this._0x1119525c);
        this._0x1119525c.Clear();
        for (int _0x945368cf = 0; _0x945368cf < this._0xe7db017c.Count; _0x945368cf++)
            Fix(this._0xe7db017c[_0x945368cf]);
    }

    private const float MinRatio = 4.5f;
    private static _0xfec2d141 _0x460b4235;
    private static float Linear(float _0xe4804ec0)
    {
        _0xe4804ec0 = Mathf.Clamp01(_0xe4804ec0);
        return _0xe4804ec0 <= 0.03928f ? _0xe4804ec0 / 12.92f : Mathf.Pow((_0xe4804ec0 + 0.055f) / 1.055f, 2.4f);
    }

    private void OnEnable()
    {
        if (this._0x178bbb07 == null)
            this._0x178bbb07 = _0x4c240a8c => this._0xb07e790e(_0x4c240a8c);
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(this._0x178bbb07);
    }

    private readonly HashSet<TMP_Text> _0x1119525c = new HashSet<TMP_Text>();
    private const float MinOutlineWidth = 0.01f;
    private void OnDisable()
    {
        if (this._0x178bbb07 != null)
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(this._0x178bbb07);
    }

    private readonly List<TMP_Text> _0xe7db017c = new List<TMP_Text>();
    private const float TargetRatio = 7f;
}

internal static class _0x37b76f4d
{
    internal static string _0x8fdc0aec(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
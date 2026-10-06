using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The in-game readout, built from OUR OWN scene objects rather than from the
/// template's score/timer slots (CLAUDE-unity.md C.2) - those are placeholders for a
/// different game and the pipeline switches them off.
///
/// The life gutter and the harvest line deliberately occupy disjoint horizontal
/// bands (C.25): the pips live on the right, the counter stops well short of them.
/// </summary>
public sealed class _0x561459ba : MonoBehaviour
{
    private void Start()
    {
        _0x05c27b73.ApplyOutline(this._harvestText);
        _0x05c27b73.ApplyOutline(this._stageLabel);
    }

    [SerializeField]
    private Image[] _lifePips;
    public void _0x477c664e(int _0x8a5c1154)
    {
        if (this._lifePips == null)
        {
            return;
        }

        for (int _0xcb2aff84 = 0; _0xcb2aff84 < this._lifePips.Length; _0xcb2aff84++)
        {
            if (this._lifePips[_0xcb2aff84] == null)
            {
                continue;
            }

            bool _0x3e10dc66 = _0xcb2aff84 < _0x8a5c1154;
            this._lifePips[_0xcb2aff84].color = _0x3e10dc66 ? _0xd2ac8035.Gold : _0xd2ac8035.Fade(_0xd2ac8035.Muted, 0.5f);
        }
    }

    [SerializeField]
    private TMP_Text _harvestText;
    public void _0x520fe43e(int _0x53b184b1, int _0x4ec9aa8c)
    {
        if (this._harvestText != null)
        {
            this._harvestText.text = _0xa26ab531._0xc437d2aa(new byte[8] { 211, 218, 201, 205, 222, 200, 207, 187 }, 155) + _0x53b184b1.ToString() + _0xa26ab531._0xc437d2aa(new byte[3] { 53, 58, 53 }, 21) + _0x4ec9aa8c.ToString();
        }
    }

    [SerializeField]
    private TMP_Text _stageLabel;
    [SerializeField]
    private RectTransform _harvestPulse;
    /// <summary>A short squeeze so a scored catch is visible, not just numerically true (C.7).</summary>
    public void _0x77f0185b()
    {
        this._0x1a44b26d = 0.22f;
    }

    private void Update()
    {
        if (this._0x1a44b26d <= 0f || this._harvestPulse == null)
        {
            return;
        }

        this._0x1a44b26d -= Time.unscaledDeltaTime;
        float _0x797b6948 = Mathf.Max(0f, this._0x1a44b26d) / 0.22f;
        float _0x39a9d55f = 1f + (Mathf.Sin(_0x797b6948 * Mathf.PI) * 0.12f);
        this._harvestPulse.localScale = new Vector3(_0x39a9d55f, _0x39a9d55f, 1f);
    }

    public void _0x38634cb7(int _0x72d15294, string _0xdd2cd2d9)
    {
        if (this._stageLabel != null)
        {
            this._stageLabel.text = _0xa26ab531._0xc437d2aa(new byte[6] { 86, 81, 68, 66, 64, 37 }, 5) + _0x72d15294.ToString() + _0xa26ab531._0xc437d2aa(new byte[3] { 105, 100, 105 }, 73) + _0xdd2cd2d9;
        }
    }

    private float _0x1a44b26d;
}

internal static class _0xa26ab531
{
    internal static string _0xc437d2aa(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
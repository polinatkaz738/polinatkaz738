using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The court's antechamber: the objective line, the best-harvest card and the three
/// ways out of the menu.
///
/// The PLAY control is the template's own scene button, resized to a real button
/// instead of the full-panel plate the template ships (CLAUDE-unity.md G.3). That
/// button renders nothing on its own - every surviving layer of EMPTY_BASE_BUTTON
/// paints through a stencil whose writers the variant disables - so the face is our
/// own node sitting over the same rect, with raycasts switched off so the press still
/// reaches the button underneath.
/// </summary>
public sealed class _0x1bd3800c : MonoBehaviour
{
    [SerializeField]
    private _0x373680ab _tutorial;
    private _0x9ab129fc _0x85358696;
    [SerializeField]
    private RectTransform _howToFace;
    [SerializeField]
    private TMP_Text _bestValue;
    [SerializeField]
    private RectTransform _playFace;
    [SerializeField]
    private TMP_Text _objectiveText;
    [SerializeField]
    private RectTransform[] _entrance;
    [SerializeField]
    private _0x1a95cfd1 _table;
    [SerializeField]
    private TMP_Text _favorLabel;
    [SerializeField]
    private RectTransform _stagesFace;
    [SerializeField]
    private _0x737d66c0 _stageSheet;
    private RectTransform _0xe98c4efd;
    [SerializeField]
    private Button _stagesButton;
    /// <summary>
    /// Re-reads the chosen stage. Picking a stage has to change something VISIBLE on
    /// the menu, not just a stored number (C.7) - the objective line is that change.
    /// </summary>
    public void _0xd2c30b3f()
    {
        int _0xbd6f0d50 = this._table == null ? 0 : Mathf.Clamp(this._0x85358696._0x2d5afef4, 0, Mathf.Max(0, this._table._0x86b3dc30 - 1));
        int _0x6a96efa9 = this._0x85358696._0x672ab235(_0xbd6f0d50);
        if (this._objectiveText != null)
        {
            int _0x64bc9d66 = this._table == null ? 12 : this._table._0x596276ec(_0xbd6f0d50);
            this._objectiveText.text = _0x18262598._0xf4d44558(new byte[6] { 243, 241, 228, 243, 248, 144 }, 176) + _0x64bc9d66.ToString() + _0x18262598._0xf4d44558(new byte[13] { 39, 85, 72, 94, 70, 75, 39, 65, 85, 82, 78, 83, 84 }, 7);
        }

        if (this._bestValue != null)
        {
            this._bestValue.text = _0x6a96efa9 > 0 ? _0x6a96efa9.ToString() : _0x18262598._0xf4d44558(new byte[14] { 197, 196, 223, 171, 219, 199, 202, 210, 206, 207, 171, 210, 206, 223 }, 139);
            this._bestValue.color = _0x6a96efa9 > 0 ? _0xd2ac8035.Leaf : _0xd2ac8035.Fade(_0xd2ac8035.Cream, 0.72f);
            _0x05c27b73.ApplyLayout(this._bestValue, _0x6a96efa9 > 0 ? 64f : 34f, _0x6a96efa9 > 0 ? 44f : 30f);
        }
    }

    private float _0xbe33fe76;
    private void Update()
    {
        this._0xbe33fe76 += Time.unscaledDeltaTime;
        // A slow breath on the crest and a staggered rise for the stack below it:
        // enough motion to read as alive, never a perpetual full-screen animation.
        if (this._crest != null)
        {
            float _0xe46caa66 = 1f + (Mathf.Sin(this._0xbe33fe76 * 2.99f) * 0.035f);
            float _0xe86b18f8 = Mathf.Clamp01(this._0xbe33fe76 / 0.55f);
            float _0xee2d1bd2 = 1f - ((1f - _0xe86b18f8) * (1f - _0xe86b18f8) * (1f - _0xe86b18f8));
            float _0x411ceca4 = Mathf.Lerp(0.72f, _0xe46caa66, _0xee2d1bd2);
            this._crest.localScale = new Vector3(_0x411ceca4, _0x411ceca4, 1f);
        }

        if (this._entrance != null)
        {
            for (int _0x9d567691 = 0; _0x9d567691 < this._entrance.Length; _0x9d567691++)
            {
                RectTransform _0x0a2a4df3 = this._entrance[_0x9d567691];
                if (_0x0a2a4df3 == null)
                {
                    continue;
                }

                float _0x48b9c4bb = 0.12f + (_0x9d567691 * 0.07f);
                float _0xfe12342a = Mathf.Clamp01((this._0xbe33fe76 - _0x48b9c4bb) / 0.32f);
                float _0x7bcec3b0 = 1f - ((1f - _0xfe12342a) * (1f - _0xfe12342a) * (1f - _0xfe12342a));
                // Every entrance item is authored at anchoredPosition zero inside a
                // point anchor, so the offset IS the whole animation.
                _0x0a2a4df3.anchoredPosition = new Vector2(0f, Mathf.Lerp(-40f, 0f, _0x7bcec3b0));
            }
        }

        if (this._0x527b925d > 0f && this._0xe98c4efd != null)
        {
            this._0x527b925d -= Time.unscaledDeltaTime;
            float _0xdb702d80 = Mathf.Max(0f, this._0x527b925d) / 0.18f;
            float _0xc72dbb2f = 1f + (Mathf.Sin(_0xdb702d80 * Mathf.PI) * 0.06f);
            this._0xe98c4efd.localScale = new Vector3(_0xc72dbb2f, _0xc72dbb2f, 1f);
        }
    }

    [SerializeField]
    private RectTransform _crest;
    private void Start()
    {
        if (this._playButton != null)
        {
            this._playButton.onClick.AddListener(() => this._0x2cca2d7d());
        }

        if (this._stagesButton != null)
        {
            this._stagesButton.onClick.AddListener(() => this._0xabd9ca1c());
        }

        if (this._howToButton != null)
        {
            this._howToButton.onClick.AddListener(() => this._0xf7681389());
        }

        _0x05c27b73.ApplyOutline(this._objectiveText);
        _0x05c27b73.ApplyOutline(this._bestValue);
        _0x05c27b73.ApplyOutline(this._bestLabel);
        _0x05c27b73.ApplyOutline(this._favorLabel);
        _0x05c27b73.ApplyOutline(this._favorValue);
        this._0xd2c30b3f();
    }

    [SerializeField]
    private Button _howToButton;
    private void _0xabd9ca1c()
    {
        this._0x2e759106(this._stagesFace);
        if (this._stageSheet != null)
        {
            this._stageSheet._0xf14e78f6();
        }
    }

    private void _0x2cca2d7d()
    {
        this._0x2e759106(this._playFace);
    }

    [SerializeField]
    private Button _playButton;
    private void _0x2e759106(RectTransform _0x297dc582)
    {
        this._0xe98c4efd = _0x297dc582;
        this._0x527b925d = 0.18f;
    }

    [SerializeField]
    private TMP_Text _favorValue;
    [SerializeField]
    private TMP_Text _bestLabel;
    private void Awake()
    {
        this._0x85358696 = new _0x9ab129fc();
    }

    private void _0xf7681389()
    {
        this._0x2e759106(this._howToFace);
        if (this._tutorial != null)
        {
            this._tutorial._0x00865093();
        }
    }

    private float _0x527b925d;
    public _0x9ab129fc _0xebee8597
    {
        get
        {
            return this._0x85358696;
        }
    }
}

internal static class _0x18262598
{
    internal static string _0xf4d44558(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
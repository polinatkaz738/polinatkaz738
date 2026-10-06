using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// One row of the stage list.
///
/// The medal gutter and the text column occupy two horizontal bands that never
/// overlap (CLAUDE-unity.md C.25): the medal is centred at x 150 in a 180-wide
/// gutter, the text column starts at 286 - a clear 46-unit gap past the gutter's
/// right edge. Left-aligning text does NOT move its rectangle, so this separation
/// has to be authored, not implied.
/// </summary>
public sealed class _0xdcb37c13 : MonoBehaviour
{
    private void Start()
    {
        if (this._button != null)
        {
            this._button.onClick.AddListener(() => this._0x194091e8());
        }
    }

    [SerializeField]
    private Image _medal;
    [SerializeField]
    private TMP_Text _nameText;
    /// <summary>
    /// The visible half of C.7: choosing a stage lights its frame, so the press is
    /// confirmed on screen rather than only in stored state.
    /// </summary>
    public void _0x37668733(bool _0x4d3ebb04)
    {
        if (this._frame != null)
        {
            this._frame.color = _0x4d3ebb04 ? _0xd2ac8035.Gold : _0xd2ac8035.Fade(_0xd2ac8035.Gold, this._0x4dc983b7 ? 0.4f : 0.2f);
        }

        if (this._plate != null)
        {
            this._plate.color = _0x4d3ebb04 ? _0xd2ac8035.Raised : _0xd2ac8035.Base;
        }

        this.transform.localScale = _0x4d3ebb04 ? new Vector3(1.03f, 1.03f, 1f) : Vector3.one;
    }

    [SerializeField]
    private Image _frame;
    private int _0x9af3d6e3;
    [SerializeField]
    private Image _plate;
    private bool _0x4dc983b7;
    [SerializeField]
    private TMP_Text _bestText;
    [SerializeField]
    private Button _button;
    private void _0x194091e8()
    {
        if (this._0x8866e95c != null && this._0x4dc983b7)
        {
            this._0x8866e95c._0xa7fec4c5(this._0x9af3d6e3);
        }
    }

    public void _0x477385a4(_0x737d66c0 _0xedf42634, int _0xb48366ed, string _0x371e8041, int _0x7585a294, int _0x935c88f1, bool _0x311ce867, bool _0x43aad767)
    {
        this._0x8866e95c = _0xedf42634;
        this._0x9af3d6e3 = _0xb48366ed;
        this._0x4dc983b7 = _0x311ce867;
        if (this._nameText != null)
        {
            this._nameText.text = _0x371e8041;
            this._nameText.color = _0x311ce867 ? _0xd2ac8035.Cream : _0xd2ac8035.Fade(_0xd2ac8035.Cream, 0.55f);
            _0x05c27b73.ApplyOutline(this._nameText);
        }

        if (this._goalText != null)
        {
            this._goalText.text = _0x311ce867 ? _0xc4d45919._0x56472cd1(new byte[5] { 69, 77, 67, 78, 34 }, 2) + _0x7585a294.ToString() + _0xc4d45919._0x56472cd1(new byte[7] { 202, 172, 184, 191, 163, 190, 185 }, 234) : _0xc4d45919._0x56472cd1(new byte[12] { 96, 111, 102, 98, 113, 3, 112, 119, 98, 100, 102, 3 }, 35) + _0xb48366ed.ToString() + _0xc4d45919._0x56472cd1(new byte[6] { 122, 28, 19, 8, 9, 14 }, 90);
            this._goalText.color = _0x311ce867 ? _0xd2ac8035.Leaf : _0xd2ac8035.Fade(_0xd2ac8035.Coral, 0.85f);
            _0x05c27b73.ApplyOutline(this._goalText);
        }

        if (this._bestText != null)
        {
            this._bestText.text = _0x935c88f1 > 0 ? _0xc4d45919._0x56472cd1(new byte[5] { 138, 141, 155, 156, 232 }, 200) + _0x935c88f1.ToString() : _0xc4d45919._0x56472cd1(new byte[14] { 185, 184, 163, 215, 167, 187, 182, 174, 178, 179, 215, 174, 178, 163 }, 247);
            this._bestText.color = _0x935c88f1 > 0 ? _0xd2ac8035.Gold : _0xd2ac8035.Fade(_0xd2ac8035.Gold, 0.65f);
            _0x05c27b73.ApplyOutline(this._bestText);
        }

        if (this._medal != null)
        {
            this._medal.color = _0x311ce867 ? Color.white : _0xd2ac8035.Muted;
            this._medal.preserveAspect = true;
        }

        this._0x37668733(_0x43aad767);
    }

    public Button _0x8fa1fb29
    {
        get
        {
            return this._button;
        }
    }

    [SerializeField]
    private TMP_Text _goalText;
    private _0x737d66c0 _0x8866e95c;
}

internal static class _0xc4d45919
{
    internal static string _0x56472cd1(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The content WE put inside one of the template's pop cards. The template ships its
/// pops wearing another game's wording and metric rows, so this card carries the whole
/// result face instead - heading, body, sub-line, illustration and the action buttons
/// (CLAUDE-unity.md C.3). Each button gets its OWN caption; none is wired from the
/// inspector, so obfuscation cannot sever them (C.1, C.17).
/// </summary>
public sealed class _0x01210122 : MonoBehaviour
{
    public Button _0xadeeac5e(int _0x209fb77d)
    {
        return this._buttons != null && _0x209fb77d >= 0 && _0x209fb77d < this._buttons.Length ? this._buttons[_0x209fb77d] : null;
    }

    [SerializeField]
    private TMP_Text[] _buttonLabels;
    /// <summary>
    /// Turns on exactly as many buttons as the caption list has entries and labels
    /// each one separately - a pop with three identical captions is the failure this
    /// guards against.
    /// </summary>
    public void _0x98db9049(string[] _0xf5922530, Color[] _0x6b4a2ecd)
    {
        if (this._buttons == null)
        {
            return;
        }

        for (int _0xc22270f4 = 0; _0xc22270f4 < this._buttons.Length; _0xc22270f4++)
        {
            bool _0xef443427 = _0xf5922530 != null && _0xc22270f4 < _0xf5922530.Length;
            if (this._buttons[_0xc22270f4] != null)
            {
                this._buttons[_0xc22270f4].gameObject.SetActive(_0xef443427);
            }

            if (_0xef443427 && this._buttonLabels != null && _0xc22270f4 < this._buttonLabels.Length && this._buttonLabels[_0xc22270f4] != null)
            {
                this._buttonLabels[_0xc22270f4].text = _0xf5922530[_0xc22270f4];
                this._buttonLabels[_0xc22270f4].color = _0xd2ac8035.Cream;
            }

            if (_0xef443427 && this._buttonPlates != null && _0xc22270f4 < this._buttonPlates.Length && this._buttonPlates[_0xc22270f4] != null)
            {
                this._buttonPlates[_0xc22270f4].color = _0x6b4a2ecd != null && _0xc22270f4 < _0x6b4a2ecd.Length ? _0x6b4a2ecd[_0xc22270f4] : _0xd2ac8035.Raised;
            }
        }
    }

    [SerializeField]
    private TMP_Text _main;
    [SerializeField]
    private Image _cardPlate;
    [SerializeField]
    private Image[] _buttonPlates;
    [SerializeField]
    private Button[] _buttons;
    private void Start()
    {
        if (this._cardPlate != null)
        {
            this._cardPlate.color = _0xd2ac8035.Base;
        }

        if (this._cardBorder != null)
        {
            this._cardBorder.color = _0xd2ac8035.Gold;
        }

        _0x05c27b73.ApplyOutline(this._title);
        _0x05c27b73.ApplyOutline(this._main);
        _0x05c27b73.ApplyOutline(this._sub);
        if (this._buttonLabels != null)
        {
            for (int _0x278462aa = 0; _0x278462aa < this._buttonLabels.Length; _0x278462aa++)
            {
                _0x05c27b73.ApplyOutline(this._buttonLabels[_0x278462aa]);
            }
        }
    }

    public void _0x7fd352fc(string _0xd238d87a, string _0xf424f893, string _0x3e932851)
    {
        if (this._title != null)
        {
            this._title.text = _0xd238d87a;
        }

        if (this._main != null)
        {
            this._main.text = _0xf424f893;
        }

        if (this._sub != null)
        {
            this._sub.text = _0x3e932851;
        }
    }

    [SerializeField]
    private Image _cardBorder;
    [SerializeField]
    private TMP_Text _sub;
    public void SetIllustration(Sprite _0xeef47b1a, Color _0xb7b2d9a3)
    {
        if (this._illustration == null)
        {
            return;
        }

        this._illustration.sprite = _0xeef47b1a;
        this._illustration.color = _0xb7b2d9a3;
        this._illustration.preserveAspect = true;
        this._illustration.gameObject.SetActive(_0xeef47b1a != null);
    }

    [SerializeField]
    private Image _illustration;
    [SerializeField]
    private TMP_Text _title;
}
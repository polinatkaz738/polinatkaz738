using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The two how-to-play steps, shown from a menu button rather than automatically.
///
/// Auto-show fires exactly once per install (the template stores a "tutor passed"
/// flag), so a re-run of the screenshot job would meet a different first screen and
/// every scripted tap would land somewhere else. Opening it from a button keeps the
/// flow identical on every run.
///
/// The template ships five tutorial panels carrying Lorem Ipsum. Two are dressed
/// here and the other three are emptied, because an undressed panel ships that filler
/// straight to the store (CLAUDE-unity.md C.15).
/// </summary>
public sealed class _0x373680ab : MonoBehaviour
{
    private void _0xd874ef50(int _0x037bdc51)
    {
        _0xcd23417c _0xe2a1a4e3 = this._0x9dd3b680(_0x037bdc51);
        if (_0xe2a1a4e3 == null)
        {
            return;
        }

        if (_0xe2a1a4e3.HeaderText != null)
        {
            _0xe2a1a4e3.HeaderText.text = string.Empty;
        }

        if (_0xe2a1a4e3.MainText != null)
        {
            _0xe2a1a4e3.MainText.text = string.Empty;
        }

        if (_0xe2a1a4e3.Content == null)
        {
            return;
        }

        TMP_Text[] _0xa494b092 = _0xe2a1a4e3.Content.GetComponentsInChildren<TMP_Text>(true);
        for (int _0x6a35add9 = 0; _0x6a35add9 < _0xa494b092.Length; _0x6a35add9++)
        {
            if (_0xa494b092[_0x6a35add9] != null)
            {
                _0xa494b092[_0x6a35add9].text = string.Empty;
            }
        }
    }

    [SerializeField]
    private int _menuPanelIndex = 1;
    [SerializeField]
    private Sprite _tapSprite;
    [SerializeField]
    private int _secondPanelIndex = 14;
    public void _0x00865093()
    {
        this._0x232a8282();
        _0x8fc0d527 _0x8db2de00 = _0x8fc0d527.Instance;
        if (_0x8db2de00 != null)
        {
            _0x8db2de00._0x226158a4(this._firstPanelIndex);
        }
    }

    private bool _0x4a183d7b;
    private void _0x6395b9a9(int _0x55a4df15, string _0x01d07e32, string _0x0d9ad1d4, string _0xd1627ef1, Sprite _0xce3c912b, int _0x838ba393, bool _0x91f6995e)
    {
        _0xcd23417c _0x10f7298e = this._0x9dd3b680(_0x55a4df15);
        if (_0x10f7298e == null)
        {
            return;
        }

        GameObject _0xc7e33128 = _0x10f7298e.Content;
        if (_0xc7e33128 == null)
        {
            return;
        }

        // The template leaves Panel.HeaderText / MainText unassigned on the tutorial
        // prefab, so the two body labels are found structurally instead: the first
        // two TMP labels under the panel that do NOT belong to a button.
        TMP_Text _0x58c53e45 = this._0x4a5296ad(_0xc7e33128, 0);
        TMP_Text _0x2e20821e = this._0x4a5296ad(_0xc7e33128, 1);
        if (_0x58c53e45 != null)
        {
            _0x58c53e45.text = _0x01d07e32;
            _0x58c53e45.color = _0xd2ac8035.Cream;
            _0x05c27b73.ApplyLayout(_0x58c53e45, 52f, 40f);
            _0x05c27b73.ApplyOutline(_0x58c53e45);
        }

        if (_0x2e20821e != null)
        {
            _0x2e20821e.text = _0x0d9ad1d4;
            _0x2e20821e.color = _0xd2ac8035.Cream;
            _0x05c27b73.ApplyLayout(_0x2e20821e, 38f, 32f);
            _0x05c27b73.ApplyOutline(_0x2e20821e);
        }

        // The illustration slot is the first Image of the panel BODY - the template
        // ships it already carrying a placeholder, so "first one without a sprite"
        // would skip it and land on a button's colour fill instead. Found by type and
        // hierarchy order, never by name.
        Image[] _0x2f53c529 = _0xc7e33128.GetComponentsInChildren<Image>(true);
        for (int _0x459e0f91 = 0; _0x459e0f91 < _0x2f53c529.Length; _0x459e0f91++)
        {
            if (_0x2f53c529[_0x459e0f91] == null || _0x2f53c529[_0x459e0f91].GetComponentInParent<Button>(true) != null)
            {
                continue;
            }

            _0x2f53c529[_0x459e0f91].sprite = _0xce3c912b;
            _0x2f53c529[_0x459e0f91].color = Color.white;
            _0x2f53c529[_0x459e0f91].preserveAspect = true;
            break;
        }

        _0x2a35787f _0x80ba6a4d = _0xc7e33128.GetComponentInParent<_0x2a35787f>(true);
        if (_0x80ba6a4d == null)
        {
            _0x80ba6a4d = _0x10f7298e.GetComponent<_0x2a35787f>();
        }

        if (_0x80ba6a4d != null)
        {
            _0x80ba6a4d.IsTutorialEndPanel = _0x91f6995e;
            _0x80ba6a4d.NextTutorialPanelIndex = _0x838ba393;
            _0x80ba6a4d.EndTutorialPanelIndex = this._menuPanelIndex;
        }

        // Every button inside the step carries the same caption on purpose: the
        // template puts exactly one action button on a tutorial panel, and the
        // close glyph in TOP_BTNS ships inactive.
        Button[] _0x64ff02f3 = _0xc7e33128.GetComponentsInChildren<Button>(true);
        for (int _0xf9be696a = 0; _0xf9be696a < _0x64ff02f3.Length; _0xf9be696a++)
        {
            // activeInHierarchy is useless here: a panel is hidden while it is being
            // dressed, so every one of its buttons reads inactive. What matters is
            // whether the button is switched on RELATIVE to the panel body - the
            // template's close glyph sits in a group it ships disabled.
            if (_0x64ff02f3[_0xf9be696a] == null || !this.EnabledWithin(_0x64ff02f3[_0xf9be696a].transform, _0xc7e33128.transform))
            {
                continue;
            }

            TMP_Text _0xfea7d1dc = _0x64ff02f3[_0xf9be696a].GetComponentInChildren<TMP_Text>(true);
            if (_0xfea7d1dc != null)
            {
                _0xfea7d1dc.text = _0xd1627ef1;
                _0xfea7d1dc.color = _0xd2ac8035.Cream;
                _0xfea7d1dc.gameObject.SetActive(true);
                _0x05c27b73.ApplyLayout(_0xfea7d1dc, 46f, 34f);
                _0x05c27b73.ApplyOutline(_0xfea7d1dc);
            }
        }
    }

    /// <summary>
    /// The n-th label of the panel body, skipping anything that is a button caption.
    /// Resolved by component type and hierarchy order, never by object name.
    /// </summary>
    private TMP_Text _0x4a5296ad(GameObject _0xfcafa7b8, int _0x232fcd4c)
    {
        TMP_Text[] _0x58283892 = _0xfcafa7b8.GetComponentsInChildren<TMP_Text>(true);
        int _0xf3705828 = 0;
        for (int _0x01ceccc1 = 0; _0x01ceccc1 < _0x58283892.Length; _0x01ceccc1++)
        {
            if (_0x58283892[_0x01ceccc1] == null || _0x58283892[_0x01ceccc1].GetComponentInParent<Button>(true) != null)
            {
                continue;
            }

            if (_0xf3705828 == _0x232fcd4c)
            {
                return _0x58283892[_0x01ceccc1];
            }

            _0xf3705828++;
        }

        return null;
    }

    private _0xcd23417c _0x9dd3b680(int _0x0eef7ac7)
    {
        _0x8fc0d527 _0x1fdf2da6 = _0x8fc0d527.Instance;
        if (_0x1fdf2da6 == null || _0x1fdf2da6.Panels == null)
        {
            return null;
        }

        if (_0x0eef7ac7 < 0 || _0x0eef7ac7 >= _0x1fdf2da6.Panels.Count)
        {
            return null;
        }

        return _0x1fdf2da6.Panels[_0x0eef7ac7];
    }

    /// <summary>Is every switch between this object and the given ancestor turned on?</summary>
    private bool EnabledWithin(Transform _0xda111012, Transform _0x5062fe2c)
    {
        Transform _0xff70e558 = _0xda111012;
        while (_0xff70e558 != null && _0xff70e558 != _0x5062fe2c)
        {
            if (!_0xff70e558.gameObject.activeSelf)
            {
                return false;
            }

            _0xff70e558 = _0xff70e558.parent;
        }

        return true;
    }

    [SerializeField]
    private Sprite _swipeSprite;
    [SerializeField]
    private int _firstPanelIndex = 13;
    private void Start()
    {
        this._0x232a8282();
    }

    [SerializeField]
    private int _lastDressedIndex = 19;
    private void _0x232a8282()
    {
        if (this._0x4a183d7b)
        {
            return;
        }

        _0x8fc0d527 _0x2f743b21 = _0x8fc0d527.Instance;
        if (_0x2f743b21 == null || _0x2f743b21.Panels == null)
        {
            return;
        }

        this._0x4a183d7b = true;
        this._0x6395b9a9(this._firstPanelIndex, _0x708d9799._0x9cea27d3(new byte[13] { 51, 55, 41, 48, 37, 64, 52, 47, 64, 45, 47, 54, 37 }, 96), _0x708d9799._0x9cea27d3(new byte[60] { 162, 166, 184, 161, 180, 209, 189, 180, 183, 165, 209, 190, 163, 209, 163, 184, 182, 185, 165, 209, 165, 190, 209, 188, 190, 167, 180, 251, 165, 185, 180, 209, 165, 163, 176, 168, 209, 164, 191, 181, 180, 163, 209, 165, 185, 180, 209, 183, 176, 189, 189, 184, 191, 182, 209, 183, 163, 164, 184, 165 }, 241), _0x708d9799._0x9cea27d3(new byte[4] { 202, 193, 220, 208 }, 132), this._swipeSprite, this._secondPanelIndex, false);
        this._0x6395b9a9(this._secondPanelIndex, _0x708d9799._0x9cea27d3(new byte[13] { 98, 119, 102, 22, 98, 121, 22, 101, 97, 127, 98, 117, 126 }, 54), _0x708d9799._0x9cea27d3(new byte[85] { 207, 218, 203, 187, 207, 212, 187, 200, 204, 210, 207, 216, 211, 187, 207, 211, 222, 187, 218, 216, 207, 210, 205, 222, 187, 200, 222, 216, 207, 210, 212, 213, 181, 145, 216, 218, 207, 216, 211, 187, 222, 218, 216, 211, 187, 221, 201, 206, 210, 207, 187, 204, 210, 207, 211, 187, 207, 211, 222, 187, 200, 222, 216, 207, 210, 212, 213, 145, 212, 221, 187, 210, 207, 200, 187, 212, 204, 213, 187, 216, 212, 215, 212, 206, 201 }, 155), _0x708d9799._0x9cea27d3(new byte[6] { 178, 186, 161, 213, 188, 161 }, 245), this._tapSprite, this._menuPanelIndex, true);
        // Everything else in the tutorial group is left in place (the controller
        // addresses panels by index, so removing one breaks navigation) but emptied,
        // so no filler text can reach a screen.
        for (int _0x22b10276 = this._secondPanelIndex + 1; _0x22b10276 <= this._lastDressedIndex; _0x22b10276++)
        {
            this._0xd874ef50(_0x22b10276);
        }
    }
}

internal static class _0x708d9799
{
    internal static string _0x9cea27d3(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
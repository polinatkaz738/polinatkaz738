using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The stage list, built from the card prefab and shown over the menu.
///
/// It is one of OUR OWN objects, raised through a visibility gate rather than by
/// borrowing a template panel (CLAUDE-unity.md C.2). A list that can be empty must
/// say so in words rather than showing a blank sheet, hence the standing empty line.
/// </summary>
public sealed class _0x737d66c0 : MonoBehaviour
{
    [SerializeField]
    private Button _dimmerButton;
    public void _0xf14e78f6()
    {
        this._0x0f1dd782();
        if (this._gate != null)
        {
            this._gate._0x6594c513(true);
        }
    }

    public void _0xa7fec4c5(int _0x20f6d55e)
    {
        this._0x6876d585._0x2d5afef4 = _0x20f6d55e;
        for (int _0xd98ea578 = 0; _0xd98ea578 < this._0x5b885b5f.Count; _0xd98ea578++)
        {
            if (this._0x5b885b5f[_0xd98ea578] != null)
            {
                this._0x5b885b5f[_0xd98ea578]._0x37668733(_0xd98ea578 == _0x20f6d55e);
            }
        }

        if (this._director != null)
        {
            this._director._0xd2c30b3f();
        }

        this._0x18ec8de5();
    }

    private _0x9ab129fc _0x6876d585;
    [SerializeField]
    private RectTransform _cardHost;
    [SerializeField]
    private _0x1a95cfd1 _table;
    [SerializeField]
    private _0x719cb13d _gate;
    [SerializeField]
    private _0xdcb37c13 _cardPrefab;
    [SerializeField]
    private _0x1bd3800c _director;
    [SerializeField]
    private float _firstCardY = -220f;
    private void _0x0f1dd782()
    {
        if (this._cardHost == null || this._cardPrefab == null || this._table == null)
        {
            this._0x65bd99b0(true);
            return;
        }

        for (int _0x0be818d4 = 0; _0x0be818d4 < this._0x5b885b5f.Count; _0x0be818d4++)
        {
            if (this._0x5b885b5f[_0x0be818d4] != null)
            {
                Destroy(this._0x5b885b5f[_0x0be818d4].gameObject);
            }
        }

        this._0x5b885b5f.Clear();
        int _0xf8512225 = this._table._0x86b3dc30;
        this._0x65bd99b0(_0xf8512225 == 0);
        int _0xe989095f = this._0x6876d585._0x2d5afef4;
        for (int _0x9167e704 = 0; _0x9167e704 < _0xf8512225; _0x9167e704++)
        {
            _0xdcb37c13 _0x170c166f = Instantiate(this._cardPrefab, this._cardHost);
            RectTransform _0x4e8c90f8 = _0x170c166f.transform as RectTransform;
            if (_0x4e8c90f8 != null)
            {
                _0x4e8c90f8.anchorMin = new Vector2(0.5f, 1f);
                _0x4e8c90f8.anchorMax = new Vector2(0.5f, 1f);
                _0x4e8c90f8.anchoredPosition = new Vector2(0f, this._firstCardY - (_0x9167e704 * this._cardPitch));
            }

            _0x170c166f._0x477385a4(this, _0x9167e704, this._table._0xe2dcb2f2(_0x9167e704), this._table._0x596276ec(_0x9167e704), this._0x6876d585._0x672ab235(_0x9167e704), this._0x6876d585._0x093b9e3f(_0x9167e704), _0x9167e704 == _0xe989095f);
            this._0x5b885b5f.Add(_0x170c166f);
        }
    }

    private void Awake()
    {
        this._0x6876d585 = new _0x9ab129fc();
    }

    private void Start()
    {
        if (this._closeButton != null)
        {
            this._closeButton.onClick.AddListener(() => this._0x18ec8de5());
        }

        if (this._dimmerButton != null)
        {
            this._dimmerButton.onClick.AddListener(() => this._0x18ec8de5());
        }

        _0x05c27b73.ApplyOutline(this._title);
        _0x05c27b73.ApplyOutline(this._emptyLabel);
        this._0x0f1dd782();
    }

    [SerializeField]
    private TMP_Text _title;
    [SerializeField]
    private float _cardPitch = 320f;
    [SerializeField]
    private TMP_Text _emptyLabel;
    private readonly List<_0xdcb37c13> _0x5b885b5f = new List<_0xdcb37c13>();
    [SerializeField]
    private Button _closeButton;
    public void _0x18ec8de5()
    {
        if (this._gate != null)
        {
            this._gate._0x6594c513(false);
        }
    }

    private void _0x65bd99b0(bool _0x089ac112)
    {
        if (this._emptyLabel != null)
        {
            this._emptyLabel.gameObject.SetActive(_0x089ac112);
        }
    }
}
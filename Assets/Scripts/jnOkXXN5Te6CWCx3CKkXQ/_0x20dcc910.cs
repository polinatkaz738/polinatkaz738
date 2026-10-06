using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Hands the win / lose / pause pops over to OUR cards.
///
/// The template's own rows inside each pop belong to a different game - a "Score:"
/// label, a reward counter and a strip of ten stock buttons of which one is enabled.
/// Leaving them next to our content is exactly the defect CLAUDE-unity.md C.3
/// describes, so they are switched off at runtime (a scene-level m_IsActive override
/// on an object this deep inside a prefab instance is silently dropped - C.2).
///
/// Everything is located BY COMPONENT TYPE, never by object name, so the pass still
/// works after the obfuscator has renamed every object in the scene.
/// </summary>
public sealed class _0x20dcc910 : MonoBehaviour
{
    private void _0xe56cd9a6(int _0x5a917cc8, _0x01210122 _0xffdeb96c)
    {
        _0x2cc5c82d _0x371c89bc = _0x2cc5c82d.Instance;
        if (_0x371c89bc == null)
        {
            return;
        }

        _0x30b2da79 _0xbcdb4efd = _0x371c89bc._0x594a6eda(_0x5a917cc8);
        if (_0xbcdb4efd == null || _0xbcdb4efd.Content == null)
        {
            return;
        }

        Transform _0xd7825a90 = _0xbcdb4efd.Content.transform;
        Transform _0xd0775edd = _0xffdeb96c == null ? null : _0xffdeb96c.transform;
        for (int _0x83211886 = 0; _0x83211886 < _0xd7825a90.childCount; _0x83211886++)
        {
            Transform _0x86058adc = _0xd7825a90.GetChild(_0x83211886);
            if (_0x86058adc == _0xd0775edd)
            {
                continue;
            }

            // A branch that holds buttons is the template's action strip; a branch
            // that holds the pop's own header label is its text block. Both are
            // replaced by our card, so neither may stay on screen.
            bool _0x9a8ebd12 = _0x86058adc.GetComponentInChildren<Button>(true) != null;
            bool _0x7b71cd17 = _0xbcdb4efd.ContentHeaderText != null && _0xbcdb4efd.ContentHeaderText.transform.IsChildOf(_0x86058adc);
            bool _0x7aea4760 = _0xbcdb4efd.ContentMainText != null && _0xbcdb4efd.ContentMainText.transform.IsChildOf(_0x86058adc);
            if (_0x9a8ebd12 || _0x7b71cd17 || _0x7aea4760)
            {
                _0x86058adc.gameObject.SetActive(false);
            }
        }

        // A close glyph the template never gave a sprite is drawn as a solid WHITE
        // RECTANGLE. Only a SMALL, still-enabled, caption-less button can be that
        // glyph: the panel plates are spriteless on purpose (they are colour fills),
        // and handing one of those a cross would paint it across the whole card.
        Button[] _0x9b394e1d = _0xd7825a90.GetComponentsInChildren<Button>(true);
        for (int _0xc474fbc4 = 0; _0xc474fbc4 < _0x9b394e1d.Length; _0xc474fbc4++)
        {
            Button _0xca3fa034 = _0x9b394e1d[_0xc474fbc4];
            if (_0xca3fa034 == null || !this.EnabledWithin(_0xca3fa034.transform, _0xd7825a90))
            {
                continue;
            }

            RectTransform _0xd2886e2c = _0xca3fa034.transform as RectTransform;
            if (_0xd2886e2c == null || _0xd2886e2c.rect.width > 170f || _0xd2886e2c.rect.height > 170f)
            {
                continue;
            }

            TMP_Text _0xe2e94274 = _0xca3fa034.GetComponentInChildren<TMP_Text>(true);
            if (_0xe2e94274 != null && !string.IsNullOrEmpty(_0xe2e94274.text))
            {
                continue;
            }

            Image _0x33f11625 = _0xca3fa034.GetComponentInChildren<Image>(true);
            if (_0x33f11625 != null && _0x33f11625.sprite == null)
            {
                _0x33f11625.sprite = this._closeIcon;
                _0x33f11625.preserveAspect = true;
                _0x33f11625.color = _0xd2ac8035.Cream;
            }
        }
    }

    [SerializeField]
    private _0x01210122 _loseCard;
    public _0x01210122 _0x78b14d6b
    {
        get
        {
            return this._pauseCard;
        }
    }

    /// <summary>Is every switch between this object and the given ancestor turned on?</summary>
    private bool EnabledWithin(Transform _0x7373d0f3, Transform _0x194bd318)
    {
        Transform _0xc5167e94 = _0x7373d0f3;
        while (_0xc5167e94 != null && _0xc5167e94 != _0x194bd318)
        {
            if (!_0xc5167e94.gameObject.activeSelf)
            {
                return false;
            }

            _0xc5167e94 = _0xc5167e94.parent;
        }

        return true;
    }

    public _0x01210122 _0x489cfebd
    {
        get
        {
            return this._winCard;
        }
    }

    [SerializeField]
    private _0x01210122 _pauseCard;
    public _0x01210122 _0x5204968c
    {
        get
        {
            return this._loseCard;
        }
    }

    [SerializeField]
    private _0x01210122 _winCard;
    [SerializeField]
    private Sprite _closeIcon;
    private void Start()
    {
        this._0xe56cd9a6(_0xea334b23._0xca25cf66.WIN, this._winCard);
        this._0xe56cd9a6(_0xea334b23._0xca25cf66.LOSE, this._loseCard);
        this._0xe56cd9a6(_0xea334b23._0xca25cf66.PAUSE, this._pauseCard);
    }
}
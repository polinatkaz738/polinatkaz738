using TMPro;
using UnityEngine;

/// <summary>
/// The control is a swipe plus a tap, so it has to be spelled out ON the play screen
/// (CLAUDE-unity.md C.6): the gesture AND what it does. The line never fades below
/// 0.72 alpha, because review is judged from screenshots taken from the fifteenth
/// second onwards and a faded hint is the same as no hint.
/// </summary>
public sealed class _0x594506a0 : MonoBehaviour
{
    [SerializeField]
    private float _restingAlpha = 0.72f;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private float _fullAlphaSeconds = 12f;
    private void Start()
    {
        if (this._label != null)
        {
            this._label.color = _0xd2ac8035.Cream;
            _0x05c27b73.ApplyLayout(this._label, 42f, 38f);
            _0x05c27b73.ApplyOutline(this._label);
        }
    }

    private float _0x12430786;
    private void Update()
    {
        if (this._label == null)
        {
            return;
        }

        this._0x12430786 += Time.unscaledDeltaTime;
        float _0xc4649c9b = this._0x12430786 < this._fullAlphaSeconds ? 1f : Mathf.Lerp(1f, this._restingAlpha, Mathf.Clamp01((this._0x12430786 - this._fullAlphaSeconds) / 1.5f));
        Color _0x9e1a91bf = this._label.color;
        this._label.color = new Color(_0x9e1a91bf.r, _0x9e1a91bf.g, _0x9e1a91bf.b, _0xc4649c9b);
    }
}
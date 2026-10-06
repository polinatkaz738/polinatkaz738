using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A single coral wash across the screen when a crowned plum is lost. Deliberately a
/// one-shot: a perpetual full-screen animation starves the device-side screenshot
/// capture, which is why nothing here loops.
/// </summary>
public sealed class _0xb5ef045d : MonoBehaviour
{
    [SerializeField]
    private Image _overlay;
    [SerializeField]
    private float _life = 0.45f;
    private void Update()
    {
        if (this._0xbde26cea < 0f)
        {
            return;
        }

        this._0xbde26cea += Time.unscaledDeltaTime;
        float _0xe8f1348e = Mathf.Clamp01(this._0xbde26cea / this._life);
        this.Apply(Mathf.Sin(_0xe8f1348e * Mathf.PI) * this._peakAlpha);
        if (_0xe8f1348e >= 1f)
        {
            this._0xbde26cea = -1f;
            this.Apply(0f);
        }
    }

    private void Start()
    {
        this.Apply(0f);
    }

    [SerializeField]
    private float _peakAlpha = 0.25f;
    public void _0x8c23dd85()
    {
        this._0xbde26cea = 0f;
    }

    private void Apply(float _0x0410d807)
    {
        if (this._overlay != null)
        {
            this._overlay.color = _0xd2ac8035.Fade(_0xd2ac8035.Coral, _0x0410d807);
        }
    }

    private float _0xbde26cea = -1f;
}
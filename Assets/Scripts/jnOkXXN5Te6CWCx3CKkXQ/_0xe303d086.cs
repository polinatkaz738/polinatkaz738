using UnityEngine;

/// <summary>A short coral puff where a fruit went wrong. Self-destructs; never loops.</summary>
public sealed class _0xe303d086 : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _renderer;
    private void Update()
    {
        this._0x5d3bacd4 += Time.deltaTime;
        float _0xfb05bd96 = Mathf.Clamp01(this._0x5d3bacd4 / this._life);
        if (this._renderer != null)
        {
            float _0x37a3c2c7 = this._0xa7378c87 * (1f + (this._growth * _0xfb05bd96));
            this._renderer.size = new Vector2(_0x37a3c2c7, _0x37a3c2c7);
            Color _0xcb8abfea = this._renderer.color;
            this._renderer.color = new Color(_0xcb8abfea.r, _0xcb8abfea.g, _0xcb8abfea.b, 1f - _0xfb05bd96);
        }

        if (_0xfb05bd96 >= 1f)
        {
            Destroy(this.gameObject);
        }
    }

    private float _0xa7378c87;
    [SerializeField]
    private float _life = 0.3f;
    private void Awake()
    {
        this._0xa7378c87 = this._renderer == null ? 0.5f : this._renderer.size.x;
    }

    public void Play(Color _0x644b643b)
    {
        this._0x5d3bacd4 = 0f;
        if (this._renderer != null)
        {
            this._renderer.color = _0x644b643b;
        }
    }

    [SerializeField]
    private float _growth = 0.45f;
    private float _0x5d3bacd4;
}
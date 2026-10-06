using UnityEngine;

/// <summary>
/// The flourish on a scored catch. Rays are authored in the prefab at fixed angles
/// with their Sliced size and sorting order already set, so the effect is correct on
/// its first frame (C.0 / F.2) and lives entirely inside the sprite band.
/// </summary>
public sealed class _0xf98dc253 : MonoBehaviour
{
    private void Awake()
    {
        this._0x2082f28e = new Vector3[this._rays == null ? 0 : this._rays.Length];
        for (int _0x965b3901 = 0; _0x965b3901 < this._0x2082f28e.Length; _0x965b3901++)
        {
            float _0xa6c51583 = (360f / Mathf.Max(1, this._0x2082f28e.Length)) * _0x965b3901 * Mathf.Deg2Rad;
            this._0x2082f28e[_0x965b3901] = new Vector3(Mathf.Cos(_0xa6c51583), Mathf.Sin(_0xa6c51583), 0f);
        }
    }

    private void Update()
    {
        this._0x0d0284e4 += Time.deltaTime;
        float _0xbd79854a = Mathf.Clamp01(this._0x0d0284e4 / this._life);
        float _0xe409583f = 1f - ((1f - _0xbd79854a) * (1f - _0xbd79854a));
        if (this._rays != null && this._0x2082f28e != null)
        {
            for (int _0x7a0b49d4 = 0; _0x7a0b49d4 < this._rays.Length && _0x7a0b49d4 < this._0x2082f28e.Length; _0x7a0b49d4++)
            {
                SpriteRenderer _0x175c980f = this._rays[_0x7a0b49d4];
                if (_0x175c980f == null)
                {
                    continue;
                }

                _0x175c980f.transform.localPosition = this._0x2082f28e[_0x7a0b49d4] * (this._reach * this._0x59badc4a * _0xe409583f);
                Color _0xf31379e3 = _0x175c980f.color;
                _0x175c980f.color = new Color(_0xf31379e3.r, _0xf31379e3.g, _0xf31379e3.b, 1f - _0xbd79854a);
            }
        }

        if (_0xbd79854a >= 1f)
        {
            Destroy(this.gameObject);
        }
    }

    private float _0x59badc4a = 1f;
    [SerializeField]
    private float _life = 0.34f;
    [SerializeField]
    private float _reach = 0.42f;
    public void Play(Color _0x54e2758b, float _0xdfa8f666)
    {
        this._0x0d0284e4 = 0f;
        this._0x59badc4a = _0xdfa8f666;
        if (this._rays == null)
        {
            return;
        }

        for (int _0xd69340d3 = 0; _0xd69340d3 < this._rays.Length; _0xd69340d3++)
        {
            if (this._rays[_0xd69340d3] != null)
            {
                this._rays[_0xd69340d3].color = _0x54e2758b;
            }
        }
    }

    private Vector3[] _0x2082f28e;
    private float _0x0d0284e4;
    [SerializeField]
    private SpriteRenderer[] _rays;
}
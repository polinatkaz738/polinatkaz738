using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Replays a RoundPlan onto the field: spawns each fruit from the prefab reference
/// at the right moment and keeps the live ones so the director can resolve them.
/// Every spawn goes through the serialized prefab reference - nothing is loaded by
/// name or path, which is the only form obfuscation cannot break.
/// </summary>
public sealed class _0x1c80f0d7 : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _decorSprites;
    public void _0xf7d04a77(_0xa6e317c1 _0xf18d11a8)
    {
        if (_0xf18d11a8 == null)
        {
            return;
        }

        this._0x9d0f7912.Remove(_0xf18d11a8);
        Destroy(_0xf18d11a8.gameObject);
    }

    [SerializeField]
    private SpriteRenderer[] _decorSlots;
    /// <summary>
    /// Side decoration is part of what makes two attempts look different (C.11), so
    /// the slot contents come from the plan rather than from the scene.
    /// </summary>
    private void _0x6e599409(_0x55510436 _0x120dd1e5)
    {
        if (this._decorSlots == null || this._decorSprites == null || this._decorSprites.Length == 0)
        {
            return;
        }

        for (int _0x4da6d69c = 0; _0x4da6d69c < this._decorSlots.Length; _0x4da6d69c++)
        {
            SpriteRenderer _0x513e3853 = this._decorSlots[_0x4da6d69c];
            if (_0x513e3853 == null)
            {
                continue;
            }

            int _0x6857cd4a = _0x120dd1e5 != null && _0x120dd1e5.Decor != null && _0x4da6d69c < _0x120dd1e5.Decor.Length ? _0x120dd1e5.Decor[_0x4da6d69c] : _0x4da6d69c;
            bool _0x967ecec1 = _0x6857cd4a >= this._decorSprites.Length;
            _0x513e3853.gameObject.SetActive(!_0x967ecec1);
            if (!_0x967ecec1)
            {
                _0x513e3853.sprite = this._decorSprites[_0x6857cd4a];
            }
        }
    }

    private Sprite _0x4f6f6210(int _0x990a3ee6)
    {
        if (this._fruitSprites == null || this._fruitSprites.Length == 0)
        {
            return null;
        }

        return this._fruitSprites[Mathf.Clamp(_0x990a3ee6, 0, this._fruitSprites.Length - 1)];
    }

    private readonly List<_0xa6e317c1> _0x9d0f7912 = new List<_0xa6e317c1>();
    public List<_0xa6e317c1> _0x42b08ff4
    {
        get
        {
            return this._0x9d0f7912;
        }
    }

    /// <summary>Spawns everything whose moment has passed. Returns how many appeared.</summary>
    public int _0xd8d48e83(float _0x055d8bb5)
    {
        if (this._0x365a981a == null)
        {
            return 0;
        }

        int _0xaad4a22f = 0;
        while (this._0x31c93384 < this._0x365a981a.Count && this._0x365a981a.Time[this._0x31c93384] <= _0x055d8bb5)
        {
            this._0x66f30ad0(this._0x31c93384);
            this._0x31c93384++;
            _0xaad4a22f++;
        }

        return _0xaad4a22f;
    }

    private void _0x66f30ad0(int _0x18866365)
    {
        if (this._fruitPrefab == null || this._host == null || this._laneX == null || this._laneX.Length == 0)
        {
            return;
        }

        bool _0xf8da819f = this._0x365a981a.Crowned[_0x18866365];
        int _0x8890c7e3 = this._0x365a981a.Colour[_0x18866365];
        Sprite _0x907ee99f = _0xf8da819f ? this._crownedSprite : this._0x4f6f6210(_0x8890c7e3);
        int _0x3885cbb5 = Mathf.Clamp(this._0x365a981a.Lane[_0x18866365], 0, this._laneX.Length - 1);
        float _0x5e83ea9d = _0xf8da819f ? this._fruitDiameter * 1.15f : this._fruitDiameter;
        _0xa6e317c1 _0x7941b7e3 = Instantiate(this._fruitPrefab, this._host);
        _0x7941b7e3._0x501b06f4(_0x907ee99f, _0x8890c7e3, _0xf8da819f, this._0x365a981a.Speed[_0x18866365], _0x5e83ea9d, new Vector3(this._laneX[_0x3885cbb5], this._spawnY, 0f), _0x18866365 * 0.73f);
        this._0x9d0f7912.Add(_0x7941b7e3);
    }

    private _0x55510436 _0x365a981a;
    private int _0x31c93384;
    public void _0x15b59ea4(_0x55510436 _0x83dec6c8)
    {
        this._0xb405fbfe();
        this._0x365a981a = _0x83dec6c8;
        this._0x31c93384 = 0;
        this._0x6e599409(_0x83dec6c8);
    }

    [SerializeField]
    private float _fruitDiameter = 0.5215f;
    [SerializeField]
    private Sprite _crownedSprite;
    [SerializeField]
    private float _spawnY = 5.6f;
    public float[] _0x79b7b573
    {
        get
        {
            return this._laneX;
        }
    }

    [SerializeField]
    private Sprite[] _fruitSprites;
    public void _0xb405fbfe()
    {
        for (int _0x12396ad6 = 0; _0x12396ad6 < this._0x9d0f7912.Count; _0x12396ad6++)
        {
            if (this._0x9d0f7912[_0x12396ad6] != null)
            {
                Destroy(this._0x9d0f7912[_0x12396ad6].gameObject);
            }
        }

        this._0x9d0f7912.Clear();
    }

    [SerializeField]
    private Transform _host;
    [SerializeField]
    private float[] _laneX;
    [SerializeField]
    private _0xa6e317c1 _fruitPrefab;
}
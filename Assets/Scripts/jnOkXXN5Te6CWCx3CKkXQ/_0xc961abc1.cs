using UnityEngine;

/// <summary>
/// Builds the content of one attempt from a seed and proves it is clearable before
/// anyone sees it (CLAUDE-unity.md C.11). Nothing the player reacts to is hard-coded:
/// lanes, colours, spawn jitter, fall-speed jitter, the moment each crowned plum
/// arrives, where the tray starts, which cushion starts active and the side decor all
/// come out of the generator. The only constant layout left is the fallback, and that
/// is a guarantee of last resort, not the game.
/// </summary>
public sealed class _0xc961abc1
{
    private const int DecorSlots = 4;
    private readonly float _0xfd9f9873;
    private readonly float[] _0x00f6ea05;
    /// <summary>
    /// The guarantee of last resort: an evenly spread, always-solvable layout. It
    /// exists so a hostile seed cannot hand the player an impossible round - it is
    /// not what the game normally plays.
    /// </summary>
    private _0x55510436 _0xebe134c6(int _0x68fef787, float _0xff5e3d85, float spawnInterval, float _0x450249ab, float _0xfbe582ac, float _0x5ddf4a29)
    {
        int _0xc27490ba = Mathf.Max(_0x68fef787 + 10, Mathf.CeilToInt(_0x5ddf4a29 / spawnInterval));
        _0x55510436 _0x4d3300c0 = new _0x55510436(_0xc27490ba + 5, DecorSlots);
        float _0xd471ae6b = 1.4f;
        for (int _0x92a01803 = 0; _0x92a01803 < _0xc27490ba; _0x92a01803++)
        {
            _0x4d3300c0.Time[_0x92a01803] = _0xd471ae6b;
            _0x4d3300c0.Lane[_0x92a01803] = 1 + (_0x92a01803 % 3);
            _0x4d3300c0.Colour[_0x92a01803] = _0x92a01803 % 3;
            _0x4d3300c0.Crowned[_0x92a01803] = false;
            _0x4d3300c0.Speed[_0x92a01803] = _0xff5e3d85;
            _0xd471ae6b += spawnInterval;
        }

        for (int _0xc10cb0b9 = 0; _0xc10cb0b9 < 5; _0xc10cb0b9++)
        {
            int _0xaca4906f = _0xc27490ba + _0xc10cb0b9;
            _0x4d3300c0.Time[_0xaca4906f] = _0x450249ab + (_0xc10cb0b9 * _0xfbe582ac);
            _0x4d3300c0.Lane[_0xaca4906f] = 2;
            _0x4d3300c0.Colour[_0xaca4906f] = -1;
            _0x4d3300c0.Crowned[_0xaca4906f] = true;
            _0x4d3300c0.Speed[_0xaca4906f] = _0xff5e3d85 * 0.92f;
        }

        _0x4d3300c0.StartSection = 0;
        _0x4d3300c0.StartX = 0f;
        for (int _0xc7baca89 = 0; _0xc7baca89 < DecorSlots; _0xc7baca89++)
        {
            _0x4d3300c0.Decor[_0xc7baca89] = _0xc7baca89 % DecorVariants;
        }

        this._0xabbdd362(_0x4d3300c0);
        return _0x4d3300c0;
    }

    /// <summary>
    /// A render-free replay of a perfect player: can they reach every crowned plum,
    /// take comfortably more than the target in ordinary fruit, and is the opening of
    /// the round actually busy? A plan that fails any of the three is thrown away.
    /// </summary>
    public bool _0xd5ee7b13(_0x55510436 _0xcaed3845, int _0xd831b868, float _0xd60727c3)
    {
        int _0x282fb950 = 0;
        for (int _0x1456c682 = 0; _0x1456c682 < _0xcaed3845.Count; _0x1456c682++)
        {
            if (!_0xcaed3845.Crowned[_0x1456c682] && _0xcaed3845.Time[_0x1456c682] <= 10f)
            {
                _0x282fb950++;
            }
        }

        if (_0x282fb950 < 4)
        {
            return false;
        }

        float _0x5bfd4c8f = _0xcaed3845.StartX;
        int _0x9d8b53bf = _0xcaed3845.StartSection;
        float _0x73640f4f = 0f;
        int _0xeea0ea61 = 0;
        for (int _0x77c0179f = 0; _0x77c0179f < _0xcaed3845.Count; _0x77c0179f++)
        {
            float _0xac06a447 = _0xcaed3845.Time[_0x77c0179f] + (this._0xfd9f9873 / _0xcaed3845.Speed[_0x77c0179f]);
            float _0x3f82adcf = this._0x00f6ea05[_0xcaed3845.Lane[_0x77c0179f]];
            float _0x1ab1c1c8 = Mathf.Clamp(_0x3f82adcf, -this._0x2d7b465a, this._0x2d7b465a);
            float _0x20e7147a = Mathf.Abs(_0x1ab1c1c8 - _0x5bfd4c8f) / this._0x4eb731f2;
            int _0x404e97d3 = _0xcaed3845.Crowned[_0x77c0179f] ? _0x9d8b53bf : _0xcaed3845.Colour[_0x77c0179f];
            float _0x3c77ce13 = _0x404e97d3 == _0x9d8b53bf ? 0f : SwitchCost * this._0xa1d40608(_0x9d8b53bf, _0x404e97d3);
            bool _0x569161e2 = _0x73640f4f + _0x20e7147a + _0x3c77ce13 <= _0xac06a447;
            if (_0xcaed3845.Crowned[_0x77c0179f])
            {
                if (!_0x569161e2)
                {
                    return false;
                }
            }
            else if (_0x569161e2)
            {
                // The cushion has to sit under the lane, not merely near it.
                if (Mathf.Abs(_0x3f82adcf - _0x1ab1c1c8) <= this._0x4952c8b4 * 1.5f)
                {
                    _0xeea0ea61++;
                }
            }

            if (_0x569161e2)
            {
                _0x5bfd4c8f = _0x1ab1c1c8;
                _0x9d8b53bf = _0x404e97d3;
                _0x73640f4f = _0xac06a447;
            }
        }

        return _0xeea0ea61 >= _0xd831b868 + 6;
    }

    private readonly float _0x2d7b465a;
    private readonly float _0x4952c8b4;
    private const int DecorVariants = 7;
    /// <summary>
    /// Deterministic in the seed, so a reported bug can be replayed exactly.
    /// System.Random, never UnityEngine.Random: the latter is global state shared with
    /// everything else in the process, and "the same seed" then stops meaning the same run.
    /// </summary>
    public _0x55510436 _0x733c5d60(int _0x35d360bf, int _0xd04b12cd, int _0xcb844e08, float _0x7c96b58f, float spawnInterval, float _0xb57e316d, float _0x0da40c5f, float _0xf0630fd3)
    {
        int _0x1d507d5d = (_0x35d360bf * 7919) ^ (_0xd04b12cd * 104729);
        System.Random _0x11390ed0 = new System.Random(_0x1d507d5d);
        {
#if B_LOGS
            {
                Debug.Log(_0x6cad0d43._0xbbb67667(new byte[14] { 174, 135, 154, 128, 155, 145, 168, 213, 134, 129, 148, 146, 144, 200 }, 245) + _0x35d360bf.ToString() + _0x6cad0d43._0xbbb67667(new byte[9] { 167, 230, 243, 243, 226, 234, 247, 243, 186 }, 135) + _0xd04b12cd.ToString() + _0x6cad0d43._0xbbb67667(new byte[6] { 49, 98, 116, 116, 117, 44 }, 17) + _0x1d507d5d.ToString());
            }
#endif
        }

        _0x55510436 _0x05f65d9d = null;
        for (int _0xff3ec9a5 = 0; _0xff3ec9a5 < MaxAttempts; _0xff3ec9a5++)
        {
            _0x05f65d9d = this._0x0d5d600c(_0x11390ed0, _0xcb844e08, _0x7c96b58f, spawnInterval, _0xb57e316d, _0x0da40c5f, _0xf0630fd3);
            if (this._0xd5ee7b13(_0x05f65d9d, _0xcb844e08, _0x7c96b58f))
            {
                return _0x05f65d9d;
            }
        }

        return this._0xebe134c6(_0xcb844e08, _0x7c96b58f, spawnInterval, _0xb57e316d, _0x0da40c5f, _0xf0630fd3);
    }

    private const int MaxAttempts = 20;
    private const float SwitchCost = 0.16f;
    private void _0xabbdd362(_0x55510436 _0xc7ca1c1f)
    {
        for (int _0x667d7fc1 = 1; _0x667d7fc1 < _0xc7ca1c1f.Count; _0x667d7fc1++)
        {
            for (int _0x8eed8075 = _0x667d7fc1; _0x8eed8075 > 0 && _0xc7ca1c1f.Time[_0x8eed8075] < _0xc7ca1c1f.Time[_0x8eed8075 - 1]; _0x8eed8075--)
            {
                this._0x3f5c2c11(_0xc7ca1c1f, _0x8eed8075, _0x8eed8075 - 1);
            }
        }
    }

    private readonly float _0x4eb731f2;
    /// <summary>
    /// Colour with two constraints the player can feel: never four of a kind in a
    /// row, and every window of eight contains all three cushions - otherwise the
    /// target is unreachable by construction, however well the player plays.
    /// </summary>
    private int _0xac327512(System.Random _0xdb2ff70f, _0x55510436 _0xc3957da7, int _0x849d9285)
    {
        for (int _0x8d29a128 = 0; _0x8d29a128 < 12; _0x8d29a128++)
        {
            int _0x4290bf2c = _0xdb2ff70f.Next(0, 3);
            if (_0x849d9285 >= 3 && _0xc3957da7.Colour[_0x849d9285 - 1] == _0x4290bf2c && _0xc3957da7.Colour[_0x849d9285 - 2] == _0x4290bf2c && _0xc3957da7.Colour[_0x849d9285 - 3] == _0x4290bf2c)
            {
                continue;
            }

            if (_0x849d9285 >= 7)
            {
                bool[] _0xc9b6e316 = new bool[3];
                _0xc9b6e316[_0x4290bf2c] = true;
                for (int _0xb53e5c36 = _0x849d9285 - 7; _0xb53e5c36 < _0x849d9285; _0xb53e5c36++)
                {
                    if (_0xc3957da7.Colour[_0xb53e5c36] >= 0)
                    {
                        _0xc9b6e316[_0xc3957da7.Colour[_0xb53e5c36]] = true;
                    }
                }

                if (!_0xc9b6e316[0] || !_0xc9b6e316[1] || !_0xc9b6e316[2])
                {
                    int _0xe71bd0f5 = !_0xc9b6e316[0] ? 0 : (!_0xc9b6e316[1] ? 1 : 2);
                    return _0xe71bd0f5;
                }
            }

            return _0x4290bf2c;
        }

        return _0xdb2ff70f.Next(0, 3);
    }

    private void _0x3f5c2c11(_0x55510436 _0x9ab7a3fb, int _0xfbf23b85, int _0x830b0145)
    {
        float _0xa00b1f73 = _0x9ab7a3fb.Time[_0xfbf23b85];
        _0x9ab7a3fb.Time[_0xfbf23b85] = _0x9ab7a3fb.Time[_0x830b0145];
        _0x9ab7a3fb.Time[_0x830b0145] = _0xa00b1f73;
        int _0xdfd6ef0f = _0x9ab7a3fb.Lane[_0xfbf23b85];
        _0x9ab7a3fb.Lane[_0xfbf23b85] = _0x9ab7a3fb.Lane[_0x830b0145];
        _0x9ab7a3fb.Lane[_0x830b0145] = _0xdfd6ef0f;
        int _0x7c86bdc2 = _0x9ab7a3fb.Colour[_0xfbf23b85];
        _0x9ab7a3fb.Colour[_0xfbf23b85] = _0x9ab7a3fb.Colour[_0x830b0145];
        _0x9ab7a3fb.Colour[_0x830b0145] = _0x7c86bdc2;
        bool _0x19e860b1 = _0x9ab7a3fb.Crowned[_0xfbf23b85];
        _0x9ab7a3fb.Crowned[_0xfbf23b85] = _0x9ab7a3fb.Crowned[_0x830b0145];
        _0x9ab7a3fb.Crowned[_0x830b0145] = _0x19e860b1;
        float _0x0f73cd49 = _0x9ab7a3fb.Speed[_0xfbf23b85];
        _0x9ab7a3fb.Speed[_0xfbf23b85] = _0x9ab7a3fb.Speed[_0x830b0145];
        _0x9ab7a3fb.Speed[_0x830b0145] = _0x0f73cd49;
    }

    public _0xc961abc1(float[] _0xacaef877, float _0xe41576fa, float _0xc0f6f584, float _0x3e1f4820, float _0x6ebb3e3e)
    {
        this._0x00f6ea05 = _0xacaef877;
        this._0xfd9f9873 = _0xe41576fa;
        this._0x2d7b465a = _0xc0f6f584;
        this._0x4eb731f2 = _0x3e1f4820;
        this._0x4952c8b4 = _0x6ebb3e3e;
    }

    private _0x55510436 _0x0d5d600c(System.Random _0x35c8359b, int _0xb0e5a27e, float _0xf1a151b1, float spawnInterval, float _0xdec9ca44, float _0x01c66d48, float _0x028df91b)
    {
        int _0x3405e73a = Mathf.Max(_0xb0e5a27e + 10, Mathf.CeilToInt(_0x028df91b / spawnInterval));
        int _0x5e17f7bf = 5;
        _0x55510436 _0x60beff5c = new _0x55510436(_0x3405e73a + _0x5e17f7bf, DecorSlots);
        // --- ordinary fruit -------------------------------------------------
        int[] _0xc35abf4f = new int[3];
        for (int _0x6af13802 = 0; _0x6af13802 < 3; _0x6af13802++)
        {
            _0xc35abf4f[_0x6af13802] = -1;
        }

        float _0x8ba27732 = 1.4f;
        for (int _0x03197e6d = 0; _0x03197e6d < _0x3405e73a; _0x03197e6d++)
        {
            _0x60beff5c.Time[_0x03197e6d] = _0x8ba27732;
            _0x60beff5c.Lane[_0x03197e6d] = _0x35c8359b.Next(0, this._0x00f6ea05.Length);
            _0x60beff5c.Colour[_0x03197e6d] = this._0xac327512(_0x35c8359b, _0x60beff5c, _0x03197e6d);
            _0x60beff5c.Crowned[_0x03197e6d] = false;
            _0x60beff5c.Speed[_0x03197e6d] = _0xf1a151b1 * (1f + (((float)_0x35c8359b.NextDouble() * 0.12f) - 0.06f));
            _0x8ba27732 += spawnInterval + (((float)_0x35c8359b.NextDouble() * 0.36f) - 0.18f);
        }

        // --- crowned plums --------------------------------------------------
        // Only the three middle lanes: the outer lanes sit beyond the reach of the
        // tray centre, and a plum that cannot be caught is a life taken by geometry.
        for (int _0x8e23c390 = 0; _0x8e23c390 < _0x5e17f7bf; _0x8e23c390++)
        {
            int _0x3bad2357 = _0x3405e73a + _0x8e23c390;
            _0x60beff5c.Time[_0x3bad2357] = _0xdec9ca44 + (_0x8e23c390 * _0x01c66d48) + (((float)_0x35c8359b.NextDouble() * 3f) - 1.5f);
            _0x60beff5c.Lane[_0x3bad2357] = 1 + _0x35c8359b.Next(0, 3);
            _0x60beff5c.Colour[_0x3bad2357] = -1;
            _0x60beff5c.Crowned[_0x3bad2357] = true;
            _0x60beff5c.Speed[_0x3bad2357] = _0xf1a151b1 * 0.92f;
        }

        _0x60beff5c.StartSection = _0x35c8359b.Next(0, 3);
        _0x60beff5c.StartX = (((float)_0x35c8359b.NextDouble() * 2f) - 1f) * this._0x2d7b465a * 0.6f;
        for (int _0x92defefd = 0; _0x92defefd < DecorSlots; _0x92defefd++)
        {
            _0x60beff5c.Decor[_0x92defefd] = _0x35c8359b.Next(0, DecorVariants);
        }

        this._0xabbdd362(_0x60beff5c);
        return _0x60beff5c;
    }

    private int _0xa1d40608(int _0x18834803, int _0x52893d6f)
    {
        int _0x94b450dc = _0x52893d6f - _0x18834803;
        if (_0x94b450dc < 0)
        {
            _0x94b450dc += 3;
        }

        return _0x94b450dc;
    }
}

internal static class _0x6cad0d43
{
    internal static string _0xbbb67667(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
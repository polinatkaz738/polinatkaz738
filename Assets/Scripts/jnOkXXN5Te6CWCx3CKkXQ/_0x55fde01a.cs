using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The round: generates the attempt, feeds the spawner, resolves every fruit against
/// the tray and decides how the audience ends.
///
/// Pace is set by CLAUDE-unity.md C.5 - with no input at all the run lasts past the
/// seventy-sixth second on stage one, so the review capture (first gameplay frame
/// around second fifteen, last around second thirty) always photographs a live field
/// rather than a result card.
/// </summary>
public sealed class _0x55fde01a : MonoBehaviour
{
    // ---------------------------------------------------------------- main loop
    private void Update()
    {
        _0x9d5294e1 _0xfc1721ff = _0x9d5294e1.Instance;
        bool _0x0433ae96 = _0xfc1721ff == null || _0xfc1721ff._0xc6e1c633;
        if (_0x0433ae96 != this._0x09f2648c)
        {
            this._0x09f2648c = _0x0433ae96;
            if (this._tray != null)
            {
                this._tray._0x169130cb(_0x0433ae96 && this._0x7e04663d == StatePlaying);
            }
        }

        if (!_0x0433ae96 || this._0x7e04663d == StateOver)
        {
            return;
        }

        float dt = Time.deltaTime;
        this._0x97843810 += dt;
        if (this._0x7e04663d == StateIntro)
        {
            if (this._0x97843810 >= this._introSeconds)
            {
                this._0x7e04663d = StatePlaying;
                if (this._tray != null)
                {
                    this._tray._0x169130cb(true);
                }
            }

            return;
        }

        if (this._favor != null)
        {
            this._favor._0x4f341c4e(dt);
            if (this._favor._0x8d388a6a)
            {
                this._0x6fac18ef(false, true);
                return;
            }
        }

        if (this._spawner != null)
        {
            this._spawner._0xd8d48e83(this._0x97843810 - this._introSeconds);
            this._0xb94c39c2();
        }
    }

    // ---------------------------------------------------------------- endings
    private void _0x6fac18ef(bool _0xb485e8cd, bool _0xc45d94c5)
    {
        if (this._0x7e04663d == StateOver)
        {
            return;
        }

        this._0x7e04663d = StateOver;
        if (this._tray != null)
        {
            this._tray._0x169130cb(false);
        }

        if (this._spawner != null)
        {
            this._spawner._0xb405fbfe();
        }

        this._0xe0666d64._0xef2def7b(this._0xf6c0c56f, this._0x0bbfed71);
        int _0x04660788 = this._favor == null ? 0 : Mathf.RoundToInt(this._favor._0x8f94c4ce);
        int _0xe94038f4 = this._0xe0666d64._0x672ab235(this._0xf6c0c56f);
        if (_0xb485e8cd)
        {
            _0x01210122 _0xf6ac91c9 = this._pops == null ? null : this._pops._0x489cfebd;
            if (_0xf6ac91c9 != null)
            {
                _0xf6ac91c9._0x7fd352fc(_0xdef9419a._0x0c28a4f2(new byte[20] { 250, 230, 235, 142, 237, 225, 251, 252, 250, 142, 231, 253, 142, 254, 226, 235, 239, 253, 235, 234 }, 174), _0xdef9419a._0x0c28a4f2(new byte[8] { 50, 59, 40, 44, 63, 41, 46, 90 }, 122) + this._0x0bbfed71.ToString() + _0xdef9419a._0x0c28a4f2(new byte[3] { 76, 67, 76 }, 108) + this._0x9b4a2554.ToString(), _0xdef9419a._0x0c28a4f2(new byte[6] { 145, 150, 129, 152, 133, 247 }, 215) + _0x04660788.ToString() + _0xdef9419a._0x0c28a4f2(new byte[8] { 100, 105, 100, 6, 1, 23, 16, 100 }, 68) + _0xe94038f4.ToString());
                _0xf6ac91c9.SetIllustration(this._crownedSprite, Color.white);
                _0xf6ac91c9._0x98db9049(new string[] { _0xdef9419a._0x0c28a4f2(new byte[10] { 240, 251, 230, 234, 158, 237, 234, 255, 249, 251 }, 190), _0xdef9419a._0x0c28a4f2(new byte[4] { 36, 44, 39, 60 }, 105) }, new Color[] { _0xd2ac8035.Leaf, _0xd2ac8035.Raised });
            }

            this._0x2759d053(_0xea334b23._0xca25cf66.WIN);
        }
        else
        {
            _0x01210122 _0xb021e4bc = this._pops == null ? null : this._pops._0x5204968c;
            if (_0xb021e4bc != null)
            {
                _0xb021e4bc._0x7fd352fc(_0xdef9419a._0x0c28a4f2(new byte[13] { 17, 5, 20, 25, 21, 30, 19, 21, 112, 31, 6, 21, 2 }, 80), _0xdef9419a._0x0c28a4f2(new byte[8] { 145, 152, 139, 143, 156, 138, 141, 249 }, 217) + this._0x0bbfed71.ToString() + _0xdef9419a._0x0c28a4f2(new byte[3] { 212, 219, 212 }, 244) + this._0x9b4a2554.ToString(), _0xc45d94c5 ? _0xdef9419a._0x0c28a4f2(new byte[22] { 155, 156, 139, 146, 143, 253, 142, 141, 152, 147, 137, 253, 137, 146, 253, 147, 146, 137, 149, 148, 147, 154 }, 221) : _0xdef9419a._0x0c28a4f2(new byte[17] { 45, 48, 38, 62, 51, 95, 57, 45, 42, 54, 43, 95, 51, 48, 44, 43, 95 }, 127) + (this._lives - this._0x7169fca1).ToString());
                _0xb021e4bc.SetIllustration(this._crownedSprite, _0xd2ac8035.Muted);
                _0xb021e4bc._0x98db9049(new string[] { _0xdef9419a._0x0c28a4f2(new byte[10] { 140, 144, 157, 133, 252, 157, 155, 157, 149, 146 }, 220), _0xdef9419a._0x0c28a4f2(new byte[4] { 242, 250, 241, 234 }, 191) }, new Color[] { _0xd2ac8035.Coral, _0xd2ac8035.Raised });
            }

            this._0x2759d053(_0xea334b23._0xca25cf66.LOSE);
        }
    }

    [SerializeField]
    private float _trayY = -3.75f;
    private float _0x97843810;
    private void Start()
    {
        if (this._backButton != null)
        {
            this._backButton.onClick.AddListener(() => this._0xa8c6e5ca());
        }

        if (this._pauseButton != null)
        {
            this._pauseButton.onClick.AddListener(() => this._0xed66b09d());
        }

        this._0xe8f621b5();
        this._0xd2d1ac03();
    }

    [SerializeField]
    private _0x20dcc910 _pops;
    private bool _0x09f2648c;
    private void _0x7293a7ae()
    {
        _0x2cc5c82d _0x1a578e0a = _0x2cc5c82d.Instance;
        if (_0x1a578e0a != null)
        {
            _0x1a578e0a._0xc6c86a07();
        }

        _0x9d5294e1 _0x0924b7b6 = _0x9d5294e1.Instance;
        if (_0x0924b7b6 != null)
        {
            _0x0924b7b6.LoadSceneByIndex(_0xea334b23._0xa4801ffa.SCENE_1);
        }
    }

    private void _0x23a3ab19(Vector3 _0x7ea163b6, Color _0x23cc77ef)
    {
        if (this._puffPrefab == null || this._effectHost == null)
        {
            return;
        }

        _0xe303d086 _0x7e54b89a = Instantiate(this._puffPrefab, this._effectHost);
        _0x7e54b89a.transform.localPosition = _0x7ea163b6;
        _0x7e54b89a.Play(_0x23cc77ef);
    }

    [SerializeField]
    private float _traySpeed = 5.2f;
    [SerializeField]
    private _0x1c80f0d7 _spawner;
    [SerializeField]
    private _0x1a95cfd1 _table;
    [SerializeField]
    private Sprite _crownedSprite;
    [SerializeField]
    private Transform _effectHost;
    /// <summary>
    /// A fruit is judged when its centre crosses the tray line. Correct colour on the
    /// receiving cushion scores; the wrong colour on that cushion costs favour; a
    /// cushion that is not receiving simply lets it pass. A crowned plum is caught by
    /// any cushion - it costs a life, so it tests placement, not colour.
    /// </summary>
    private void _0xb94c39c2()
    {
        for (int _0x27c742af = this._spawner._0x42b08ff4.Count - 1; _0x27c742af >= 0; _0x27c742af--)
        {
            // EndRound clears the field, so the moment the round is decided the walk
            // has to stop - the list it is walking no longer exists.
            if (this._0x7e04663d == StateOver)
            {
                return;
            }

            if (_0x27c742af >= this._spawner._0x42b08ff4.Count)
            {
                continue;
            }

            _0xa6e317c1 _0x1c9c6900 = this._spawner._0x42b08ff4[_0x27c742af];
            if (_0x1c9c6900 == null)
            {
                this._spawner._0x42b08ff4.RemoveAt(_0x27c742af);
                continue;
            }

            if (_0x1c9c6900._0x7b9bebc6)
            {
                continue;
            }

            if (_0x1c9c6900._0x758e23f0 > this._trayY)
            {
                continue;
            }

            int _0xaab4f542 = this._tray == null ? -1 : this._tray._0xb2308299(_0x1c9c6900._0x2e3915b8);
            Vector3 _0x2b537e50 = new Vector3(_0x1c9c6900._0x2e3915b8, this._trayY, 0f);
            if (_0x1c9c6900._0x36667e03)
            {
                if (_0xaab4f542 >= 0)
                {
                    this._0x0bbfed71 += 3;
                    if (this._favor != null)
                    {
                        this._favor.Add(12f);
                    }

                    this._0xeb73623c(_0x2b537e50, _0xd2ac8035.Gold, 1.7f);
                    this._0x1aacacc7();
                    this._spawner._0xf7d04a77(_0x1c9c6900);
                }
                else if (_0x1c9c6900._0x758e23f0 < this._trayY - 0.4f)
                {
                    this._0x7169fca1--;
                    if (this._hud != null)
                    {
                        this._hud._0x477c664e(this._0x7169fca1);
                    }

                    if (this._vignette != null)
                    {
                        this._vignette._0x8c23dd85();
                    }

                    this._0x23a3ab19(_0x2b537e50, _0xd2ac8035.Coral);
                    this._spawner._0xf7d04a77(_0x1c9c6900);
                    if (this._0x7169fca1 <= 0)
                    {
                        this._0x6fac18ef(false, false);
                        return;
                    }
                }

                continue;
            }

            if (_0xaab4f542 < 0)
            {
                if (_0x1c9c6900._0x758e23f0 < this._trayY - 1.6f)
                {
                    this._spawner._0xf7d04a77(_0x1c9c6900);
                }

                continue;
            }

            if (_0xaab4f542 == this._tray._0x2127ec75)
            {
                if (_0x1c9c6900._0x40750151 == _0xaab4f542)
                {
                    this._0x0bbfed71++;
                    if (this._favor != null)
                    {
                        this._favor.Add(4f);
                    }

                    _0xea334b23._0xdb0cb883._0xd71b9dc9 = _0xea334b23._0xdb0cb883._0xd71b9dc9 + 1;
                    this._0xeb73623c(_0x2b537e50, _0xd2ac8035.Section(_0x1c9c6900._0x40750151), 1f);
                    this._0x1aacacc7();
                }
                else
                {
                    if (this._favor != null)
                    {
                        this._favor.Add(-9f);
                    }

                    if (this._tray != null)
                    {
                        this._tray._0x1a223a89();
                    }

                    this._0x23a3ab19(_0x2b537e50, _0xd2ac8035.Coral);
                }

                this._spawner._0xf7d04a77(_0x1c9c6900);
                continue;
            }

            // Landed on a cushion that is not receiving: no score, no penalty.
            _0x1c9c6900._0x157bc513();
            this._spawner._0xf7d04a77(_0x1c9c6900);
        }
    }

    private const int StateIntro = 0;
    private void _0x1aacacc7()
    {
        if (this._hud != null)
        {
            this._hud._0x520fe43e(this._0x0bbfed71, this._0x9b4a2554);
            this._hud._0x77f0185b();
        }

        if (this._0x0bbfed71 >= this._0x9b4a2554)
        {
            this._0x6fac18ef(true, false);
        }
    }

    [SerializeField]
    private float _trayLimitX = 1.3385f;
    [SerializeField]
    private int _lives = 5;
    [SerializeField]
    private _0xe303d086 _puffPrefab;
    [SerializeField]
    private Button _pauseButton;
    // ---------------------------------------------------------------- effects
    private void _0xeb73623c(Vector3 _0x3ec382e7, Color _0xc3f2612d, float _0x13459ef8)
    {
        if (this._burstPrefab == null || this._effectHost == null)
        {
            return;
        }

        _0xf98dc253 _0x8e0d7b69 = Instantiate(this._burstPrefab, this._effectHost);
        _0x8e0d7b69.transform.localPosition = _0x3ec382e7;
        _0x8e0d7b69.Play(_0xc3f2612d, _0x13459ef8);
    }

    private _0x9ab129fc _0xe0666d64;
    private int _0x7e04663d;
    [SerializeField]
    private _0xea3c1a17 _favor;
    [SerializeField]
    private _0xb5ef045d _vignette;
    private const int StatePlaying = 1;
    [SerializeField]
    private Sprite _crownMarkerSprite;
    private int _0x7169fca1;
    private int _0xf6c0c56f;
    private void _0x2af63693(_0x01210122 _0xcfd9d279, int _0x795ffee7, int _0x6a5b387e)
    {
        if (_0xcfd9d279 == null)
        {
            return;
        }

        Button _0xe1443735 = _0xcfd9d279._0xadeeac5e(_0x795ffee7);
        if (_0xe1443735 == null)
        {
            return;
        }

        // Always a lambda: a method group survives compilation but not the obfuscator,
        // and the cloud build then dies on a name that no longer exists (C.1).
        if (_0x6a5b387e == 0)
        {
            _0xe1443735.onClick.AddListener(() => this._0x74c059b5());
        }
        else if (_0x6a5b387e == 1)
        {
            _0xe1443735.onClick.AddListener(() => this._0x7293a7ae());
        }
        else if (_0x6a5b387e == 2)
        {
            _0xe1443735.onClick.AddListener(() => this._0xa8c6e5ca());
        }
        else
        {
            _0xe1443735.onClick.AddListener(() => this._0x9abc9d12());
        }
    }

    private _0x55510436 _0xf8f5d8aa;
    private int _0x9b4a2554;
    private void _0x74c059b5()
    {
        int _0xa082550d = this._table == null ? 1 : this._table._0x86b3dc30;
        this._0xe0666d64._0x2d5afef4 = Mathf.Min(this._0xf6c0c56f + 1, _0xa082550d - 1);
        this._0x7293a7ae();
    }

    [SerializeField]
    private float _introSeconds = 1.2f;
    private void _0xed66b09d()
    {
        if (this._0x7e04663d == StateOver)
        {
            return;
        }

        _0x01210122 _0x691ed55e = this._pops == null ? null : this._pops._0x78b14d6b;
        if (_0x691ed55e != null)
        {
            int _0xda9c3969 = this._favor == null ? 0 : Mathf.RoundToInt(this._favor._0x8f94c4ce);
            _0x691ed55e._0x7fd352fc(_0xdef9419a._0x0c28a4f2(new byte[12] { 195, 222, 200, 208, 221, 177, 195, 212, 210, 212, 194, 194 }, 145), _0xdef9419a._0x0c28a4f2(new byte[8] { 254, 247, 228, 224, 243, 229, 226, 150 }, 182) + this._0x0bbfed71.ToString() + _0xdef9419a._0x0c28a4f2(new byte[3] { 129, 142, 129 }, 161) + this._0x9b4a2554.ToString(), _0xdef9419a._0x0c28a4f2(new byte[6] { 194, 197, 210, 203, 214, 164 }, 132) + _0xda9c3969.ToString() + _0xdef9419a._0x0c28a4f2(new byte[9] { 135, 138, 135, 235, 238, 241, 226, 244, 135 }, 167) + this._0x7169fca1.ToString());
            _0x691ed55e.SetIllustration(this._crownMarkerSprite, Color.white);
            _0x691ed55e._0x98db9049(new string[] { _0xdef9419a._0x0c28a4f2(new byte[6] { 20, 3, 21, 19, 11, 3 }, 70), _0xdef9419a._0x0c28a4f2(new byte[10] { 186, 166, 171, 179, 202, 171, 173, 171, 163, 164 }, 234), _0xdef9419a._0x0c28a4f2(new byte[4] { 212, 220, 215, 204 }, 153) }, new Color[] { _0xd2ac8035.Leaf, _0xd2ac8035.Gold, _0xd2ac8035.Raised });
        }

        this._0x2759d053(_0xea334b23._0xca25cf66.PAUSE);
    }

    private void _0x2759d053(int _0x81edc328)
    {
        _0x9d5294e1 _0x76099840 = _0x9d5294e1.Instance;
        if (_0x76099840 != null)
        {
            _0x76099840._0x8bcf8e94(false);
        }

        _0x2cc5c82d _0x5dcc583e = _0x2cc5c82d.Instance;
        if (_0x5dcc583e != null)
        {
            // Fetching the pop keeps the content ours: raised without this the card
            // would show the template's own wording (C.3).
            _0x30b2da79 _0x26dd599f = _0x5dcc583e._0x594a6eda(_0x81edc328);
            if (_0x26dd599f != null)
            {
                _0x5dcc583e._0x6dedd689(_0x81edc328);
            }
        }
    }

    private void Awake()
    {
        this._0xe0666d64 = new _0x9ab129fc();
    }

    [SerializeField]
    private Button _backButton;
    private void _0x9abc9d12()
    {
        _0x2cc5c82d _0xa07a7a49 = _0x2cc5c82d.Instance;
        if (_0xa07a7a49 != null)
        {
            _0xa07a7a49._0xc6c86a07();
        }

        _0x9d5294e1 _0x3884ee67 = _0x9d5294e1.Instance;
        if (_0x3884ee67 != null)
        {
            _0x3884ee67._0x8bcf8e94(true);
        }
    }

    [SerializeField]
    private _0xf98dc253 _burstPrefab;
    private const int StateOver = 2;
    private void _0xa8c6e5ca()
    {
        _0x2cc5c82d _0x0c3a67de = _0x2cc5c82d.Instance;
        if (_0x0c3a67de != null)
        {
            _0x0c3a67de._0xc6c86a07();
        }

        _0x9d5294e1 _0x3e61ffef = _0x9d5294e1.Instance;
        if (_0x3e61ffef != null)
        {
            _0x3e61ffef._0x8bcf8e94(true);
            _0x3e61ffef.LoadSceneByIndex(_0xea334b23._0xa4801ffa.SCENE_0);
        }
    }

    [SerializeField]
    private _0x561459ba _hud;
    private void _0xe8f621b5()
    {
        if (this._pops == null)
        {
            return;
        }

        this._0x2af63693(this._pops._0x489cfebd, 0, 0);
        this._0x2af63693(this._pops._0x489cfebd, 1, 2);
        this._0x2af63693(this._pops._0x5204968c, 0, 1);
        this._0x2af63693(this._pops._0x5204968c, 1, 2);
        this._0x2af63693(this._pops._0x78b14d6b, 0, 3);
        this._0x2af63693(this._pops._0x78b14d6b, 1, 1);
        this._0x2af63693(this._pops._0x78b14d6b, 2, 2);
    }

    [SerializeField]
    private _0x6965f42d _tray;
    private int _0x0bbfed71;
    [SerializeField]
    private float _spawnY = 5.6f;
    // ---------------------------------------------------------------- round setup
    private void _0xd2d1ac03()
    {
        this._0xf6c0c56f = Mathf.Clamp(this._0xe0666d64._0x2d5afef4, 0, Mathf.Max(0, this._table == null ? 0 : this._table._0x86b3dc30 - 1));
        this._0x9b4a2554 = this._table == null ? 12 : this._table._0x596276ec(this._0xf6c0c56f);
        this._0x0bbfed71 = 0;
        this._0x7169fca1 = this._lives;
        this._0x97843810 = 0f;
        this._0x7e04663d = StateIntro;
        float _0x67106f30 = this._spawnY - this._trayY;
        _0xc961abc1 _0x4a7285a1 = new _0xc961abc1(this._spawner != null ? this._spawner._0x79b7b573 : new float[] { 0f }, _0x67106f30, this._trayLimitX, this._traySpeed, this._tray != null ? this._tray._0xbf819f0f : 0.6462f);
        this._0xf8f5d8aa = _0x4a7285a1._0x733c5d60(this._0xf6c0c56f, this._0xe0666d64._0xa00e5485(), this._0x9b4a2554, this._table == null ? 2.6f : this._table._0x14b049f7(this._0xf6c0c56f), this._table == null ? 1.95f : this._table._0xf19c3530(this._0xf6c0c56f), this._table == null ? 12f : this._table._0xc2abad76(this._0xf6c0c56f), this._table == null ? 16f : this._table._0x3f394375(this._0xf6c0c56f), 110f);
        if (this._spawner != null)
        {
            this._spawner._0x15b59ea4(this._0xf8f5d8aa);
        }

        if (this._tray != null)
        {
            this._tray._0x37954232(this._0xf8f5d8aa.StartX, this._0xf8f5d8aa.StartSection);
            this._tray._0x169130cb(false);
        }

        if (this._favor != null)
        {
            this._favor._0x7705f3e4();
        }

        if (this._hud != null)
        {
            this._hud._0x38634cb7(this._0xf6c0c56f + 1, this._table == null ? string.Empty : this._table._0xe2dcb2f2(this._0xf6c0c56f));
            this._hud._0x520fe43e(0, this._0x9b4a2554);
            this._hud._0x477c664e(this._0x7169fca1);
        }
    }
}

internal static class _0xdef9419a
{
    internal static string _0x0c28a4f2(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
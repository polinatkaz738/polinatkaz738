using UnityEngine;

/// <summary>
/// The ceremonial tray: it follows the finger along x and cycles which cushion is
/// "receiving" on a tap. Every distance here comes from the camera (C.0): the caller
/// passes limits computed from orthographicSize, nothing is a hand-picked constant.
///
/// The active cushion is marked THREE ways at once - crown above it, a larger
/// cushion, and full opacity against dimmed neighbours - so the state reads at a
/// glance on a three-second preview.
/// </summary>
public sealed class _0x6965f42d : MonoBehaviour
{
    [SerializeField]
    private Transform _tray;
    public float _0xbf819f0f
    {
        get
        {
            return this._padWidth;
        }
    }

    private void Awake()
    {
        this._0x8170ebbf = new float[this._pads == null ? 0 : this._pads.Length];
        for (int _0x918ce7d4 = 0; _0x918ce7d4 < this._0x8170ebbf.Length; _0x918ce7d4++)
        {
            if (this._pads[_0x918ce7d4] != null)
            {
                this._0x8170ebbf[_0x918ce7d4] = this._pads[_0x918ce7d4].transform.localPosition.y;
            }
        }
    }

    private void Update()
    {
        if (this._0x2bd97938 > 0f)
        {
            this._0x2bd97938 -= Time.deltaTime;
            if (this._trayBase != null)
            {
                this._trayBase.color = this._0x2bd97938 > 0f ? _0xd2ac8035.Coral : Color.white;
            }
        }

        if (!this._0x661c014a)
        {
            return;
        }

        if (this._touch != null)
        {
            if (this._touch._0xcb0a32cf)
            {
                this._0xd47f290e = Mathf.Clamp(this._touch._0xeff85b2c(), -this._limitX, this._limitX);
            }

            if (this._touch._0xb7d9e384)
            {
                this._0x3a3ea224 = (this._0x3a3ea224 + 1) % 3;
                this._0xbdbd4ab9();
            }
        }

        if (this._tray != null)
        {
            Vector3 _0x7bf582b0 = this._tray.localPosition;
            _0x7bf582b0.x = Mathf.MoveTowards(_0x7bf582b0.x, this._0xd47f290e, this._speed * Time.deltaTime);
            this._tray.localPosition = _0x7bf582b0;
        }
    }

    /// <summary>A coral pulse on the tray frame when a fruit lands on the wrong cushion.</summary>
    public void _0x1a223a89()
    {
        this._0x2bd97938 = 0.25f;
    }

    [SerializeField]
    private float _limitX = 1.3385f;
    private float[] _0x8170ebbf;
    public int _0x2127ec75
    {
        get
        {
            return this._0x3a3ea224;
        }
    }

    [SerializeField]
    private SpriteRenderer[] _pads;
    [SerializeField]
    private float _padWidth = 0.6462f;
    [SerializeField]
    private float _activeScale = 1.1f;
    private void _0xbdbd4ab9()
    {
        if (this._pads == null)
        {
            return;
        }

        for (int _0x8bc33d81 = 0; _0x8bc33d81 < this._pads.Length; _0x8bc33d81++)
        {
            SpriteRenderer _0x6659b85d = this._pads[_0x8bc33d81];
            if (_0x6659b85d == null)
            {
                continue;
            }

            bool _0x58c58756 = _0x8bc33d81 == this._0x3a3ea224;
            float _0x57211e70 = _0x58c58756 ? this._padWidth * this._activeScale : this._padWidth;
            _0x6659b85d.size = new Vector2(_0x57211e70, _0x57211e70);
            _0x6659b85d.color = _0x58c58756 ? Color.white : new Color(1f, 1f, 1f, 0.55f);
            Vector3 _0x83327df2 = _0x6659b85d.transform.localPosition;
            _0x83327df2.y = (this._0x8170ebbf != null && _0x8bc33d81 < this._0x8170ebbf.Length ? this._0x8170ebbf[_0x8bc33d81] : 0f) + (_0x58c58756 ? this._activeLift : 0f);
            _0x6659b85d.transform.localPosition = _0x83327df2;
            if (_0x58c58756 && this._crownMarker != null)
            {
                Vector3 _0xe88c7cde = this._crownMarker.localPosition;
                _0xe88c7cde.x = _0x6659b85d.transform.localPosition.x;
                this._crownMarker.localPosition = _0xe88c7cde;
            }
        }
    }

    private float _0x2bd97938;
    [SerializeField]
    private Transform _crownMarker;
    private int _0x3a3ea224;
    /// <summary>Which cushion sits under this world x, or -1 for a clean miss.</summary>
    public int _0xb2308299(float _0xc1421784)
    {
        float _0xaddc940d = _0xc1421784 - this._0x53dd520a;
        float _0xd3897e23 = this._padWidth * 1.5f;
        if (_0xaddc940d < -_0xd3897e23 || _0xaddc940d > _0xd3897e23)
        {
            return -1;
        }

        int _0xf7e46312 = Mathf.FloorToInt((_0xaddc940d + _0xd3897e23) / this._padWidth);
        return Mathf.Clamp(_0xf7e46312, 0, 2);
    }

    private float _0xd47f290e;
    private bool _0x661c014a;
    public void _0x37954232(float _0x6a8dcf90, int _0xb0959d2f)
    {
        this._0xd47f290e = Mathf.Clamp(_0x6a8dcf90, -this._limitX, this._limitX);
        this._0x3a3ea224 = Mathf.Clamp(_0xb0959d2f, 0, 2);
        if (this._tray != null)
        {
            Vector3 _0x755f9c5b = this._tray.localPosition;
            _0x755f9c5b.x = this._0xd47f290e;
            this._tray.localPosition = _0x755f9c5b;
        }

        this._0xbdbd4ab9();
    }

    public float _0x53dd520a
    {
        get
        {
            return this._tray == null ? 0f : this._tray.localPosition.x;
        }
    }

    private void Start()
    {
        this._0xbdbd4ab9();
    }

    [SerializeField]
    private _0xf8dceeb1 _touch;
    /// <summary>Called by the director so the tray only answers taps during play.</summary>
    public void _0x169130cb(bool _0x994f38f0)
    {
        this._0x661c014a = _0x994f38f0;
    }

    [SerializeField]
    private float _speed = 5.2f;
    [SerializeField]
    private float _activeLift = 0.08f;
    [SerializeField]
    private SpriteRenderer _trayBase;
}
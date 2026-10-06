using UnityEngine;

/// <summary>
/// One falling piece of the harvest. The prefab already carries a Sliced
/// SpriteRenderer with its size and sorting order baked in (C.0 / F.2), so a spawned
/// fruit is the right size on the frame it appears - nothing is repaired at runtime.
/// </summary>
public sealed class _0xa6e317c1 : MonoBehaviour
{
    public void _0x157bc513()
    {
        this._0xc171b57b = true;
    }

    private float _0x0eafa4d8;
    private bool _0xca99d458;
    public void _0x501b06f4(Sprite _0xee69b718, int _0x08ad8e10, bool _0x3c449a6b, float _0xca461741, float _0x2c8216fe, Vector3 _0xffc26821, float _0x8a2dc45e)
    {
        this._0x470cf02f = _0x08ad8e10;
        this._0xca99d458 = _0x3c449a6b;
        this._0x0eafa4d8 = _0xca461741;
        this._0xaf690262 = _0x8a2dc45e;
        this._0xc171b57b = false;
        this.transform.localPosition = _0xffc26821;
        if (this._renderer != null)
        {
            this._renderer.sprite = _0xee69b718;
            this._renderer.size = new Vector2(_0x2c8216fe, _0x2c8216fe);
        }
    }

    public bool _0x36667e03
    {
        get
        {
            return this._0xca99d458;
        }
    }

    public float _0x2e3915b8
    {
        get
        {
            return this.transform.localPosition.x;
        }
    }

    private bool _0xc171b57b;
    public bool _0x7b9bebc6
    {
        get
        {
            return this._0xc171b57b;
        }
    }

    public float _0x758e23f0
    {
        get
        {
            return this.transform.localPosition.y;
        }
    }

    [SerializeField]
    private SpriteRenderer _renderer;
    public int _0x40750151
    {
        get
        {
            return this._0x470cf02f;
        }
    }

    private void Update()
    {
        if (this._0xc171b57b)
        {
            return;
        }

        Vector3 _0xe356f997 = this.transform.localPosition;
        _0xe356f997.y -= this._0x0eafa4d8 * Time.deltaTime;
        this.transform.localPosition = _0xe356f997;
        float _0x70f37edd = Mathf.Sin((Time.time * 5.7f) + this._0xaf690262) * 7f;
        this.transform.localRotation = Quaternion.Euler(0f, 0f, _0x70f37edd);
    }

    private float _0xaf690262;
    private int _0x470cf02f;
}
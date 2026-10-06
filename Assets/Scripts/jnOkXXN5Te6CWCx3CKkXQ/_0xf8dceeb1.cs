using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/// <summary>
/// One frame of pointer state, read through the NEW input system only.
///
/// The template's InputController would normally serve this, but in this tarball its
/// singleton and every accessor are private, so nothing outside it can call them -
/// the EnhancedTouch API it wraps is read here directly instead. Legacy
/// UnityEngine.Input is never touched (CLAUDE-unity.md C).
/// </summary>
public sealed class _0xf8dceeb1 : MonoBehaviour
{
    public Vector2 _0xa0c5a863
    {
        get
        {
            return this._0x8e46314f;
        }
    }

    [SerializeField]
    private Camera _camera;
    /// <summary>True while a finger (or the editor mouse) is on the screen.</summary>
    public bool _0xcb0a32cf
    {
        get
        {
            return this._0xab8ffbee;
        }
    }

    private void Update()
    {
        this._0xe52107fc = false;
        bool _0xaa79e24e = false;
        Vector2 _0x8ffe1c39 = this._0x8e46314f;
        if (ETouch.activeTouches.Count > 0)
        {
            for (int _0xb65c68d8 = 0; _0xb65c68d8 < ETouch.activeTouches.Count; _0xb65c68d8++)
            {
                ETouch _0xc2c953f7 = ETouch.activeTouches[_0xb65c68d8];
                if (!_0xc2c953f7.ended)
                {
                    _0xaa79e24e = true;
                    _0x8ffe1c39 = _0xc2c953f7.screenPosition;
                    break;
                }
            }

            if (!_0xaa79e24e)
            {
                _0x8ffe1c39 = ETouch.activeTouches[0].screenPosition;
            }
        }
        else
        {
            Mouse _0xfd9541d9 = Mouse.current;
            if (_0xfd9541d9 != null)
            {
                _0xaa79e24e = _0xfd9541d9.leftButton.isPressed;
                _0x8ffe1c39 = _0xfd9541d9.position.ReadValue();
            }
        }

        this._0x8e46314f = _0x8ffe1c39;
        if (_0xaa79e24e && !this._0xab8ffbee)
        {
            this._0xab8ffbee = true;
            this._0x2c0d363e = false;
            this._0xa3834f6b = _0x8ffe1c39;
        }
        else if (_0xaa79e24e)
        {
            if ((_0x8ffe1c39 - this._0xa3834f6b).sqrMagnitude > this._tapSlackPixels * this._tapSlackPixels)
            {
                this._0x2c0d363e = true;
            }
        }
        else if (this._0xab8ffbee)
        {
            this._0xab8ffbee = false;
            this._0xe52107fc = !this._0x2c0d363e;
        }
    }

    /// <summary>True on the single frame a press ended without travelling far.</summary>
    public bool _0xb7d9e384
    {
        get
        {
            return this._0xe52107fc;
        }
    }

    private Vector2 _0x8e46314f;
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    [SerializeField]
    private float _tapSlackPixels = 28f;
    private void OnDestroy()
    {
        EnhancedTouchSupport.Disable();
    }

    private bool _0xab8ffbee;
    private Vector2 _0xa3834f6b;
    /// <summary>The pointer projected onto the gameplay plane, in world units.</summary>
    public float _0xeff85b2c()
    {
        if (this._camera == null)
        {
            return 0f;
        }

        Vector3 _0xdfa1195b = this._camera.ScreenToWorldPoint(new Vector3(this._0x8e46314f.x, this._0x8e46314f.y, 10f));
        return _0xdfa1195b.x;
    }

    private bool _0x2c0d363e;
    private bool _0xe52107fc;
}
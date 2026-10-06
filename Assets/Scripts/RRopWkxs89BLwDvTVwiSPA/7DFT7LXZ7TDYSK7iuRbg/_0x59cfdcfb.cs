using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class _0x59cfdcfb : MonoBehaviour
{
    private Touch? _0x67c09c6c()
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
            return null;
        foreach (Touch _0x03775222 in Touch.activeTouches)
            if (!_0x03775222.ended)
                if (this._0xb070495e(_0x03775222))
                    return _0x03775222;
        return null;
    }

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        _0xb91abaa4 = this.gameObject.GetComponent<_0x59cfdcfb>();
    }

    public BoxCollider2D CameraTouchBounds;
    private static _0x59cfdcfb _0xb91abaa4;
    private Touch? _0x6628284b()
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
            return null;
        foreach (Touch _0x3e5bc3a9 in Touch.activeTouches)
            if (_0x3e5bc3a9.ended)
                if (this._0xb070495e(_0x3e5bc3a9))
                    return _0x3e5bc3a9;
        return null;
    }

    private Touch? _0xf7463e86(Bounds _0xcf63a2be, TouchPhase _0x13313138)
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
            return null;
        foreach (Touch _0xcb7515a6 in Touch.activeTouches)
            if (_0xcb7515a6.phase == _0x13313138)
            {
                Vector3 _0x37177593 = Camera.main.ScreenToWorldPoint(_0xcb7515a6.screenPosition);
                Vector3 _0x755ebbaa = new(_0x37177593.x, _0x37177593.y, _0xcf63a2be.center.z);
                if (_0xcf63a2be.Contains(_0x755ebbaa) && this._0xb070495e(_0xcb7515a6))
                    return _0xcb7515a6;
            }

        return null;
    }

    private bool _0xb070495e(Touch? _0x5af2ccff)
    {
        if (!_0x5af2ccff.HasValue)
            return false;
        Vector3 _0xa3716e8e = Camera.main.ScreenToWorldPoint(_0x5af2ccff.Value.screenPosition);
        Vector3 _0x6a8e6b0e = _0xa3716e8e;
        _0x6a8e6b0e.z = this.CameraTouchBounds.transform.position.z;
        if (this.CameraTouchBounds.bounds.Contains(_0x6a8e6b0e))
            return true;
        _0x5af2ccff = null;
        return false;
    }

    private void _0xb58bb9ac(Touch? _0x611d7bbe)
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
        {
            _0x611d7bbe = null;
            return;
        }

        int _0x7ac82797 = _0x611d7bbe.Value.touchId;
        _0x611d7bbe = Touch.activeTouches.FirstOrDefault(_0xe8e8623b => _0xe8e8623b.touchId == _0x7ac82797);
        if (!this._0xb070495e(_0x611d7bbe.Value))
            _0x611d7bbe = null;
    }

    private Touch? _0x142bc2e4(Bounds _0x0d8ba796)
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
            return null;
        foreach (Touch _0xb78aa2b8 in Touch.activeTouches)
            if (!_0xb78aa2b8.ended)
            {
                Vector3 _0x91032fd5 = Camera.main.ScreenToWorldPoint(_0xb78aa2b8.screenPosition);
                Vector3 _0xeb505d3b = new(_0x91032fd5.x, _0x91032fd5.y, _0x0d8ba796.center.z);
                if (_0x0d8ba796.Contains(_0xeb505d3b) && this._0xb070495e(_0xb78aa2b8))
                    return _0xb78aa2b8;
            }

        return null;
    }

    private Touch? _0xb132a307(Bounds _0xd6310ef0)
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
            return null;
        foreach (Touch _0xdaacadf6 in Touch.activeTouches)
            if (_0xdaacadf6.ended)
            {
                Vector3 _0x4938507b = Camera.main.ScreenToWorldPoint(_0xdaacadf6.screenPosition);
                Vector3 _0xb649c269 = new(_0x4938507b.x, _0x4938507b.y, _0xd6310ef0.center.z);
                if (_0xd6310ef0.Contains(_0xb649c269) && this._0xb070495e(_0xdaacadf6))
                    return _0xdaacadf6;
            }

        return null;
    }

    private bool _0x681115be(Touch? _0x687f4699, Bounds _0x24c4b3ca, TouchPhase _0xac79c3b7)
    {
        if (!_0x9d5294e1.Instance._0xc6e1c633)
        {
            _0x687f4699 = null;
            return false;
        }

        if (_0x687f4699 != null)
            if (_0x687f4699.Value.phase == _0xac79c3b7)
            {
                Vector3 _0xe6eba41e = Camera.main.ScreenToWorldPoint(_0x687f4699.Value.screenPosition);
                Vector3 _0x0c7418b1 = new(_0xe6eba41e.x, _0xe6eba41e.y, _0x24c4b3ca.center.z);
                if (_0x24c4b3ca.Contains(_0x0c7418b1) && this._0xb070495e(_0x687f4699.Value))
                    return true;
            }

        return false;
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class _0x03af14a4 : MonoBehaviour
{
    private static bool _0x8f7ccc85;
    private void OnDestroy()
    {
        if (_0xa15223cf != null && _0xa15223cf.Contains(this))
            _0xa15223cf.Remove(this);
    }

    private Canvas _0x4dc9be18;
    private static Vector2 _0x9361b883 = Vector2.zero;
    private void Update()
    {
        if (_0xa15223cf[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0xe4746cea)
            OrientationChanged();
        if (Screen.safeArea != _0x1cb50c2c)
            SafeAreaChanged();
        if (Screen.width != _0x9361b883.x || Screen.height != _0x9361b883.y)
            ResolutionChanged();
    }

    private static void SafeAreaChanged()
    {
        _0x1cb50c2c = Screen.safeArea;
        for (int _0x0868f8da = 0; _0x0868f8da < _0xa15223cf.Count; _0x0868f8da++)
            _0xa15223cf[_0x0868f8da]._0x3da39cfd();
    }

    private void _0x3da39cfd()
    {
        if (this._0x26803ec9 == null)
            return;
        Rect _0xb4eeb08c = Screen.safeArea;
        Vector2 _0x03577af5 = _0xb4eeb08c.position;
        Vector2 _0x6b51202f = _0xb4eeb08c.position + _0xb4eeb08c.size;
        _0x03577af5.x /= this._0x4dc9be18.pixelRect.width;
        _0x03577af5.y /= this._0x4dc9be18.pixelRect.height;
        _0x6b51202f.x /= this._0x4dc9be18.pixelRect.width;
        _0x6b51202f.y /= this._0x4dc9be18.pixelRect.height;
        this._0x26803ec9.anchorMin = _0x03577af5;
        this._0x26803ec9.anchorMax = _0x6b51202f;
    }

    private RectTransform _0x26803ec9;
    private void Awake()
    {
        if (!_0xa15223cf.Contains(this))
            _0xa15223cf.Add(this);
        this._0x4dc9be18 = this.GetComponent<Canvas>();
        this._0x29f86136 = this.GetComponent<RectTransform>();
        this._0x26803ec9 = this.transform.Find(_0xce2d84b0._0x1cbe14ea(new byte[8] { 188, 142, 137, 138, 174, 157, 138, 142 }, 239)) as RectTransform;
        if (!_0x8f7ccc85)
        {
            _0xe4746cea = Screen.orientation;
            _0x9361b883.x = Screen.width;
            _0x9361b883.y = Screen.height;
            _0x1cb50c2c = Screen.safeArea;
            _0x8f7ccc85 = true;
        }

        this._0x3da39cfd();
    }

    private static Rect _0x1cb50c2c = Rect.zero;
    private static UnityEvent _0x8567af5d = new();
    private static void OrientationChanged()
    {
        _0xe4746cea = Screen.orientation;
        _0x9361b883.x = Screen.width;
        _0x9361b883.y = Screen.height;
        _0x8567af5d.Invoke();
    }

    private static readonly List<_0x03af14a4> _0xa15223cf = new();
    private static ScreenOrientation _0xe4746cea = ScreenOrientation.LandscapeLeft;
    private static void ResolutionChanged()
    {
        _0x9361b883.x = Screen.width;
        _0x9361b883.y = Screen.height;
        _0x8567af5d.Invoke();
    }

    private RectTransform _0x29f86136;
}

internal static class _0xce2d84b0
{
    internal static string _0x1cbe14ea(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
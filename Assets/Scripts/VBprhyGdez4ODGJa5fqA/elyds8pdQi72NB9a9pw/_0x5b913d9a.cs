using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class _0x5b913d9a : MonoBehaviour
{
    private Vector2 _0x384c78cb;
    private void Awake()
    {
        if (!_0xbc27217f.Contains(this))
            _0xbc27217f.Add(this);
        this._0x8bd5d901 = this.GetComponent<Canvas>();
        this._0x0405967a = this.GetComponent<CanvasScaler>();
        if (this._0x0405967a != null)
            this._0x384c78cb = this._0x0405967a.referenceResolution;
        this._0xb4f75ae5 = this.GetComponent<RectTransform>();
        this._0xa43fe631 = this.transform.Find(_0xfa1ce96b._0x0619126f(new byte[8] { 208, 226, 229, 230, 194, 241, 230, 226 }, 131)) as RectTransform;
        if (!_0xb4a1ae86)
        {
            _0x1d49aefb = Screen.orientation;
            _0x3fe3db30.x = Screen.width;
            _0x3fe3db30.y = Screen.height;
            _0xc89c397a = Screen.safeArea;
            _0xb4a1ae86 = true;
        }

        this._0x48979c63();
    }

    private static void ResolutionChanged()
    {
        _0x3fe3db30.x = Screen.width;
        _0x3fe3db30.y = Screen.height;
        _0xc89c397a = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x3e6b0b6d.Invoke();
    }

    private static void SafeAreaChanged()
    {
        _0xc89c397a = Screen.safeArea;
        ApplySafeAreaToAll();
    }

    private static UnityEvent _0x3e6b0b6d = new();
    private CanvasScaler _0x0405967a;
    private void Update()
    {
        if (_0xbc27217f.Count == 0 || _0xbc27217f[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x1d49aefb)
            OrientationChanged();
        if (Screen.safeArea != _0xc89c397a)
            SafeAreaChanged();
        if (Screen.width != _0x3fe3db30.x || Screen.height != _0x3fe3db30.y)
            ResolutionChanged();
    }

    private RectTransform _0xa43fe631;
    private static void OrientationChanged()
    {
        _0x1d49aefb = Screen.orientation;
        _0x3fe3db30.x = Screen.width;
        _0x3fe3db30.y = Screen.height;
        _0xc89c397a = Screen.safeArea;
        ApplySafeAreaToAll();
        _0x3e6b0b6d.Invoke();
    }

    private RectTransform _0xb4f75ae5;
    private static Rect _0xc89c397a = Rect.zero;
    private static ScreenOrientation _0x1d49aefb = ScreenOrientation.LandscapeLeft;
    private static readonly List<_0x5b913d9a> _0xbc27217f = new();
    private void Start()
    {
    }

    private static void ApplySafeAreaToAll()
    {
        for (int _0x24a1a708 = 0; _0x24a1a708 < _0xbc27217f.Count; _0x24a1a708++)
            _0xbc27217f[_0x24a1a708]._0x48979c63();
    }

    private void _0x48979c63()
    {
        if (this._0xa43fe631 == null)
            return;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        if (screenWidth <= 0f || screenHeight <= 0f)
            return;
        Rect _0xf5c5a8b1 = Screen.safeArea;
        Vector2 _0xc574150e = _0xf5c5a8b1.position;
        Vector2 _0xbc99b048 = _0xf5c5a8b1.position + _0xf5c5a8b1.size;
        _0xc574150e.x /= screenWidth;
        _0xc574150e.y /= screenHeight;
        _0xbc99b048.x /= screenWidth;
        _0xbc99b048.y /= screenHeight;
        this._0xa43fe631.anchorMin = _0xc574150e;
        this._0xa43fe631.anchorMax = _0xbc99b048;
        this._0xa43fe631.offsetMin = Vector2.zero;
        this._0xa43fe631.offsetMax = Vector2.zero;
        if (this._0x0405967a == null)
            return;
        Vector2 _0xfff406f4 = _0xbc99b048 - _0xc574150e;
        float _0xa12daa3a = 2f - _0xfff406f4.x;
        float _0xef559ae0 = 2f - _0xfff406f4.y;
        this._0x0405967a.referenceResolution = this._0x384c78cb * new Vector2(_0xa12daa3a, _0xef559ae0);
    }

    private static Vector2 _0x3fe3db30 = Vector2.zero;
    private void OnDestroy()
    {
        if (_0xbc27217f != null && _0xbc27217f.Contains(this))
            _0xbc27217f.Remove(this);
    }

    private static bool _0xb4a1ae86;
    private Canvas _0x8bd5d901;
}

internal static class _0xfa1ce96b
{
    internal static string _0x0619126f(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
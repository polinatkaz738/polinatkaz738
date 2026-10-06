using AndroidInstallReferrer;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Notifications.Android;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.CloudSave.Models.Data.Player;
using Unity.Services.Core;
using Unity.Services.PushNotifications;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class _0x163f5a1a : MonoBehaviour
{
    private void _0x380eb801(string _0xc8ba2355)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[34] { 100, 107, 90, 76, 75, 98, 31, 121, 90, 75, 92, 87, 31, 122, 71, 75, 77, 94, 31, 111, 74, 76, 87, 31, 123, 94, 75, 94, 31, 109, 94, 72, 5, 31 }, 63) + _0xc8ba2355);
#endif
            }
        }

        var _0x4c3b00be = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xc8ba2355);
        StartCoroutine(_0xdd18fea2(_0x4c3b00be));
    }

    private string _0xac771e6f { get; set; }

    private string GetFailingUrl(UniWebViewNativeResultPayload _0xcee3761b)
    {
        if (_0xcee3761b == null || _0xcee3761b.Extra == null)
            return null;
        object _0x2a3e7d61;
        if (!_0xcee3761b.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out _0x2a3e7d61))
            return null;
        return _0x2a3e7d61 as string;
    }

    private bool OpenUrlExternally(string _0xe546d759)
    {
        return _0xfa20af44(_0xe546d759);
    }

    internal Vector2 lastSize = Vector2.zero;
    private string _0x6cf8290e = "";
    private IEnumerator _0xa9f90edd(string _0x6e2e57f6)
    {
        if (_0x93930a98 != null && _0x936330f6)
            yield break;
        _0x93930a98 = gameObject.AddComponent<UniWebView>();
        _0xd2e34a56(_0x93930a98);
        _0x5d946420(_0x93930a98);
        _0x93930a98.BackgroundColor = Color.clear;
        var _0x0e4949ad = SceneManager.GetActiveScene().GetRootGameObjects();
        if (Camera.main != null)
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            Camera.main.backgroundColor = Color.clear;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
        _0xcb7bdc1c();
        yield return new WaitForEndOfFrame();
        _0x936330f6 = true;
        _0xcb582acb();
        _0xecb8ecc4(true);
        _0xcb861229 = false;
        _0x999cc648 = false;
        _0x9f92c081.Clear();
        _0x9df46722 = -1;
        firstLoadShown = false;
        _0xddd8c26c = false;
        _0x1b71bca0 = false;
        _0x93930a98.SetUserAgent("");
        _0x0167ec95 = Time.realtimeSinceStartup;
        _0x93930a98.Stop();
        _0x93930a98.Load(_0x6e2e57f6);
        _0x93930a98.Show(false, UniWebViewTransitionEdge.None, 0f, null);
        WLog(_0xc4b9e23f._0x50c41416(new byte[25] { 100, 72, 64, 71, 9, 126, 76, 75, 127, 64, 76, 94, 9, 96, 71, 64, 93, 64, 72, 69, 9, 122, 65, 70, 94 }, 41));
    }

    private Canvas _0xc2f29852()
    {
        if (_0x9d602273 != null)
            return _0x9d602273;
        var _0xc39e9899 = gameObject.GetComponentInChildren<Canvas>();
        if (_0xc39e9899 == null)
        {
            var _0xc6a26cad = new GameObject(_0xc4b9e23f._0x50c41416(new byte[6] { 253, 223, 208, 200, 223, 205 }, 190), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            _0xc39e9899 = _0xc6a26cad.GetComponent<Canvas>();
            _0xc39e9899.transform.SetParent(transform, false);
            _0xc39e9899.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        _0x9d602273 = _0xc39e9899;
        return _0x9d602273;
    }

    private void _0xfec2e4cf(string _0x393be0e0)
    {
        if (string.IsNullOrEmpty(_0x393be0e0))
            return;
        if (TryOpenExternalLikeChrome(_0x393be0e0))
            return;
        OpenUrlExternally(_0x393be0e0);
    }

    private Canvas _0x9d602273;
    private bool _0x17b20cca = false;
    private string _0x2e75047a { get; set; }

    private async Task _0x54bf2974(string _0x53d11e3e)
    {
        if (_0x17b20cca || string.IsNullOrEmpty(_0xba5b794d) || string.IsNullOrEmpty(_0x53d11e3e) || _0x5da73ea8)
            return;
        _0x17b20cca = true;
        try
        {
            JObject _0x08f9ceac = BuildRandomPayload(_0x53d11e3e, _0xba5b794d, _0xc2423bf4());
            {
#if B_LOGS
                {
                    Debug.Log($"[Test][Load Pass] Send total: {_0x53d11e3e} payload: {_0x08f9ceac}");
                }
#endif
            }

            var _0xcba0292e = _0x39c081c6(_0x08f9ceac.ToString(), _0xba5b794d);
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0xc4b9e23f._0x50c41416(new byte[4] { 230, 229, 235, 238 }, 138) + _0xba5b794d, _0xcba0292e } });
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[24] { 156, 147, 130, 148, 147, 154, 231, 139, 168, 166, 163, 231, 183, 166, 180, 180, 231, 162, 181, 181, 168, 181, 253, 231 }, 199) + e.Message);
#endif
            }
        }
    }

    private Action _0x76a5daea;
    private bool _0xddd8c26c = false;
    internal void Update()
    {
        if (_0x93930a98 == null)
            return;
        if (_0xbad163cc())
            _0x445b0684();
        if (!isApplicationFocus || isApplicationPause)
            return;
        _0xcb7bdc1c();
        if (_0xbd41ac94 && _0x807abed0 != null)
            _0x807abed0.Rotate(0f, 0f, -360f * Time.deltaTime);
    }

    private bool _0x8beead78()
    {
        _0x9f92c081.RemoveAll(_0x696dceb8 => _0x696dceb8 == null || !_0x696dceb8.IsAlive);
        return _0x9f92c081.Count > 0;
    }

    private void Awake()
    {
        if (_0x76d4b68d != null)
        {
            Destroy(this.gameObject);
            return;
        }

        EnhancedTouchSupport.Enable();
        Input.backButtonLeavesApp = false;
        {
#if !B_LOGS
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
#endif
        }

        _0x76d4b68d = gameObject.GetComponent<_0x163f5a1a>();
        DontDestroyOnLoad(gameObject);
        _0xeb87ca69 = _0xac771e6f = _0x2e75047a = "";
        _0x6cf8290e = "";
        _0x936330f6 = false;
    }

    private bool _0xbe979cbe()
    {
        if (_0x3e91aed1())
            return true;
        if (_0x93930a98 != null && _0x93930a98.CanGoBack)
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[36] { 7, 46, 61, 43, 56, 46, 61, 42, 111, 45, 46, 44, 36, 111, 98, 113, 111, 34, 46, 38, 33, 111, 24, 42, 45, 25, 38, 42, 56, 111, 8, 32, 13, 46, 44, 36 }, 79));
            _0x93930a98.GoBack();
            return true;
        }

        return false;
    }

    private readonly List<UniWebViewPopup> _0x9f92c081 = new List<UniWebViewPopup>();
    private bool _0x70ff3473(int _0x144385d2, string _0xa8a7cf8c, string _0x6ca34812)
    {
        if (string.IsNullOrEmpty(_0x6ca34812))
            return false;
        if (!IsHttpUrl(_0x6ca34812))
            return true;
        if (string.IsNullOrEmpty(_0xa8a7cf8c))
            return false;
        return _0xa8a7cf8c.IndexOf(_0xc4b9e23f._0x50c41416(new byte[20] { 83, 68, 68, 73, 85, 89, 88, 88, 83, 85, 66, 95, 89, 88, 73, 68, 83, 69, 83, 66 }, 22), StringComparison.OrdinalIgnoreCase) >= 0 || _0xa8a7cf8c.IndexOf(_0xc4b9e23f._0x50c41416(new byte[22] { 176, 167, 167, 170, 182, 186, 187, 187, 176, 182, 161, 188, 186, 187, 170, 167, 176, 179, 160, 166, 176, 177 }, 245), StringComparison.OrdinalIgnoreCase) >= 0 || _0xa8a7cf8c.IndexOf(_0xc4b9e23f._0x50c41416(new byte[21] { 208, 199, 199, 202, 214, 218, 219, 219, 208, 214, 193, 220, 218, 219, 202, 214, 217, 218, 198, 208, 209 }, 149), StringComparison.OrdinalIgnoreCase) >= 0 || _0xa8a7cf8c.IndexOf(_0xc4b9e23f._0x50c41416(new byte[22] { 129, 150, 150, 155, 145, 138, 143, 138, 139, 147, 138, 155, 145, 150, 136, 155, 151, 135, 140, 129, 137, 129 }, 196), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    internal Rect lastSafe = Rect.zero;
    private string _0x5a2af73a = "";
    private string _0xcbda13db = "";
    internal Button _0xc7bc1fdc(string _0x13e24d04, Transform _0x8d509d82)
    {
        var _0x5e8bc667 = new GameObject(_0x13e24d04 + _0xc4b9e23f._0x50c41416(new byte[3] { 167, 145, 139 }, 229), typeof(RectTransform), typeof(Image), typeof(Button));
        var _0xfe901a97 = _0x5e8bc667.GetComponent<RectTransform>();
        _0xfe901a97.SetParent(_0x8d509d82, false);
        var _0x880394a2 = _0x5e8bc667.GetComponent<Image>();
        _0x880394a2.color = new Color(0.92f, 0.92f, 0.95f, 1f);
        var _0x2e490f88 = _0x5e8bc667.GetComponent<Button>();
        var _0x921d0c95 = _0x2e490f88.colors;
        _0x921d0c95.highlightedColor = new Color(0.85f, 0.85f, 0.9f);
        _0x921d0c95.pressedColor = new Color(0.8f, 0.8f, 0.88f);
        _0x2e490f88.colors = _0x921d0c95;
        var _0x60e1fac8 = new GameObject(_0xc4b9e23f._0x50c41416(new byte[4] { 248, 201, 212, 216 }, 172), typeof(RectTransform), typeof(Text));
        var _0xd71a7d2b = _0x60e1fac8.GetComponent<RectTransform>();
        _0xd71a7d2b.SetParent(_0x5e8bc667.transform, false);
        _0xd71a7d2b.anchorMin = Vector2.zero;
        _0xd71a7d2b.anchorMax = Vector2.one;
        _0xd71a7d2b.offsetMin = _0xd71a7d2b.offsetMax = Vector2.zero;
        var _0xef39b709 = _0x60e1fac8.GetComponent<Text>();
        _0xef39b709.text = _0x13e24d04;
        _0xef39b709.alignment = TextAnchor.MiddleCenter;
        _0xef39b709.color = Color.black;
        _0xef39b709.font = Resources.GetBuiltinResource<Font>(_0xc4b9e23f._0x50c41416(new byte[9] { 36, 23, 12, 4, 9, 75, 17, 17, 3 }, 101));
        _0xef39b709.fontSize = 28;
        WLog(_0xc4b9e23f._0x50c41416(new byte[14] { 154, 171, 188, 184, 173, 188, 155, 172, 173, 173, 182, 183, 249, 254 }, 217) + _0x13e24d04 + _0xc4b9e23f._0x50c41416(new byte[1] { 106 }, 77));
        return _0x2e490f88;
    }

    // WEB VIEW LOGIC END
    internal void _0x3cc1f3fe()
    {
        // Ensure channel exists (safe to call multiple times)
        var _0xeeaa692e = new AndroidNotificationChannel
        {
            Id = _0xc4b9e23f._0x50c41416(new byte[15] { 214, 215, 212, 211, 199, 222, 198, 237, 209, 218, 211, 220, 220, 215, 222 }, 178),
            Name = _0xc4b9e23f._0x50c41416(new byte[15] { 42, 11, 8, 15, 27, 2, 26, 78, 45, 6, 15, 0, 0, 11, 2 }, 110),
            Importance = Importance.High,
            Description = _0xc4b9e23f._0x50c41416(new byte[21] { 29, 63, 52, 63, 40, 59, 54, 122, 52, 53, 46, 51, 60, 51, 57, 59, 46, 51, 53, 52, 41 }, 90)
        };
        AndroidNotificationCenter.RegisterNotificationChannel(_0xeeaa692e);
        // Build notification
        var _0x081d1575 = new AndroidNotification
        {
            Title = _0xaaa5f249[UnityEngine.Random.Range(0, _0xaaa5f249.Length)],
            Text = _0xc4b9e23f._0x50c41416(new byte[21] { 197, 246, 225, 164, 253, 235, 241, 164, 247, 241, 246, 225, 164, 240, 235, 164, 225, 252, 237, 240, 187 }, 132),
            FireTime = System.DateTime.Now
        };
        // Send immediately
        AndroidNotificationCenter.SendNotification(_0x081d1575, _0xc4b9e23f._0x50c41416(new byte[15] { 107, 106, 105, 110, 122, 99, 123, 80, 108, 103, 110, 97, 97, 106, 99 }, 15));
    }

    private string _0x7b976bc1 = "";
    internal bool _0x16be0954(string _0xcb9fc8bf)
    {
        return _0xcb9fc8bf.StartsWith(_0xc4b9e23f._0x50c41416(new byte[9] { 204, 192, 211, 202, 196, 213, 155, 142, 142 }, 161), StringComparison.OrdinalIgnoreCase) || _0xcb9fc8bf.StartsWith(_0xc4b9e23f._0x50c41416(new byte[24] { 166, 186, 186, 190, 189, 244, 225, 225, 190, 162, 175, 183, 224, 169, 161, 161, 169, 162, 171, 224, 173, 161, 163, 225 }, 206), StringComparison.OrdinalIgnoreCase) || _0xcb9fc8bf.StartsWith(_0xc4b9e23f._0x50c41416(new byte[23] { 38, 58, 58, 62, 116, 97, 97, 62, 34, 47, 55, 96, 41, 33, 33, 41, 34, 43, 96, 45, 33, 35, 97 }, 78), StringComparison.OrdinalIgnoreCase);
    }

    private JObject BuildRandomPayload(params string[] _0x4f3f4c98)
    {
        JObject _0x87f226ab = new JObject();
        foreach (var _0x399a4a8f in _0x4f3f4c98)
        {
            string _0x54ea07b5 = _0x07d4b7b7();
            {
#if B_LOGS
                Debug.Log($"[Test] Crypto key={_0x54ea07b5} val={_0x399a4a8f}");
#endif
            }

            _0x87f226ab.Add(_0x54ea07b5, _0x399a4a8f == null ? "" : _0x399a4a8f);
        }

        return _0x87f226ab;
    }

    private bool _0xfe48ce99(string _0x69b3979e, string _0xb9412b6f)
    {
        string _0xfbd91cb2 = _0xa58c5fc8(_0x69b3979e);
        if (string.IsNullOrEmpty(_0xfbd91cb2))
            _0xfbd91cb2 = _0xb9412b6f;
        if (_0x4880ade8(_0xfbd91cb2))
            return true;
        string _0x53da6203 = string.IsNullOrEmpty(_0xfbd91cb2) ? _0xc4b9e23f._0x50c41416(new byte[29] { 128, 156, 156, 152, 155, 210, 199, 199, 152, 132, 137, 145, 198, 143, 135, 135, 143, 132, 141, 198, 139, 135, 133, 199, 155, 156, 135, 154, 141 }, 232) : _0xc4b9e23f._0x50c41416(new byte[46] { 76, 80, 80, 84, 87, 30, 11, 11, 84, 72, 69, 93, 10, 67, 75, 75, 67, 72, 65, 10, 71, 75, 73, 11, 87, 80, 75, 86, 65, 11, 69, 84, 84, 87, 11, 64, 65, 80, 69, 77, 72, 87, 27, 77, 64, 25 }, 36) + _0xfbd91cb2;
        WLog(_0xc4b9e23f._0x50c41416(new byte[35] { 159, 180, 174, 179, 177, 185, 144, 181, 183, 185, 252, 177, 189, 174, 183, 185, 168, 252, 186, 189, 176, 176, 190, 189, 191, 183, 252, 189, 175, 252, 171, 185, 190, 230, 252 }, 220) + _0x53da6203);
        return _0xfa20af44(_0x53da6203);
    }

    private bool _0x008ac9a6 = false;
    private bool _0xbad163cc()
    {
        var _0xd0b4d90d = Keyboard.current;
        return _0xd0b4d90d != null && _0xd0b4d90d.escapeKey.wasPressedThisFrame;
    }

    private async Task<bool> _0xb6664e4f()
    {
        {
#if B_LOGS
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[37] { 111, 96, 81, 71, 64, 105, 20, 103, 93, 83, 90, 125, 90, 97, 90, 93, 64, 77, 103, 81, 70, 66, 93, 87, 81, 71, 117, 90, 91, 90, 77, 89, 91, 65, 71, 88, 77 }, 52));
#endif
        }

        try
        {
            var _0x5365f81b = new InitializationOptions();
            await UnityServices.InitializeAsync(_0x5365f81b);
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[32] { 76, 67, 114, 100, 99, 74, 55, 66, 121, 126, 99, 110, 68, 114, 101, 97, 126, 116, 114, 100, 55, 94, 121, 126, 99, 126, 118, 123, 126, 109, 114, 115 }, 23));
#endif
            }
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[20] { 117, 100, 114, 117, 1, 116, 79, 72, 85, 88, 114, 68, 83, 87, 72, 66, 68, 82, 27, 1 }, 33) + ex.Message);
#endif
            }

            _0x76d4b68d?._0xbb066f8e();
            return true;
        }

        bool _0xdc2946c2 = false;
        do
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                _0xdc2946c2 = true;
                {
                    {
#if B_LOGS
                        Debug.Log(_0xc4b9e23f._0x50c41416(new byte[37] { 75, 68, 117, 99, 100, 77, 48, 67, 121, 119, 126, 61, 121, 126, 48, 81, 126, 127, 126, 105, 125, 127, 101, 99, 62, 48, 64, 124, 113, 105, 117, 98, 48, 89, 84, 42, 48 }, 16) + AuthenticationService.Instance.PlayerId);
#endif
                    }

                    _0xba5b794d = AuthenticationService.Instance.PlayerId;
                }
            }
            catch (AuthenticationException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[25] { 144, 129, 151, 144, 228, 151, 173, 163, 170, 233, 173, 170, 228, 133, 177, 176, 172, 228, 129, 150, 150, 139, 150, 254, 228 }, 196) + ex.Message);
#endif
                }

                _0x76d4b68d?._0xbb066f8e();
                return true;
            }
            catch (RequestFailedException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[28] { 164, 181, 163, 164, 208, 163, 153, 151, 158, 221, 153, 158, 208, 162, 149, 129, 133, 149, 131, 132, 208, 181, 162, 162, 191, 162, 202, 208 }, 240) + ex.Message);
#endif
                }

                _0x76d4b68d?._0xbb066f8e();
                return true;
            }
        }
        while (!_0xdc2946c2);
        return false;
    }

    private IEnumerator _0xdd18fea2(Dictionary<string, object> _0x429d7602)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[30] { 49, 62, 15, 25, 30, 55, 74, 44, 15, 30, 9, 2, 74, 47, 18, 30, 24, 11, 74, 58, 31, 25, 2, 74, 46, 11, 30, 11, 80, 74 }, 106) + string.Join(_0xc4b9e23f._0x50c41416(new byte[1] { 164 }, 173), _0x429d7602));
#endif
            }
        }

        string _0x7d242438 = "";
        // Primary source: nested JSON under "notificationData"
        if (_0x429d7602 != null && _0x429d7602.TryGetValue(_0xc4b9e23f._0x50c41416(new byte[16] { 178, 179, 168, 181, 186, 181, 191, 189, 168, 181, 179, 178, 152, 189, 168, 189 }, 220), out var raw))
        {
            try
            {
                var _0xecc83a8c = raw?.ToString();
                var _0x7e8701b9 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xecc83a8c);
                if (_0x7e8701b9 != null && _0x7e8701b9.TryGetValue(_0xc4b9e23f._0x50c41416(new byte[6] { 211, 197, 206, 196, 201, 196 }, 160), out var val))
                {
                    _0x7d242438 = val?.ToString();
                }
            }
            catch (Exception e)
            {
#if B_LOGS
                Debug.LogError(_0xc4b9e23f._0x50c41416(new byte[30] { 230, 233, 216, 206, 201, 157, 237, 200, 206, 213, 224, 157, 247, 238, 242, 243, 157, 205, 220, 207, 206, 216, 157, 216, 207, 207, 210, 207, 135, 157 }, 189) + e);
#endif
            }
        }

        // Fallback: flat structure
        if (string.IsNullOrEmpty(_0x7d242438) && _0x429d7602 != null && _0x429d7602.TryGetValue(_0xc4b9e23f._0x50c41416(new byte[6] { 244, 226, 233, 227, 238, 227 }, 135), out var lab))
        {
            _0x7d242438 = lab?.ToString();
        }

        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[38] { 82, 93, 108, 122, 125, 41, 89, 124, 122, 97, 84, 41, 79, 108, 125, 106, 97, 108, 109, 41, 122, 108, 103, 109, 96, 109, 41, 111, 123, 102, 100, 41, 99, 122, 102, 103, 51, 41 }, 9) + _0x7d242438);
            }
#endif
        }

        if (string.IsNullOrEmpty(_0x7d242438))
            yield break;
        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[38] { 128, 143, 190, 168, 175, 251, 139, 174, 168, 179, 134, 251, 140, 186, 178, 175, 251, 175, 180, 251, 180, 171, 190, 181, 251, 172, 178, 175, 179, 251, 168, 190, 181, 191, 178, 191, 225, 251 }, 219) + _0x7d242438);
            }
#endif
        }

        _0x40b3e17c = _0x7d242438;
        yield return new WaitUntil(() => _0x936330f6);
        var _0x730a4178 = _0x7e78f5e3(2, 100);
        yield return new WaitUntil(() => _0x730a4178.IsCompleted);
        string _0x5aec8143 = _0x730a4178.Result;
        if (!string.IsNullOrEmpty(_0x5aec8143))
        {
            string _0x425ebc84 = _0x7283c5fa(_0x5aec8143, _0x7d242438);
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[33] { 208, 223, 238, 248, 255, 171, 219, 254, 248, 227, 214, 171, 217, 238, 231, 228, 234, 239, 171, 220, 238, 233, 221, 226, 238, 252, 171, 252, 226, 255, 227, 177, 171 }, 139) + _0x425ebc84);
#endif
            }

            _0x93930a98.Load(_0x425ebc84);
        }
    }

    private string _0xba001c37 = "";
    private void _0xcb582acb()
    {
        if (_0x13fac4f3 != null)
            return;
        var _0x5885aafa = _0xc2f29852();
        _0x13fac4f3 = new GameObject(_0xc4b9e23f._0x50c41416(new byte[14] { 117, 71, 64, 116, 75, 71, 85, 113, 82, 75, 76, 76, 71, 80 }, 34), typeof(RectTransform), typeof(Text));
        _0x807abed0 = _0x13fac4f3.GetComponent<RectTransform>();
        _0x807abed0.SetParent(_0x5885aafa.transform, false);
        _0x807abed0.anchorMin = new Vector2(0.5f, 0.5f);
        _0x807abed0.anchorMax = new Vector2(0.5f, 0.5f);
        _0x807abed0.pivot = new Vector2(0.5f, 0.5f);
        _0x807abed0.sizeDelta = new Vector2(600f, 600f);
        _0x807abed0.anchoredPosition = Vector2.zero;
        _0x0af05949 = _0x13fac4f3.GetComponent<Text>();
        _0x0af05949.text = _0xc4b9e23f._0x50c41416(new byte[1] { 115 }, 92);
        _0x0af05949.font = Resources.GetBuiltinResource<Font>(_0xc4b9e23f._0x50c41416(new byte[17] { 35, 10, 8, 14, 12, 22, 61, 26, 1, 27, 6, 2, 10, 65, 27, 27, 9 }, 111));
        _0x0af05949.fontSize = 200;
        _0x0af05949.alignment = TextAnchor.MiddleCenter;
        _0x0af05949.color = Color.white;
        _0x0af05949.raycastTarget = false;
        _0x13fac4f3.SetActive(false);
    }

    private void _0xd2e34a56(UniWebView _0x82f48c4a)
    {
        _0x82f48c4a.BackgroundColor = Color.clear;
        _0x82f48c4a.SetSupportMultipleWindows(true, true);
        _0x82f48c4a.SetBackButtonEnabled(false);
        _0x93930a98.SetUserAgent(_0xef01bce6());
    }

    private async Task _0xbff9623a()
    {
        if (await _0xb6664e4f())
            return;
        if (await _0x68fde62c())
            return;
        if (await _0xff23ee14())
            return;
        _0xaf04c0a0();
        await _0xdfd6291f(_0x87f46713());
        _0xf814c017 = await _0xb2815a0b();
        await _0x0af0a4d9();
    }

    private string _0x1b09e5a8;
    private string _0x07d4b7b7()
    {
        string _0x7f508750 = _0xc4b9e23f._0x50c41416(new byte[62] { 194, 193, 192, 199, 198, 197, 196, 203, 202, 201, 200, 207, 206, 205, 204, 211, 210, 209, 208, 215, 214, 213, 212, 219, 218, 217, 226, 225, 224, 231, 230, 229, 228, 235, 234, 233, 232, 239, 238, 237, 236, 243, 242, 241, 240, 247, 246, 245, 244, 251, 250, 249, 147, 146, 145, 144, 151, 150, 149, 148, 155, 154 }, 163);
        System.Random _0x51a7c21b = new System.Random();
        int _0xa356eac4 = _0x51a7c21b.Next(8, 16);
        return new string (Enumerable.Repeat(_0x7f508750, _0xa356eac4).Select(_0x7fc82f4b => _0x7fc82f4b[_0x51a7c21b.Next(_0x7fc82f4b.Length)]).ToArray());
    }

    internal bool IsGoogleAuthFlowUrl(string _0xdb082505)
    {
        if (string.IsNullOrEmpty(_0xdb082505))
            return false;
        return _0xdb082505.IndexOf(_0xc4b9e23f._0x50c41416(new byte[19] { 131, 129, 129, 141, 151, 140, 150, 145, 204, 133, 141, 141, 133, 142, 135, 204, 129, 141, 143 }, 226), StringComparison.OrdinalIgnoreCase) >= 0 || _0xdb082505.IndexOf(_0xc4b9e23f._0x50c41416(new byte[16] { 142, 140, 140, 128, 154, 129, 155, 156, 193, 136, 128, 128, 136, 131, 138, 193 }, 239), StringComparison.OrdinalIgnoreCase) >= 0 || _0xdb082505.IndexOf(_0xc4b9e23f._0x50c41416(new byte[21] { 133, 141, 141, 133, 142, 135, 151, 145, 135, 144, 129, 141, 140, 150, 135, 140, 150, 204, 129, 141, 143 }, 226), StringComparison.OrdinalIgnoreCase) >= 0 || _0xdb082505.IndexOf(_0xc4b9e23f._0x50c41416(new byte[11] { 121, 109, 106, 127, 106, 119, 125, 48, 125, 113, 115 }, 30), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private async Task _0x0af0a4d9()
    {
        {
#if B_LOGS
            Debug.Log($"[Test] Send click");
#endif
        }

        _0xcbda13db = _0xc4b9e23f._0x50c41416(new byte[5] { 23, 16, 29, 2, 20 }, 113);
        _0x5a2af73a = /*IsRunningOnEmulator() ? "running" :*/ "";
        _0x48fc01ff = DateTime.UtcNow.Ticks.ToString();
        _0x8afb0e63 = "";
        JObject _0xa2f1401c = BuildRandomPayload(_0x90979726, _0xba001c37, _0x1c669fe8, _0xeb87ca69, _0x7b976bc1, _0xac771e6f, _0x2e75047a, _0xec9de758, _0xf814c017, _0x069628e2, _0xcbda13db, _0x8afb0e63, _0xb5ee7f14, _0x32a0a20c, _0x90c68e54.ToString(), _0xee90543b, _0x48fc01ff, _0x5a2af73a, _0xba5b794d, _0x80fc142b, _0xc72bc106, _0x81a500c8, _0xc2423bf4());
        var _0x941d4e31 = _0x39c081c6(_0xa2f1401c.ToString(), _0xba5b794d);
        {
#if B_LOGS
            {
                Debug.Log($"[Test][First Run] Send Payload for first run: {_0xa2f1401c}");
            }
#endif
        }

        try
        {
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0xc4b9e23f._0x50c41416(new byte[7] { 73, 88, 64, 85, 86, 88, 93 }, 57) + _0xba5b794d, _0x941d4e31 } });
            await Task.Delay(500);
            string _0xbb1a87fd = "";
            for (int _0x1d8136b8 = 0; _0x1d8136b8 < 20; _0x1d8136b8++)
            {
                if (await _0x65c709a6(1, 1))
                {
                    await _0x54bf2974(_0xc4b9e23f._0x50c41416(new byte[7] { 68, 74, 73, 69, 77, 67, 66 }, 38));
                    _0xbb066f8e();
                    return;
                }

                _0xbb1a87fd = await _0x7e78f5e3(1, 500);
                if (!string.IsNullOrEmpty(_0xbb1a87fd))
                    break;
            }

            _0x332abd8c(_0xbb1a87fd);
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[22] { 126, 113, 96, 118, 113, 120, 5, 98, 64, 75, 64, 87, 68, 73, 5, 64, 87, 87, 74, 87, 31, 5 }, 37) + e.Message);
#endif
            }

            _0xbb066f8e();
        }
    }

    private bool _0xbd41ac94 = false;
    internal void _0xcb7bdc1c()
    {
        Rect _0xe60a155b = Screen.safeArea;
        Vector2 _0xf449938e = new Vector2(Screen.width, Screen.height);
        if (_0xe60a155b == lastSafe && _0xf449938e == lastSize)
            return;
        // Apply manual padding
        _0xe60a155b.xMin += _0xba504628;
        _0xe60a155b.xMax -= _0xa7bd9a88;
        _0xe60a155b.yMin += _0x6771e9e6;
        _0xe60a155b.yMax -= _0x89d97dda;
        // Convert Unity safe area -> native WebView frame
        Rect _0xcae2ee44 = new Rect(_0xe60a155b.x, _0xf449938e.y - _0xe60a155b.y - _0xe60a155b.height, // Y flip for native coordinate system
 _0xe60a155b.width, _0xe60a155b.height);
        _0x93930a98.Frame = _0xcae2ee44;
        lastSafe = Screen.safeArea;
        lastSize = _0xf449938e;
    }

    private string _0xba5b794d = "";
    internal bool IsHttpUrl(string _0x847302e1)
    {
        if (string.IsNullOrEmpty(_0x847302e1))
            return false;
        return _0x847302e1.StartsWith(_0xc4b9e23f._0x50c41416(new byte[7] { 0, 28, 28, 24, 82, 71, 71 }, 104), StringComparison.OrdinalIgnoreCase) || _0x847302e1.StartsWith(_0xc4b9e23f._0x50c41416(new byte[8] { 78, 82, 82, 86, 85, 28, 9, 9 }, 38), StringComparison.OrdinalIgnoreCase);
    }

    private void StopCurrentFailedLoad(UniWebView _0xba435321)
    {
        _0xecb8ecc4(false);
        if (_0xba435321 == null)
            return;
        _0xba435321.Stop();
        if (_0xba435321.CanGoBack)
            _0xba435321.GoBack();
    }

    private string _0x32a0a20c = "";
    private void _0xecb8ecc4(bool _0x7873ec57)
    {
        _0xcb582acb();
        _0x13fac4f3.SetActive(_0x7873ec57);
        _0xbd41ac94 = _0x7873ec57;
        if (_0x7873ec57)
        {
            _0x13fac4f3.transform.SetAsLastSibling();
            if (_0x807abed0 != null)
                _0x807abed0.localRotation = Quaternion.identity;
        }
    }

    private string _0xef01bce6()
    {
        if (string.IsNullOrEmpty(_0xec9de758) && _0x93930a98 != null)
            _0xec9de758 = _0x93930a98.GetUserAgent();
        if (string.IsNullOrEmpty(_0xec9de758))
            return string.Empty;
        string _0x1a65f379 = Regex.Replace(_0xec9de758, _0xc4b9e23f._0x50c41416(new byte[11] { 51, 28, 69, 84, 51, 28, 69, 24, 25, 51, 13 }, 111), string.Empty);
        _0x1a65f379 = Regex.Replace(_0x1a65f379, _0xc4b9e23f._0x50c41416(new byte[15] { 133, 170, 242, 155, 172, 176, 181, 189, 246, 130, 135, 226, 240, 132, 242 }, 217), string.Empty);
        _0x1a65f379 = Regex.Replace(_0x1a65f379, _0xc4b9e23f._0x50c41416(new byte[15] { 131, 176, 167, 166, 188, 186, 187, 250, 225, 137, 251, 229, 137, 166, 255 }, 213), string.Empty);
        return Regex.Replace(_0x1a65f379, _0xc4b9e23f._0x50c41416(new byte[6] { 58, 21, 29, 84, 74, 27 }, 102), _0xc4b9e23f._0x50c41416(new byte[1] { 201 }, 233)).Trim();
    }

    private int _0xfc2ff2db = 0;
    private string _0x7283c5fa(string _0x6ea31d02, string _0x08670513)
    {
        if (string.IsNullOrEmpty(_0x08670513))
            return _0x6ea31d02;
        if (_0x6ea31d02.Contains(_0xc4b9e23f._0x50c41416(new byte[1] { 35 }, 28)))
            return _0x6ea31d02 + _0xc4b9e23f._0x50c41416(new byte[8] { 219, 142, 152, 147, 153, 148, 153, 192 }, 253) + UnityWebRequest.EscapeURL(_0x08670513);
        else
            return _0x6ea31d02 + _0xc4b9e23f._0x50c41416(new byte[8] { 234, 166, 176, 187, 177, 188, 177, 232 }, 213) + UnityWebRequest.EscapeURL(_0x08670513);
    }

    private static readonly string WindowsDesktopUserAgent = _0xc4b9e23f._0x50c41416(new byte[111] { 200, 234, 255, 236, 233, 233, 228, 170, 176, 171, 181, 165, 173, 210, 236, 235, 225, 234, 242, 246, 165, 203, 209, 165, 180, 181, 171, 181, 190, 165, 210, 236, 235, 179, 177, 190, 165, 253, 179, 177, 172, 165, 196, 245, 245, 233, 224, 210, 224, 231, 206, 236, 241, 170, 176, 182, 178, 171, 182, 179, 165, 173, 206, 205, 209, 200, 201, 169, 165, 233, 236, 238, 224, 165, 194, 224, 230, 238, 234, 172, 165, 198, 237, 247, 234, 232, 224, 170, 180, 183, 181, 171, 181, 171, 181, 171, 181, 165, 214, 228, 227, 228, 247, 236, 170, 176, 182, 178, 171, 182, 179 }, 133);
    private string _0x8afb0e63 = "";
    private async void Start()
    {
        await _0xbff9623a();
    }

    private ApplicationInstallMode _0x90c68e54 = ApplicationInstallMode.Unknown;
    private void _0x7cd03dba()
    {
        if (_0x93930a98 == null)
            return;
        if (_0x999cc648)
            _0x93930a98.SetUserAgent(_0xef01bce6());
        else
            _0x93930a98.SetUserAgent("");
    }

    private string _0x1c669fe8 = "";
    private void _0x332abd8c(string _0xe7ff376e)
    {
        bool _0x45b51c62 = !string.IsNullOrEmpty(_0xe7ff376e);
        if (_0x45b51c62)
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[13] { 90, 85, 100, 114, 117, 92, 33, 82, 105, 110, 118, 59, 33 }, 1) + _0xe7ff376e);
#endif
            }

            _0x90f2cbd8(_0xe7ff376e);
            return;
        }
        else
        {
            {
#if B_LOGS
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[39] { 175, 160, 145, 135, 128, 169, 212, 178, 149, 152, 152, 150, 149, 151, 159, 212, 22, 114, 102, 212, 179, 149, 153, 145, 212, 220, 154, 155, 212, 146, 157, 154, 149, 152, 212, 161, 166, 184, 221 }, 244));
#endif
            }

            _0xbb066f8e();
            return;
        }
    }

    private void _0x9babd2c1()
    {
        if (Camera.main == null)
            return;
        Camera.main.cullingMask = 0;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }

    private RectTransform _0x807abed0;
    /* ============================= */
    /* ENCRYPT / DECRYPT             */
    /* ============================= */
    private string _0x39c081c6(string _0xab8842bc, string _0x9c5f853f)
    {
        try
        {
            using var _0xf6668761 = Aes.Create();
            _0xf6668761.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x9c5f853f));
            _0xf6668761.GenerateIV();
            using var _0x6a0cb1e6 = new MemoryStream();
            _0x6a0cb1e6.Write(_0xf6668761.IV, 0, _0xf6668761.IV.Length);
            using (var _0x42d1972b = new CryptoStream(_0x6a0cb1e6, _0xf6668761.CreateEncryptor(), CryptoStreamMode.Write))
            {
                var _0x495d0148 = Encoding.UTF8.GetBytes(_0xab8842bc);
                _0x42d1972b.Write(_0x495d0148, 0, _0x495d0148.Length);
                _0x42d1972b.FlushFinalBlock();
            }

            return Convert.ToBase64String(_0x6a0cb1e6.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private void OnApplicationFocus(bool _0x8d96bfaf)
    {
        isApplicationFocus = _0x8d96bfaf;
        if (_0x8d96bfaf && _0x936330f6)
        {
            _0x14eb421e();
        }
    }

    public void _0xbb066f8e()
    {
        isDestroyedForce = true;
        StopAllCoroutines();
        {
#if B_LOGS
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[18] { 24, 23, 38, 48, 55, 30, 99, 15, 34, 54, 45, 32, 43, 99, 4, 34, 46, 38 }, 67));
#endif
        }

        _0x755be608.Instance?._0x67775186();
        _0x8fc0d527.Instance._0x226158a4(_0xea334b23._0x29a65535.DEFAULT);
    }

    private void _0x15c8a9a5()
    {
        if (_0x1b71bca0)
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[18] { 243, 206, 223, 194, 150, 215, 218, 196, 211, 215, 210, 207, 150, 197, 222, 217, 193, 216 }, 182));
            return;
        }

        _0xecb8ecc4(false);
        WLog(_0xc4b9e23f._0x50c41416(new byte[46] { 182, 154, 146, 149, 219, 172, 158, 153, 173, 146, 158, 140, 219, 171, 142, 136, 147, 219, 181, 148, 143, 146, 157, 146, 152, 154, 143, 146, 148, 149, 219, 211, 147, 154, 137, 159, 140, 154, 137, 158, 219, 153, 154, 152, 144, 210 }, 251));
        ++_0xfc2ff2db;
        _0x3cc1f3fe();
        if (_0xfc2ff2db <= 1)
            return;
        if (_0x8beead78())
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[37] { 233, 212, 197, 216, 140, 223, 199, 197, 220, 220, 201, 200, 140, 129, 146, 140, 220, 195, 220, 217, 220, 223, 140, 223, 216, 197, 192, 192, 140, 195, 220, 201, 194, 201, 200, 150, 140 }, 172) + _0x9f92c081.Count);
            return;
        }

        Application.Quit();
    }

    private readonly string[] _0xaaa5f249 = new string[]
    {
        _0xc4b9e23f._0x50c41416(new byte[60] { 4, 107, 122, 68, 212, 160, 156, 145, 212, 134, 145, 145, 152, 135, 212, 149, 134, 145, 212, 156, 155, 128, 212, 134, 157, 147, 156, 128, 212, 154, 155, 131, 212, 22, 116, 103, 212, 144, 155, 154, 22, 116, 109, 128, 212, 153, 157, 135, 135, 212, 141, 155, 129, 134, 212, 135, 132, 157, 154, 213 }, 244),
        _0xc4b9e23f._0x50c41416(new byte[52] { 21, 122, 104, 101, 197, 172, 145, 197, 134, 138, 144, 137, 129, 197, 135, 128, 197, 156, 138, 144, 151, 197, 137, 144, 134, 142, 156, 197, 136, 138, 136, 128, 139, 145, 197, 7, 101, 118, 197, 146, 141, 156, 197, 150, 145, 138, 149, 197, 139, 138, 146, 218 }, 229),
        _0xc4b9e23f._0x50c41416(new byte[66] { 179, 203, 240, 190, 233, 222, 113, 19, 56, 54, 113, 38, 56, 63, 34, 113, 48, 35, 52, 113, 57, 56, 37, 37, 56, 63, 54, 113, 60, 62, 35, 52, 113, 62, 55, 37, 52, 63, 113, 37, 62, 53, 48, 40, 113, 179, 209, 194, 113, 34, 37, 48, 40, 113, 56, 63, 113, 37, 57, 52, 113, 54, 48, 60, 52, 127 }, 81),
        _0xc4b9e23f._0x50c41416(new byte[54] { 88, 55, 61, 58, 136, 252, 192, 193, 219, 136, 193, 219, 136, 216, 218, 193, 197, 205, 136, 220, 193, 197, 205, 136, 74, 40, 59, 136, 220, 192, 205, 136, 202, 205, 219, 220, 136, 216, 196, 201, 209, 205, 218, 219, 136, 216, 196, 201, 209, 136, 198, 199, 223, 134 }, 168),
        _0xc4b9e23f._0x50c41416(new byte[48] { 115, 28, 23, 38, 163, 218, 236, 246, 241, 163, 244, 234, 237, 237, 234, 237, 228, 163, 240, 247, 241, 230, 226, 232, 163, 224, 236, 246, 239, 231, 163, 225, 230, 163, 236, 237, 230, 163, 240, 243, 234, 237, 163, 226, 244, 226, 250, 173 }, 131),
        _0xc4b9e23f._0x50c41416(new byte[65] { 112, 31, 26, 0, 160, 202, 225, 227, 235, 240, 239, 244, 243, 160, 225, 242, 229, 160, 237, 239, 242, 229, 160, 225, 227, 244, 233, 246, 229, 160, 244, 239, 238, 233, 231, 232, 244, 160, 98, 0, 19, 160, 243, 244, 225, 249, 160, 225, 238, 228, 160, 244, 242, 249, 160, 249, 239, 245, 242, 160, 236, 245, 227, 235, 174 }, 128),
        _0xc4b9e23f._0x50c41416(new byte[55] { 131, 236, 253, 193, 83, 54, 5, 22, 1, 10, 83, 0, 3, 26, 29, 83, 16, 28, 6, 29, 7, 0, 83, 145, 243, 224, 83, 7, 27, 22, 83, 29, 22, 11, 7, 83, 28, 29, 22, 83, 16, 28, 6, 31, 23, 83, 17, 22, 83, 10, 28, 6, 1, 0, 93 }, 115),
        _0xc4b9e23f._0x50c41416(new byte[63] { 63, 112, 77, 50, 101, 82, 253, 141, 177, 188, 164, 184, 175, 174, 253, 175, 180, 186, 181, 169, 253, 179, 178, 170, 253, 188, 175, 184, 253, 170, 180, 179, 179, 180, 179, 186, 253, 63, 93, 78, 253, 185, 178, 179, 63, 93, 68, 169, 253, 170, 188, 177, 182, 253, 188, 170, 188, 164, 253, 164, 184, 169, 243 }, 221),
        _0xc4b9e23f._0x50c41416(new byte[51] { 181, 218, 202, 195, 101, 10, 43, 41, 60, 101, 49, 45, 42, 54, 32, 101, 50, 45, 42, 101, 54, 49, 36, 60, 101, 44, 43, 101, 49, 45, 32, 101, 34, 36, 40, 32, 101, 50, 44, 43, 101, 49, 45, 32, 101, 53, 55, 44, 63, 32, 107 }, 69),
        _0xc4b9e23f._0x50c41416(new byte[64] { 163, 219, 224, 174, 249, 206, 97, 12, 46, 44, 36, 47, 53, 52, 44, 97, 40, 50, 97, 36, 55, 36, 51, 56, 53, 41, 40, 47, 38, 97, 163, 193, 210, 97, 42, 36, 36, 49, 97, 50, 49, 40, 47, 47, 40, 47, 38, 97, 39, 46, 51, 97, 56, 46, 52, 51, 97, 34, 41, 32, 47, 34, 36, 111 }, 65)
    };
    private bool _0x984fed58 = false;
    private int _0x89d97dda = 5, _0x6771e9e6 = 5, _0xba504628 = 5, _0xa7bd9a88 = 5;
    private void _0x14eb421e()
    {
        using (var _0x193b2134 = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[30] { 143, 131, 129, 194, 153, 130, 133, 152, 149, 223, 136, 194, 156, 128, 141, 149, 137, 158, 194, 185, 130, 133, 152, 149, 188, 128, 141, 149, 137, 158 }, 236)))
        using (var _0x2cac0a9a = _0x193b2134.GetStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 50, 36, 35, 35, 52, 63, 37, 16, 50, 37, 56, 39, 56, 37, 40 }, 81)))
        using (var _0x95a76629 = _0x2cac0a9a.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[9] { 144, 146, 131, 190, 153, 131, 146, 153, 131 }, 247)))
        {
            if (_0x95a76629 == null)
                return;
            using (var _0xc37b7ff2 = _0x95a76629.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[9] { 201, 203, 218, 235, 214, 218, 220, 207, 221 }, 174)))
            {
                if (_0xc37b7ff2 == null)
                    return;
                using (var _0xa26814d3 = new AndroidJavaObject(_0xc4b9e23f._0x50c41416(new byte[19] { 185, 164, 177, 248, 188, 165, 185, 184, 248, 156, 133, 153, 152, 153, 180, 188, 179, 181, 162 }, 214)))
                using (var _0x55041131 = _0xc37b7ff2.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[6] { 244, 250, 230, 204, 250, 235 }, 159)))
                using (var _0x4cc92315 = _0x55041131.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[8] { 165, 184, 169, 190, 173, 184, 163, 190 }, 204)))
                {
                    while (_0x4cc92315.Call<bool>(_0xc4b9e23f._0x50c41416(new byte[7] { 106, 99, 113, 76, 103, 122, 118 }, 2)))
                    {
                        string _0x1488427c = _0x4cc92315.Call<string>(_0xc4b9e23f._0x50c41416(new byte[4] { 233, 226, 255, 243 }, 135));
                        using (var _0x62b7eb2d = _0xc37b7ff2.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[3] { 9, 11, 26 }, 110), _0x1488427c))
                        {
                            _0xa26814d3.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[3] { 181, 176, 177 }, 197), _0x1488427c, _0x62b7eb2d);
                        }
                    }

                    string _0x11baf815 = _0xa26814d3.Call<string>(_0xc4b9e23f._0x50c41416(new byte[8] { 147, 136, 180, 147, 149, 142, 137, 128 }, 231));
                    if (!string.IsNullOrEmpty(_0x11baf815))
                    {
                        _0x248815e2(_0x11baf815);
                        _0x380eb801(_0x11baf815);
                    }
                }
            }
        }
    }

    internal bool firstLoadShown = false;
    internal bool isApplicationPause = false;
    private IEnumerator _0xebbfa16f(IEnumerator _0x18c1d7f0, TaskCompletionSource<bool> _0x8a2a4537)
    {
        yield return _0x18c1d7f0;
        _0x8a2a4537.SetResult(true);
    }

    private async Task<string> _0x7e78f5e3(int _0x371a20f2 = 5, int _0xee8fceaf = 500)
    {
        try
        {
            List<EntityData> _0x256c462b = new List<EntityData>();
            int _0x28ebb20d = 0;
            do
            {
                _0x256c462b = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0xc4b9e23f._0x50c41416(new byte[8] { 82, 78, 67, 91, 71, 80, 107, 70 }, 34), _0xba5b794d, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0xba5b794d }), new QueryOptions())).ToList();
                await Task.Delay(_0xee8fceaf);
            }
            while (_0x256c462b.Count == 0 && _0x28ebb20d++ < _0x371a20f2);
            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[33] { 68, 75, 122, 108, 107, 66, 63, 76, 126, 105, 122, 123, 63, 83, 118, 113, 116, 63, 78, 106, 122, 109, 102, 63, 109, 122, 108, 106, 115, 107, 108, 37, 63 }, 31) + JsonConvert.SerializeObject(_0x256c462b, Formatting.Indented));
                }
#endif
            }

            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[39] { 228, 235, 218, 204, 203, 226, 159, 236, 222, 201, 218, 219, 159, 243, 214, 209, 212, 159, 238, 202, 218, 205, 198, 159, 205, 218, 204, 202, 211, 203, 204, 159, 220, 208, 202, 209, 203, 133, 159 }, 191) + _0x256c462b.Count);
                }
#endif
            }

            var _0xb6af9984 = _0x256c462b.SelectMany(_0x583313a4 => _0x583313a4.Data).FirstOrDefault(_0xe1048b97 => _0xe1048b97.Key == _0xba5b794d)?.Value.GetAs<string>() ?? string.Empty;
            _0xb6af9984 = Decrypt(_0xb6af9984, _0xba5b794d);
            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[24] { 215, 216, 233, 255, 248, 209, 172, 192, 227, 237, 232, 172, 255, 237, 250, 233, 232, 172, 224, 229, 226, 231, 182, 172 }, 140) + _0xb6af9984);
                }
#endif
            }

            return _0xb6af9984;
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[39] { 16, 31, 46, 56, 63, 22, 107, 12, 46, 63, 107, 36, 57, 107, 59, 42, 57, 56, 46, 107, 56, 42, 61, 46, 47, 107, 39, 34, 37, 32, 107, 45, 42, 34, 39, 46, 47, 113, 107 }, 75) + ex.Message);
                }
#endif
            }

            return string.Empty;
        }
    }

    internal bool ContainsIgnoreCase(string _0x90aa2a49, string _0x9ded3d02)
    {
        if (string.IsNullOrEmpty(_0x90aa2a49) || string.IsNullOrEmpty(_0x9ded3d02))
            return false;
        return _0x90aa2a49.IndexOf(_0x9ded3d02, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private void _0x2ae14c8b()
    {
        _0x999cc648 = true;
        if (_0x93930a98 != null)
            _0x93930a98.SetUserAgent(_0xef01bce6());
    }

    private IEnumerator _0x87f46713()
    {
        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[26] { 142, 129, 176, 166, 161, 136, 245, 156, 187, 188, 161, 188, 180, 185, 188, 175, 176, 135, 176, 179, 179, 176, 167, 176, 167, 245 }, 213));
            }
#endif
        }

        bool _0xf8f0d011 = false;
        InstallReferrer.GetReferrer((_0x1d5bb95c) =>
        {
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[24] { 52, 59, 10, 28, 27, 79, 61, 10, 9, 10, 29, 29, 10, 29, 50, 79, 8, 10, 27, 79, 141, 233, 253, 79 }, 111) + _0x7b976bc1);
            if (_0x1d5bb95c.IsSuccess)
            {
                _0x7b976bc1 = _0x1d5bb95c.InstallReferrer ?? "";
                {
#if B_LOGS
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[28] { 245, 250, 203, 221, 218, 142, 252, 203, 200, 203, 220, 220, 203, 220, 243, 142, 253, 219, 205, 205, 203, 221, 221, 142, 76, 40, 60, 142 }, 174) + _0x7b976bc1);
#endif
                }
            }
            else
            {
                {
#if B_LOGS
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[27] { 196, 203, 250, 236, 235, 191, 205, 250, 249, 250, 237, 237, 250, 237, 194, 191, 217, 254, 246, 243, 250, 251, 191, 125, 25, 13, 191 }, 159) + _0x1d5bb95c);
#endif
                }

                _0x7b976bc1 = "";
            }

            _0xd05d0799 = true;
        });
        StartCoroutine(_0x39064db1(2f));
        yield return new WaitUntil(() => _0xd05d0799);
        {
#if B_LOGS
            Debug.Log($"[Test] check google atr {_0x7b976bc1}");
#endif
        }

        bool _0x752ce726 = _0x7b976bc1.Contains(_0xc4b9e23f._0x50c41416(new byte[6] { 94, 90, 85, 80, 93, 4 }, 57));
        _0xf8f0d011 = _0x752ce726 || _0x7b976bc1.Contains(_0xc4b9e23f._0x50c41416(new byte[18] { 132, 149, 149, 150, 203, 140, 139, 150, 145, 132, 130, 151, 132, 136, 203, 134, 138, 136 }, 229)) || _0x7b976bc1.Contains(_0xc4b9e23f._0x50c41416(new byte[17] { 16, 1, 1, 2, 95, 23, 16, 18, 20, 19, 30, 30, 26, 95, 18, 30, 28 }, 113));
        _0xac771e6f = _0x752ce726 ? "" : (_0xf8f0d011 ? "" : _0xac771e6f);
        _0xac771e6f = _0xac771e6f ?? "";
        _0x2e75047a = _0x2e75047a ?? "";
        {
#if B_LOGS
            Debug.Log($"[Test] oneLinkData (FB): {_0xac771e6f}");
#endif
        }
    }

    private string _0xc2423bf4()
    {
        float _0x81f59f47 = Time.realtimeSinceStartup;
        if (_0x81f59f47 < 0f)
            _0x81f59f47 = 0f;
        int _0xfe41bd36 = (int)(_0x81f59f47 * 1000f);
        int _0xca234670 = _0xfe41bd36 / 60000;
        int _0x69448929 = (_0xfe41bd36 / 1000) % 60;
        int _0xeb865052 = _0xfe41bd36 % 1000;
        return string.Format(_0xc4b9e23f._0x50c41416(new byte[21] { 7, 76, 70, 76, 76, 1, 70, 7, 77, 70, 76, 76, 1, 70, 7, 78, 70, 76, 76, 76, 1 }, 124), _0xca234670, _0x69448929, _0xeb865052);
    }

    private string _0xc72bc106 = "";
    //    private async Task<string> GetMyip()
    //    {
    //        string result = "";
    //        var processorType = SystemInfo.processorType;
    //        //        {
    //        //#if NOT_B_STARTED
    //        //#endif
    //        if (!processorType.Contains("armv7", StringComparison.OrdinalIgnoreCase) && !processorType.Contains("x86-64", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var tcs = new TaskCompletionSource<string>();
    //            // Primary and fallback STUN servers (Google STUN 1-6)
    //            var stunServers = new[]
    //            {
    //                new[] { "stun:stun.l.google.com:19302" },      // Primary
    //                //new[] { "stun:stun1.l.google.com:19302" },     // Fallback 1
    //                //new[] { "stun:stun2.l.google.com:19302" },     // Fallback 2
    //                //new[] { "stun:stun3.l.google.com:19302" },     // Fallback 3
    //                //new[] { "stun:stun4.l.google.com:19302" },     // Fallback 4
    //                //new[] { "stun:stun5.l.google.com:19302" },     // Fallback 5
    //                //new[] { "stun:stun6.l.google.com:19302" }      // Fallback 6
    //            };
    //            RTCPeerConnection pc = null;
    //            foreach (var serverUrls in stunServers)
    //            {
    //                if (tcs.Task.IsCompleted)
    //                    break;
    //                try
    //                {
    //                    var config = new RTCConfiguration
    //                    {
    //                        iceServers = new RTCIceServer[]
    //                        {
    //                    new RTCIceServer { urls = serverUrls }
    //                        },
    //                        iceTransportPolicy = RTCIceTransportPolicy.All
    //                    };
    //                    pc = new RTCPeerConnection(ref config);
    //                    pc.OnIceCandidate = candidate =>
    //                    {
    //                        if (candidate == null || tcs.Task.IsCompleted)
    //                            return;
    //                        if (candidate.Type == RTCIceCandidateType.Srflx || candidate.Type == RTCIceCandidateType.Prflx)
    //                        {
    //                            string address = candidate.Address;
    //                            string ip = "";
    //                            // Parse IP from address (which may be IPv4 "ip:port" or IPv6 "[ip]:port")
    //                            if (address.StartsWith("[") && address.Contains("]:"))
    //                            {
    //                                // IPv6 format: [2001:db8::1]:12345
    //                                int endBracket = address.IndexOf(']');
    //                                ip = address.Substring(1, endBracket - 1);
    //                            }
    //                            else if (address.Contains(':'))
    //                            {
    //                                // IPv4 format: 192.168.1.1:12345
    //                                int lastColon = address.LastIndexOf(':');
    //                                ip = address.Substring(0, lastColon);
    //                            }
    //                            else
    //                            {
    //                                // No port, just IP
    //                                ip = address;
    //                            }
    //                            {
    //#if B_LOGS
    //                                {
    //                                    Debug.Log($"[test STUN] Public IP: {ip} from {serverUrls[0]}");
    //                                }
    //#endif
    //                            }
    //                            tcs.TrySetResult(ip);
    //                        }
    //                    };
    //                    pc.CreateDataChannel("init");
    //                    var offerOp = pc.CreateOffer();
    //                    while (!offerOp.IsDone)
    //                        await Task.Yield();
    //                    var desc = offerOp.Desc;
    //                    pc.SetLocalDescription(ref desc);
    //                    float timeout = 10f;
    //                    float t = 0f;
    //                    while (!tcs.Task.IsCompleted && t < timeout)
    //                    {
    //                        await Task.Delay(100);
    //                        t += 0.1f;
    //                    }
    //                    if (tcs.Task.IsCompleted)
    //                    {
    //                        result = tcs.Task.Result;
    //                        break;
    //                    }
    //                    {
    //#if B_LOGS
    //                        {
    //                            Debug.Log($"[test STUN] Failed with {serverUrls[0]}, trying next...");
    //                        }
    //#endif
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //#if B_LOGS
    //                    {
    //                        Debug.Log($"[test STUN] Error with {serverUrls[0]}: {ex.Message}");
    //                    }
    //#endif
    //                    if (pc != null)
    //                    {
    //                        pc.Close();
    //                        pc.Dispose();
    //                    }
    //                }
    //            }
    //            if (!tcs.Task.IsCompleted)
    //                result = "";
    //        }
    //        //#if NOT_B_STARTED
    //        //            else
    //        //        if(result == "")
    //        //        {
    //        //            {
    //        //#if B_LOGS
    //        //                {
    //        //                    Debug.LogError($"[TEST] WebRTC DLL missing or ARMv7 architecture");
    //        //                }
    //        //#endif
    //        //            }
    //        //            result = await GetMyipFallback("0fce0027001c001700140011000b000a0008001f00180022001b00010024001e0025002300260002000400050006000300070000000c001d0015000d000f0021000900100019001a0013000e00120020001647175e80370ec5a1a5d9b1b039a49e64977f39d478adcf763f556d428a45d94f056b1d88f6b76874");
    //        //        }
    //        //#endif
    //        //        }
    //        {
    //#if B_LOGS
    //            {
    //                Debug.Log($"[Test] Get my ip: {result}");
    //            }
    //#endif
    //        }
    //        return result;
    //    }
    private async Task<string> _0xb2815a0b()
    {
        var _0xda24474b = _0xc4b9e23f._0x50c41416(new byte[40] { 58, 38, 38, 34, 33, 104, 125, 125, 37, 37, 37, 124, 49, 62, 61, 39, 54, 52, 62, 51, 32, 55, 124, 49, 61, 63, 125, 49, 54, 60, 127, 49, 53, 59, 125, 38, 32, 51, 49, 55 }, 82);
        using (UnityWebRequest _0xa4e8d6de = UnityWebRequest.Get(_0xda24474b))
        {
            await _0xa4e8d6de.SendWebRequest();
            string[] _0xd9116237 = _0xa4e8d6de.downloadHandler.text.Split('\n');
            foreach (string _0xf007571c in _0xd9116237)
            {
                if (_0xf007571c.StartsWith(_0xc4b9e23f._0x50c41416(new byte[3] { 186, 163, 238 }, 211)))
                {
                    string _0x68561822 = _0xf007571c.Substring(3);
                    {
#if B_LOGS
                        {
                            Debug.Log($"[Test] User ip (FALLBACK MODE): {_0x68561822} from {_0xda24474b}");
                        }
#endif
                    }

                    return _0x68561822;
                }
            }
        }

        return "";
    }

    private string _0x81a500c8 = "";
    private string _0xee90543b = "";
    private float _0x0167ec95 = 0f;
    private bool _0x4880ade8(string _0xf2a568ee)
    {
        if (string.IsNullOrEmpty(_0xf2a568ee))
            return false;
        try
        {
            using (var _0x1f2a9913 = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[30] { 24, 20, 22, 85, 14, 21, 18, 15, 2, 72, 31, 85, 11, 23, 26, 2, 30, 9, 85, 46, 21, 18, 15, 2, 43, 23, 26, 2, 30, 9 }, 123)))
            using (var _0x727f3912 = _0x1f2a9913.GetStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 128, 150, 145, 145, 134, 141, 151, 162, 128, 151, 138, 149, 138, 151, 154 }, 227)))
            using (var _0x2a74cfdb = _0x727f3912.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[17] { 194, 192, 209, 245, 196, 198, 206, 196, 194, 192, 232, 196, 203, 196, 194, 192, 215 }, 165)))
            using (var _0x7f38cf56 = _0x2a74cfdb.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[25] { 157, 159, 142, 182, 155, 143, 148, 153, 146, 179, 148, 142, 159, 148, 142, 188, 149, 136, 170, 155, 153, 145, 155, 157, 159 }, 250), _0xf2a568ee))
            {
                if (_0x7f38cf56 == null)
                    return false;
                WLog(_0xc4b9e23f._0x50c41416(new byte[37] { 184, 147, 137, 148, 150, 158, 183, 146, 144, 158, 219, 151, 154, 142, 149, 152, 147, 219, 146, 149, 136, 143, 154, 151, 151, 158, 159, 219, 139, 154, 152, 144, 154, 156, 158, 193, 219 }, 251) + _0xf2a568ee);
                _0x7f38cf56.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[8] { 240, 245, 245, 215, 253, 240, 246, 226 }, 145), 0x10000000);
                _0x727f3912.Call(_0xc4b9e23f._0x50c41416(new byte[13] { 86, 81, 68, 87, 81, 100, 70, 81, 76, 83, 76, 81, 92 }, 37), _0x7f38cf56);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private void _0x445b0684()
    {
        WLog(_0xc4b9e23f._0x50c41416(new byte[21] { 180, 157, 142, 152, 139, 157, 142, 153, 220, 158, 157, 159, 151, 220, 140, 142, 153, 143, 143, 153, 152 }, 252));
        if (Time.frameCount == _0x9df46722)
            return;
        _0x9df46722 = Time.frameCount;
        if (_0xbe979cbe())
            return;
        _0x15c8a9a5();
    }

    private void WLog(string _0x509820c4)
    {
#if B_LOGS
        {
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[7] { 145, 158, 175, 185, 190, 151, 234 }, 202) + _0x509820c4);
        }
#endif
    }

    private string _0xe0826c2f()
    {
        return _0xc4b9e23f._0x50c41416(new byte[12] { 47, 97, 114, 105, 100, 115, 110, 104, 105, 47, 46, 124 }, 7) + _0xc4b9e23f._0x50c41416(new byte[8] { 94, 73, 90, 8, 93, 73, 21, 15 }, 40) + WindowsDesktopUserAgent + _0xc4b9e23f._0x50c41416(new byte[2] { 137, 149 }, 174) + _0xc4b9e23f._0x50c41416(new byte[30] { 23, 0, 19, 65, 17, 19, 14, 21, 14, 92, 47, 0, 23, 8, 6, 0, 21, 14, 19, 79, 17, 19, 14, 21, 14, 21, 24, 17, 4, 90 }, 97) + _0xc4b9e23f._0x50c41416(new byte[121] { 79, 92, 71, 74, 93, 64, 70, 71, 9, 77, 76, 79, 1, 70, 75, 67, 5, 66, 76, 80, 5, 95, 72, 69, 0, 82, 93, 91, 80, 82, 102, 75, 67, 76, 74, 93, 7, 77, 76, 79, 64, 71, 76, 121, 91, 70, 89, 76, 91, 93, 80, 1, 70, 75, 67, 5, 66, 76, 80, 5, 82, 78, 76, 93, 19, 79, 92, 71, 74, 93, 64, 70, 71, 1, 0, 82, 91, 76, 93, 92, 91, 71, 9, 95, 72, 69, 18, 84, 5, 74, 70, 71, 79, 64, 78, 92, 91, 72, 75, 69, 76, 19, 93, 91, 92, 76, 84, 0, 18, 84, 74, 72, 93, 74, 65, 1, 76, 0, 82, 84, 84 }, 41) + _0xc4b9e23f._0x50c41416(new byte[26] { 38, 39, 36, 106, 50, 48, 45, 54, 45, 110, 101, 55, 49, 39, 48, 3, 37, 39, 44, 54, 101, 110, 55, 35, 107, 121 }, 66) + _0xc4b9e23f._0x50c41416(new byte[130] { 84, 85, 86, 24, 64, 66, 95, 68, 95, 28, 23, 81, 64, 64, 102, 85, 66, 67, 89, 95, 94, 23, 28, 23, 5, 30, 0, 16, 24, 103, 89, 94, 84, 95, 71, 67, 16, 126, 100, 16, 1, 0, 30, 0, 11, 16, 103, 89, 94, 6, 4, 11, 16, 72, 6, 4, 25, 16, 113, 64, 64, 92, 85, 103, 85, 82, 123, 89, 68, 31, 5, 3, 7, 30, 3, 6, 16, 24, 123, 120, 100, 125, 124, 28, 16, 92, 89, 91, 85, 16, 119, 85, 83, 91, 95, 25, 16, 115, 88, 66, 95, 93, 85, 31, 1, 2, 0, 30, 0, 30, 0, 30, 0, 16, 99, 81, 86, 81, 66, 89, 31, 5, 3, 7, 30, 3, 6, 23, 25, 11 }, 48) + _0xc4b9e23f._0x50c41416(new byte[30] { 234, 235, 232, 166, 254, 252, 225, 250, 225, 162, 169, 254, 226, 239, 250, 232, 225, 252, 227, 169, 162, 169, 217, 231, 224, 189, 188, 169, 167, 181 }, 142) + _0xc4b9e23f._0x50c41416(new byte[34] { 129, 128, 131, 205, 149, 151, 138, 145, 138, 201, 194, 147, 128, 139, 129, 138, 151, 194, 201, 194, 162, 138, 138, 130, 137, 128, 197, 172, 139, 134, 203, 194, 204, 222 }, 229) + _0xc4b9e23f._0x50c41416(new byte[30] { 105, 104, 107, 37, 125, 127, 98, 121, 98, 33, 42, 96, 108, 117, 89, 98, 120, 110, 101, 93, 98, 100, 99, 121, 126, 42, 33, 61, 36, 54 }, 13) + _0xc4b9e23f._0x50c41416(new byte[449] { 176, 182, 189, 191, 178, 165, 182, 228, 177, 165, 160, 249, 191, 166, 182, 165, 170, 160, 183, 254, 159, 191, 166, 182, 165, 170, 160, 254, 227, 135, 172, 182, 171, 169, 173, 177, 169, 227, 232, 178, 161, 182, 183, 173, 171, 170, 254, 227, 245, 246, 244, 227, 185, 232, 191, 166, 182, 165, 170, 160, 254, 227, 131, 171, 171, 163, 168, 161, 228, 135, 172, 182, 171, 169, 161, 227, 232, 178, 161, 182, 183, 173, 171, 170, 254, 227, 245, 246, 244, 227, 185, 232, 191, 166, 182, 165, 170, 160, 254, 227, 138, 171, 176, 249, 133, 251, 134, 182, 165, 170, 160, 227, 232, 178, 161, 182, 183, 173, 171, 170, 254, 227, 246, 240, 227, 185, 153, 232, 169, 171, 166, 173, 168, 161, 254, 162, 165, 168, 183, 161, 232, 180, 168, 165, 176, 162, 171, 182, 169, 254, 227, 147, 173, 170, 160, 171, 179, 183, 227, 232, 163, 161, 176, 140, 173, 163, 172, 129, 170, 176, 182, 171, 180, 189, 146, 165, 168, 177, 161, 183, 254, 162, 177, 170, 167, 176, 173, 171, 170, 236, 237, 191, 182, 161, 176, 177, 182, 170, 228, 148, 182, 171, 169, 173, 183, 161, 234, 182, 161, 183, 171, 168, 178, 161, 236, 191, 165, 182, 167, 172, 173, 176, 161, 167, 176, 177, 182, 161, 254, 227, 188, 252, 242, 227, 232, 166, 173, 176, 170, 161, 183, 183, 254, 227, 242, 240, 227, 232, 169, 171, 166, 173, 168, 161, 254, 162, 165, 168, 183, 161, 232, 169, 171, 160, 161, 168, 254, 227, 227, 232, 180, 168, 165, 176, 162, 171, 182, 169, 254, 227, 147, 173, 170, 160, 171, 179, 183, 227, 232, 180, 168, 165, 176, 162, 171, 182, 169, 146, 161, 182, 183, 173, 171, 170, 254, 227, 245, 241, 234, 244, 234, 244, 227, 232, 177, 165, 130, 177, 168, 168, 146, 161, 182, 183, 173, 171, 170, 254, 227, 245, 246, 244, 234, 244, 234, 244, 234, 244, 227, 185, 237, 255, 185, 185, 255, 139, 166, 174, 161, 167, 176, 234, 160, 161, 162, 173, 170, 161, 148, 182, 171, 180, 161, 182, 176, 189, 236, 180, 182, 171, 176, 171, 232, 227, 177, 183, 161, 182, 133, 163, 161, 170, 176, 128, 165, 176, 165, 227, 232, 191, 163, 161, 176, 254, 162, 177, 170, 167, 176, 173, 171, 170, 236, 237, 191, 182, 161, 176, 177, 182, 170, 228, 177, 165, 160, 255, 185, 232, 167, 171, 170, 162, 173, 163, 177, 182, 165, 166, 168, 161, 254, 176, 182, 177, 161, 185, 237, 255, 185, 167, 165, 176, 167, 172, 236, 161, 237, 191, 185 }, 196) + _0xc4b9e23f._0x50c41416(new byte[112] { 87, 86, 85, 27, 64, 80, 65, 86, 86, 93, 31, 20, 68, 90, 87, 71, 91, 20, 31, 2, 10, 1, 3, 26, 8, 87, 86, 85, 27, 64, 80, 65, 86, 86, 93, 31, 20, 91, 86, 90, 84, 91, 71, 20, 31, 2, 3, 11, 3, 26, 8, 87, 86, 85, 27, 64, 80, 65, 86, 86, 93, 31, 20, 82, 69, 82, 90, 95, 100, 90, 87, 71, 91, 20, 31, 2, 10, 1, 3, 26, 8, 87, 86, 85, 27, 64, 80, 65, 86, 86, 93, 31, 20, 82, 69, 82, 90, 95, 123, 86, 90, 84, 91, 71, 20, 31, 2, 3, 7, 3, 26, 8 }, 51) + _0xc4b9e23f._0x50c41416(new byte[45] { 147, 149, 158, 156, 144, 142, 137, 131, 136, 144, 201, 136, 137, 147, 136, 146, 132, 143, 148, 147, 134, 149, 147, 218, 146, 137, 131, 130, 129, 142, 137, 130, 131, 220, 154, 132, 134, 147, 132, 143, 207, 130, 206, 156, 154 }, 231) + _0xc4b9e23f._0x50c41416(new byte[721] { 130, 132, 143, 141, 128, 151, 132, 214, 153, 132, 159, 145, 203, 129, 159, 152, 146, 153, 129, 216, 155, 151, 130, 149, 158, 187, 147, 146, 159, 151, 216, 148, 159, 152, 146, 222, 129, 159, 152, 146, 153, 129, 223, 205, 129, 159, 152, 146, 153, 129, 216, 155, 151, 130, 149, 158, 187, 147, 146, 159, 151, 203, 144, 131, 152, 149, 130, 159, 153, 152, 222, 135, 223, 141, 128, 151, 132, 214, 133, 203, 165, 130, 132, 159, 152, 145, 222, 135, 223, 216, 130, 153, 186, 153, 129, 147, 132, 181, 151, 133, 147, 222, 223, 205, 159, 144, 222, 133, 216, 159, 152, 146, 147, 142, 185, 144, 222, 209, 134, 153, 159, 152, 130, 147, 132, 204, 214, 149, 153, 151, 132, 133, 147, 209, 223, 200, 203, 198, 138, 138, 133, 216, 159, 152, 146, 147, 142, 185, 144, 222, 209, 158, 153, 128, 147, 132, 204, 214, 152, 153, 152, 147, 209, 223, 200, 203, 198, 138, 138, 133, 216, 159, 152, 146, 147, 142, 185, 144, 222, 209, 155, 151, 142, 219, 129, 159, 146, 130, 158, 209, 223, 200, 203, 198, 138, 138, 133, 216, 159, 152, 146, 147, 142, 185, 144, 222, 209, 155, 151, 142, 219, 146, 147, 128, 159, 149, 147, 219, 129, 159, 146, 130, 158, 209, 223, 200, 203, 198, 223, 132, 147, 130, 131, 132, 152, 214, 141, 155, 151, 130, 149, 158, 147, 133, 204, 144, 151, 154, 133, 147, 218, 155, 147, 146, 159, 151, 204, 135, 218, 153, 152, 149, 158, 151, 152, 145, 147, 204, 152, 131, 154, 154, 218, 151, 146, 146, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 132, 147, 155, 153, 128, 147, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 151, 146, 146, 179, 128, 147, 152, 130, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 132, 147, 155, 153, 128, 147, 179, 128, 147, 152, 130, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 146, 159, 133, 134, 151, 130, 149, 158, 179, 128, 147, 152, 130, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 132, 147, 130, 131, 132, 152, 214, 144, 151, 154, 133, 147, 205, 139, 139, 205, 159, 144, 222, 133, 216, 159, 152, 146, 147, 142, 185, 144, 222, 209, 134, 153, 159, 152, 130, 147, 132, 204, 214, 144, 159, 152, 147, 209, 223, 200, 203, 198, 138, 138, 133, 216, 159, 152, 146, 147, 142, 185, 144, 222, 209, 158, 153, 128, 147, 132, 204, 214, 158, 153, 128, 147, 132, 209, 223, 200, 203, 198, 223, 132, 147, 130, 131, 132, 152, 214, 141, 155, 151, 130, 149, 158, 147, 133, 204, 130, 132, 131, 147, 218, 155, 147, 146, 159, 151, 204, 135, 218, 153, 152, 149, 158, 151, 152, 145, 147, 204, 152, 131, 154, 154, 218, 151, 146, 146, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 132, 147, 155, 153, 128, 147, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 151, 146, 146, 179, 128, 147, 152, 130, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 132, 147, 155, 153, 128, 147, 179, 128, 147, 152, 130, 186, 159, 133, 130, 147, 152, 147, 132, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 139, 218, 146, 159, 133, 134, 151, 130, 149, 158, 179, 128, 147, 152, 130, 204, 144, 131, 152, 149, 130, 159, 153, 152, 222, 223, 141, 132, 147, 130, 131, 132, 152, 214, 144, 151, 154, 133, 147, 205, 139, 139, 205, 132, 147, 130, 131, 132, 152, 214, 153, 132, 159, 145, 222, 135, 223, 205, 139, 205, 139, 149, 151, 130, 149, 158, 222, 147, 223, 141, 139 }, 246) + _0xc4b9e23f._0x50c41416(new byte[5] { 72, 28, 29, 28, 14 }, 53);
    }

    private AndroidJavaObject _0x1401db4a { get; set; }

    private GameObject _0x13fac4f3;
    private string _0x75ab3f25()
    {
        string _0x91c8ed91 = _0xef01bce6();
        if (string.IsNullOrEmpty(_0x91c8ed91))
            return _0xc4b9e23f._0x50c41416(new byte[7] { 235, 242, 244, 249, 189, 173, 166 }, 157);
        string _0xc69db01d = _0x91c8ed91.Replace(_0xc4b9e23f._0x50c41416(new byte[1] { 51 }, 111), _0xc4b9e23f._0x50c41416(new byte[2] { 201, 201 }, 149)).Replace(_0xc4b9e23f._0x50c41416(new byte[1] { 134 }, 161), _0xc4b9e23f._0x50c41416(new byte[2] { 239, 148 }, 179));
        var _0x8975d77f = Regex.Match(_0x91c8ed91, _0xc4b9e23f._0x50c41416(new byte[12] { 40, 3, 25, 4, 6, 14, 68, 67, 55, 15, 64, 66 }, 107));
        string _0xdd9dc94c = _0x8975d77f.Success ? _0x8975d77f.Groups[1].Value : _0xc4b9e23f._0x50c41416(new byte[3] { 182, 181, 183 }, 135);
        return _0xc4b9e23f._0x50c41416(new byte[12] { 26, 84, 71, 92, 81, 70, 91, 93, 92, 26, 27, 73 }, 50) + _0xc4b9e23f._0x50c41416(new byte[8] { 243, 228, 247, 165, 240, 228, 184, 162 }, 133) + _0xc69db01d + _0xc4b9e23f._0x50c41416(new byte[2] { 237, 241 }, 202) + _0xc4b9e23f._0x50c41416(new byte[30] { 39, 48, 35, 113, 33, 35, 62, 37, 62, 108, 31, 48, 39, 56, 54, 48, 37, 62, 35, 127, 33, 35, 62, 37, 62, 37, 40, 33, 52, 106 }, 81) + _0xc4b9e23f._0x50c41416(new byte[121] { 120, 107, 112, 125, 106, 119, 113, 112, 62, 122, 123, 120, 54, 113, 124, 116, 50, 117, 123, 103, 50, 104, 127, 114, 55, 101, 106, 108, 103, 101, 81, 124, 116, 123, 125, 106, 48, 122, 123, 120, 119, 112, 123, 78, 108, 113, 110, 123, 108, 106, 103, 54, 113, 124, 116, 50, 117, 123, 103, 50, 101, 121, 123, 106, 36, 120, 107, 112, 125, 106, 119, 113, 112, 54, 55, 101, 108, 123, 106, 107, 108, 112, 62, 104, 127, 114, 37, 99, 50, 125, 113, 112, 120, 119, 121, 107, 108, 127, 124, 114, 123, 36, 106, 108, 107, 123, 99, 55, 37, 99, 125, 127, 106, 125, 118, 54, 123, 55, 101, 99, 99 }, 30) + _0xc4b9e23f._0x50c41416(new byte[26] { 132, 133, 134, 200, 144, 146, 143, 148, 143, 204, 199, 149, 147, 133, 146, 161, 135, 133, 142, 148, 199, 204, 149, 129, 201, 219 }, 224) + _0xc4b9e23f._0x50c41416(new byte[52] { 22, 23, 20, 90, 2, 0, 29, 6, 29, 94, 85, 19, 2, 2, 36, 23, 0, 1, 27, 29, 28, 85, 94, 7, 19, 92, 0, 23, 2, 30, 19, 17, 23, 90, 93, 44, 63, 29, 8, 27, 30, 30, 19, 46, 93, 93, 94, 85, 85, 91, 91, 73 }, 114) + _0xc4b9e23f._0x50c41416(new byte[37] { 173, 172, 175, 225, 185, 187, 166, 189, 166, 229, 238, 185, 165, 168, 189, 175, 166, 187, 164, 238, 229, 238, 133, 160, 167, 188, 177, 233, 168, 187, 164, 191, 241, 165, 238, 224, 242 }, 201) + _0xc4b9e23f._0x50c41416(new byte[34] { 50, 51, 48, 126, 38, 36, 57, 34, 57, 122, 113, 32, 51, 56, 50, 57, 36, 113, 122, 113, 17, 57, 57, 49, 58, 51, 118, 31, 56, 53, 120, 113, 127, 109 }, 86) + _0xc4b9e23f._0x50c41416(new byte[30] { 159, 158, 157, 211, 139, 137, 148, 143, 148, 215, 220, 150, 154, 131, 175, 148, 142, 152, 147, 171, 148, 146, 149, 143, 136, 220, 215, 206, 210, 192 }, 251) + _0xc4b9e23f._0x50c41416(new byte[48] { 85, 83, 88, 90, 87, 64, 83, 1, 84, 64, 69, 28, 90, 67, 83, 64, 79, 69, 82, 27, 122, 90, 67, 83, 64, 79, 69, 27, 6, 98, 73, 83, 78, 76, 72, 84, 76, 6, 13, 87, 68, 83, 82, 72, 78, 79, 27, 6 }, 33) + _0xdd9dc94c + _0xc4b9e23f._0x50c41416(new byte[35] { 211, 137, 216, 143, 150, 134, 149, 154, 144, 206, 211, 179, 155, 155, 147, 152, 145, 212, 183, 156, 134, 155, 153, 145, 211, 216, 130, 145, 134, 135, 157, 155, 154, 206, 211 }, 244) + _0xdd9dc94c + _0xc4b9e23f._0x50c41416(new byte[238] { 162, 248, 169, 254, 231, 247, 228, 235, 225, 191, 162, 203, 234, 241, 184, 196, 186, 199, 247, 228, 235, 225, 162, 169, 243, 224, 247, 246, 236, 234, 235, 191, 162, 183, 177, 162, 248, 216, 169, 232, 234, 231, 236, 233, 224, 191, 241, 247, 240, 224, 169, 245, 233, 228, 241, 227, 234, 247, 232, 191, 162, 196, 235, 225, 247, 234, 236, 225, 162, 169, 226, 224, 241, 205, 236, 226, 237, 192, 235, 241, 247, 234, 245, 252, 211, 228, 233, 240, 224, 246, 191, 227, 240, 235, 230, 241, 236, 234, 235, 173, 172, 254, 247, 224, 241, 240, 247, 235, 165, 213, 247, 234, 232, 236, 246, 224, 171, 247, 224, 246, 234, 233, 243, 224, 173, 254, 228, 247, 230, 237, 236, 241, 224, 230, 241, 240, 247, 224, 191, 162, 228, 247, 232, 162, 169, 231, 236, 241, 235, 224, 246, 246, 191, 162, 179, 177, 162, 169, 232, 234, 231, 236, 233, 224, 191, 241, 247, 240, 224, 169, 232, 234, 225, 224, 233, 191, 162, 162, 169, 245, 233, 228, 241, 227, 234, 247, 232, 191, 162, 196, 235, 225, 247, 234, 236, 225, 162, 169, 245, 233, 228, 241, 227, 234, 247, 232, 211, 224, 247, 246, 236, 234, 235, 191, 162, 180, 177, 171, 181, 171, 181, 162, 169, 240, 228, 195, 240, 233, 233, 211, 224, 247, 246, 236, 234, 235, 191, 162 }, 133) + _0xdd9dc94c + _0xc4b9e23f._0x50c41416(new byte[117] { 10, 20, 10, 20, 10, 20, 3, 89, 13, 31, 89, 89, 31, 107, 70, 78, 65, 71, 80, 10, 64, 65, 66, 77, 74, 65, 116, 86, 75, 84, 65, 86, 80, 93, 12, 84, 86, 75, 80, 75, 8, 3, 81, 87, 65, 86, 101, 67, 65, 74, 80, 96, 69, 80, 69, 3, 8, 95, 67, 65, 80, 30, 66, 81, 74, 71, 80, 77, 75, 74, 12, 13, 95, 86, 65, 80, 81, 86, 74, 4, 81, 69, 64, 31, 89, 8, 71, 75, 74, 66, 77, 67, 81, 86, 69, 70, 72, 65, 30, 80, 86, 81, 65, 89, 13, 31, 89, 71, 69, 80, 71, 76, 12, 65, 13, 95, 89 }, 36) + _0xc4b9e23f._0x50c41416(new byte[5] { 90, 14, 15, 14, 28 }, 39);
    }

    private IEnumerator _0x39064db1(float _0x8b317cd6)
    {
        yield return new WaitForSeconds(_0x8b317cd6);
        if (!_0xd05d0799)
        {
            _0xd05d0799 = true;
            {
#if B_LOGS
                {
                    Debug.Log($"[Test] Refferer timeout apply: {_0x7b976bc1}");
                }
#endif
            }
        }
    }

    private Task _0xdfd6291f(IEnumerator _0xd4e629d5)
    {
        var _0x04dd170c = new TaskCompletionSource<bool>();
        StartCoroutine(_0xebbfa16f(_0xd4e629d5, _0x04dd170c));
        return _0x04dd170c.Task;
    }

    private string _0xec9de758 = "";
    private string Decrypt(string _0xf7bc5f8e, string _0xf0b4c8a1)
    {
        try
        {
            var _0x884f0bf1 = Convert.FromBase64String(_0xf7bc5f8e);
            using var _0xd4c8b1ad = Aes.Create();
            _0xd4c8b1ad.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0xf0b4c8a1));
            var _0xf17e0bbf = new byte[16];
            Buffer.BlockCopy(_0x884f0bf1, 0, _0xf17e0bbf, 0, 16);
            _0xd4c8b1ad.IV = _0xf17e0bbf;
            using var _0x4ac25795 = new MemoryStream(_0x884f0bf1, 16, _0x884f0bf1.Length - 16);
            using var _0x8df17d1e = new CryptoStream(_0x4ac25795, _0xd4c8b1ad.CreateDecryptor(), CryptoStreamMode.Read);
            using var _0x137ac9c7 = new StreamReader(_0x8df17d1e, Encoding.UTF8);
            return _0x137ac9c7.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public void _0xa16d7b56()
    {
        if (_0x936330f6)
            return;
        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[33] { 85, 90, 107, 125, 122, 83, 46, 90, 103, 99, 107, 124, 46, 97, 123, 122, 46, 35, 48, 46, 99, 97, 120, 107, 46, 122, 97, 46, 125, 109, 107, 96, 107 }, 14));
            }
#endif
        }

        _0xbb066f8e();
    }

    private IEnumerator _0x82dac273()
    {
        yield return RequestAndroidPermissionIfNeeded(Permission.Camera);
    }

    private bool TryOpenExternalLikeChrome(string _0xed4796a0)
    {
        if (string.IsNullOrEmpty(_0xed4796a0))
            return false;
        if (_0xed4796a0.StartsWith(_0xc4b9e23f._0x50c41416(new byte[9] { 239, 232, 242, 227, 232, 242, 188, 169, 169 }, 134), StringComparison.OrdinalIgnoreCase))
            return _0xab7b6cd2(_0xed4796a0);
        if (_0x16be0954(_0xed4796a0))
            return _0xfe48ce99(_0xed4796a0, null);
        if (!_0xed4796a0.StartsWith(_0xc4b9e23f._0x50c41416(new byte[7] { 54, 42, 42, 46, 100, 113, 113 }, 94), StringComparison.OrdinalIgnoreCase) && !_0xed4796a0.StartsWith(_0xc4b9e23f._0x50c41416(new byte[8] { 98, 126, 126, 122, 121, 48, 37, 37 }, 10), StringComparison.OrdinalIgnoreCase) && !_0xed4796a0.StartsWith(_0xc4b9e23f._0x50c41416(new byte[11] { 54, 53, 56, 34, 35, 109, 53, 59, 54, 57, 60 }, 87), StringComparison.OrdinalIgnoreCase))
        {
            return _0xfa20af44(_0xed4796a0);
        }

        return false;
    }

    private bool _0xab7b6cd2(string _0x2e204d92)
    {
        try
        {
            using (var _0xccfca1de = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[30] { 233, 229, 231, 164, 255, 228, 227, 254, 243, 185, 238, 164, 250, 230, 235, 243, 239, 248, 164, 223, 228, 227, 254, 243, 218, 230, 235, 243, 239, 248 }, 138)))
            using (var _0xeb6c4f1e = _0xccfca1de.GetStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 12, 26, 29, 29, 10, 1, 27, 46, 12, 27, 6, 25, 6, 27, 22 }, 111)))
            using (var _0x4222b06b = _0xeb6c4f1e.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[17] { 234, 232, 249, 221, 236, 238, 230, 236, 234, 232, 192, 236, 227, 236, 234, 232, 255 }, 141)))
            using (var _0x1cdaddd7 = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[22] { 193, 206, 196, 210, 207, 201, 196, 142, 195, 207, 206, 212, 197, 206, 212, 142, 233, 206, 212, 197, 206, 212 }, 160)))
            using (var _0xab03e013 = _0x1cdaddd7.CallStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[8] { 226, 243, 224, 225, 247, 199, 224, 251 }, 146), _0x2e204d92, 1))
            {
                string _0x7375fc7e = _0xab03e013.Call<string>(_0xc4b9e23f._0x50c41416(new byte[14] { 139, 137, 152, 191, 152, 158, 133, 130, 139, 169, 148, 152, 158, 141 }, 236), _0xc4b9e23f._0x50c41416(new byte[20] { 19, 3, 30, 6, 2, 20, 3, 46, 23, 16, 29, 29, 19, 16, 18, 26, 46, 4, 3, 29 }, 113));
                string _0x6f6b5106 = _0xab03e013.Call<string>(_0xc4b9e23f._0x50c41416(new byte[10] { 58, 56, 41, 13, 60, 62, 54, 60, 58, 56 }, 93));
                _0xab03e013.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[11] { 237, 232, 232, 207, 237, 248, 233, 235, 227, 254, 245 }, 140), _0xc4b9e23f._0x50c41416(new byte[33] { 155, 148, 158, 136, 149, 147, 158, 212, 147, 148, 142, 159, 148, 142, 212, 153, 155, 142, 159, 157, 149, 136, 131, 212, 184, 168, 181, 173, 169, 187, 184, 182, 191 }, 250));
                _0xab03e013.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[11] { 241, 230, 238, 236, 245, 230, 198, 251, 247, 241, 226 }, 131), _0xc4b9e23f._0x50c41416(new byte[20] { 43, 59, 38, 62, 58, 44, 59, 22, 47, 40, 37, 37, 43, 40, 42, 34, 22, 60, 59, 37 }, 73));
                if (_0xab03e013.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 45, 58, 44, 48, 51, 41, 58, 30, 60, 43, 54, 41, 54, 43, 38 }, 95), _0x4222b06b) != null)
                {
                    WLog(_0xc4b9e23f._0x50c41416(new byte[24] { 61, 22, 12, 17, 19, 27, 50, 23, 21, 27, 94, 17, 14, 27, 16, 94, 23, 16, 10, 27, 16, 10, 68, 94 }, 126) + _0x2e204d92);
                    _0xab03e013.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[8] { 149, 144, 144, 178, 152, 149, 147, 135 }, 244), 0x10000000);
                    _0xeb6c4f1e.Call(_0xc4b9e23f._0x50c41416(new byte[13] { 89, 94, 75, 88, 94, 107, 73, 94, 67, 92, 67, 94, 83 }, 42), _0xab03e013);
                    return true;
                }

                if (_0x4880ade8(_0x6f6b5106))
                    return true;
                if (!string.IsNullOrEmpty(_0x7375fc7e))
                {
                    WLog(_0xc4b9e23f._0x50c41416(new byte[28] { 214, 253, 231, 250, 248, 240, 217, 252, 254, 240, 181, 252, 251, 225, 240, 251, 225, 181, 243, 244, 249, 249, 247, 244, 246, 254, 175, 181 }, 149) + _0x7375fc7e);
                    if (_0x16be0954(_0x7375fc7e))
                        return _0xfe48ce99(_0x7375fc7e, _0x6f6b5106);
                    return _0xfa20af44(_0x7375fc7e);
                }

                WLog(_0xc4b9e23f._0x50c41416(new byte[30] { 149, 190, 164, 185, 187, 179, 154, 191, 189, 179, 246, 191, 184, 162, 179, 184, 162, 246, 184, 185, 246, 190, 183, 184, 178, 186, 179, 164, 236, 246 }, 214) + _0x2e204d92);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[26] { 103, 76, 86, 75, 73, 65, 104, 77, 79, 65, 4, 77, 74, 80, 65, 74, 80, 4, 66, 69, 77, 72, 65, 64, 30, 4 }, 36) + e.Message);
            return true;
        }
    }

    private void _0x248815e2(string _0x053ec28d)
    {
        Dictionary<string, object> _0x4e9680c8;
        try
        {
            _0x4e9680c8 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0x053ec28d);
        }
        catch
        {
            return;
        }

        var _0xa44afbb4 = ReadPushField(_0x4e9680c8, _0xc4b9e23f._0x50c41416(new byte[3] { 59, 60, 34 }, 78));
        if (string.IsNullOrWhiteSpace(_0xa44afbb4))
            return;
        _0xa44afbb4 = _0xa44afbb4.Trim();
        if (!IsHttpUrl(_0xa44afbb4))
            return;
        if (string.Equals(_0xa44afbb4, _0x1b09e5a8, StringComparison.Ordinal))
            return;
        _0x1b09e5a8 = _0xa44afbb4;
        OpenUrlExternally(_0xa44afbb4);
    }

    private IEnumerator RequestAndroidPermissionIfNeeded(string _0xc4430786)
    {
        if (Permission.HasUserAuthorizedPermission(_0xc4430786))
            yield break;
        bool _0xf73a47c4 = false;
        var _0xfc2e4813 = new PermissionCallbacks();
        _0xfc2e4813.PermissionGranted += _0xf834c484 => _0xf73a47c4 = true;
        _0xfc2e4813.PermissionDenied += _0xf834c484 => _0xf73a47c4 = true;
        Permission.RequestUserPermission(_0xc4430786, _0xfc2e4813);
        yield return new WaitUntil(() => _0xf73a47c4);
    }

    private static bool IsPrivacyItemTrue(Item _0x3a3c7802)
    {
        if (_0x3a3c7802.Key != _0xc4b9e23f._0x50c41416(new byte[9] { 117, 111, 76, 110, 117, 106, 125, 127, 101 }, 28))
            return false;
        try
        {
            var _0xae5ec91d = _0x3a3c7802.Value.GetAs<object>();
            return _0xae5ec91d switch
            {
                bool b => b,
                string s when bool.TryParse(s, out var parsed) => parsed,
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }

    private void OnApplicationPause(bool _0xc73c3505)
    {
        isApplicationPause = _0xc73c3505;
    }

    private int _0x9df46722 = -1;
    private void OnDestroy()
    {
        StopAllCoroutines();
        _0xbb066f8e();
    }

    private bool _0x999cc648 = false;
    private void _0x5d946420(UniWebView _0xd6e3161b)
    {
        if (_0x008ac9a6)
            return;
        _0x008ac9a6 = true;
        _0xd6e3161b.AddUrlScheme(_0xc4b9e23f._0x50c41416(new byte[2] { 105, 122 }, 29));
        _0xd6e3161b.AddUrlScheme(_0xc4b9e23f._0x50c41416(new byte[6] { 223, 216, 194, 211, 216, 194 }, 182));
        _0xd6e3161b.AddUrlScheme(_0xc4b9e23f._0x50c41416(new byte[6] { 170, 166, 181, 172, 162, 179 }, 199));
        _0xd6e3161b.OnMessageReceived += (_0x4748d4dc, _0xb7b52816) =>
        {
            if (TryOpenExternalLikeChrome(_0xb7b52816.RawMessage))
            {
                _0xecb8ecc4(false);
                return;
            }
        };
        _0xd6e3161b.RegisterShouldHandleRequest(_0x129a8c24 =>
        {
            string _0x52a06a40 = _0x129a8c24 != null ? _0x129a8c24.Url : string.Empty;
            if (string.IsNullOrEmpty(_0x52a06a40))
                return true;
            WLog(_0xc4b9e23f._0x50c41416(new byte[21] { 65, 122, 125, 103, 126, 118, 90, 115, 124, 118, 126, 119, 64, 119, 99, 103, 119, 97, 102, 40, 50 }, 18) + _0x52a06a40);
            if (TryOpenExternalLikeChrome(_0x52a06a40))
            {
                _0xecb8ecc4(false);
                return false;
            }

            if (_0x129a8c24 != null && _0x129a8c24.IsMainFrame && IsGoogleAuthFlowUrl(_0x52a06a40) && !_0x999cc648)
            {
                WLog(_0xc4b9e23f._0x50c41416(new byte[62] { 191, 147, 155, 156, 210, 165, 151, 144, 164, 155, 151, 133, 210, 150, 151, 134, 151, 145, 134, 151, 150, 210, 181, 157, 157, 149, 158, 151, 210, 147, 135, 134, 154, 210, 167, 160, 190, 210, 223, 204, 210, 128, 151, 158, 157, 147, 150, 210, 133, 155, 134, 154, 210, 181, 157, 157, 149, 158, 151, 210, 167, 179 }, 242));
                _0x999cc648 = true;
                _0xecb8ecc4(true);
                _0x93930a98.SetUserAgent(_0xef01bce6());
                _0x93930a98.Load(_0x52a06a40);
                return false;
            }

            return true;
        });
        _0xd6e3161b.OnLoadingErrorReceived += (_0x4748d4dc, _0x968913ba, _0xb7b52816, _0x9728278f) =>
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[25] { 60, 16, 24, 31, 81, 38, 20, 19, 39, 24, 20, 6, 81, 52, 3, 3, 30, 3, 75, 81, 18, 30, 21, 20, 76 }, 113) + _0x968913ba + _0xc4b9e23f._0x50c41416(new byte[9] { 49, 124, 116, 98, 98, 112, 118, 116, 44 }, 17) + _0xb7b52816);
            string _0xd0c970e1 = GetFailingUrl(_0x9728278f);
            if (string.IsNullOrEmpty(_0xd0c970e1) || IsAboutBlank(_0xd0c970e1))
                return;
            _ = _0x54bf2974(_0xc4b9e23f._0x50c41416(new byte[8] { 1, 0, 41, 19, 4, 4, 25, 4 }, 118));
            WLog(_0xc4b9e23f._0x50c41416(new byte[45] { 44, 0, 8, 15, 65, 54, 4, 3, 55, 8, 4, 22, 65, 7, 0, 8, 13, 8, 15, 6, 65, 52, 51, 45, 65, 76, 95, 65, 14, 17, 4, 15, 65, 4, 25, 21, 4, 19, 15, 0, 13, 13, 24, 91, 65 }, 97) + _0xd0c970e1);
            StopCurrentFailedLoad(_0x4748d4dc);
            _0xfec2e4cf(_0xd0c970e1);
        };
        _0xd6e3161b.OnPageStarted += (_0x4748d4dc, _0xd9c5480b) =>
        {
            _0xfc2ff2db = 0;
            if (_0xcb861229 && IsAboutBlank(_0xd9c5480b))
            {
                WLog(_0xc4b9e23f._0x50c41416(new byte[27] { 64, 98, 117, 103, 113, 98, 125, 48, 113, 114, 127, 101, 100, 42, 114, 124, 113, 126, 123, 48, 99, 100, 113, 98, 100, 117, 116 }, 16));
                return;
            }

            WLog(_0xc4b9e23f._0x50c41416(new byte[29] { 14, 34, 42, 45, 99, 20, 38, 33, 21, 42, 38, 52, 99, 12, 45, 19, 34, 36, 38, 16, 55, 34, 49, 55, 38, 39, 121, 99, 104 }, 67) + (Time.realtimeSinceStartup - _0x0167ec95).ToString(_0xc4b9e23f._0x50c41416(new byte[5] { 154, 132, 154, 154, 154 }, 170)) + _0xc4b9e23f._0x50c41416(new byte[2] { 103, 52 }, 20) + _0xd9c5480b);
            if (TryOpenExternalLikeChrome(_0xd9c5480b))
            {
                StopCurrentFailedLoad(_0x4748d4dc);
                return;
            }

            if (ContainsIgnoreCase(_0xd9c5480b, _0xc4b9e23f._0x50c41416(new byte[8] { 152, 149, 149, 157, 210, 157, 140, 140 }, 252)) || ContainsIgnoreCase(_0xd9c5480b, _0xc4b9e23f._0x50c41416(new byte[15] { 177, 160, 184, 239, 182, 168, 165, 166, 164, 181, 239, 163, 173, 174, 166 }, 193)) || _0xd9c5480b.StartsWith(_0xc4b9e23f._0x50c41416(new byte[25] { 158, 130, 130, 134, 133, 204, 217, 217, 148, 134, 145, 154, 153, 148, 151, 154, 144, 151, 128, 216, 154, 159, 128, 147, 217 }, 246), StringComparison.OrdinalIgnoreCase))
            {
                StopCurrentFailedLoad(_0x4748d4dc);
                OpenUrlExternally(_0xd9c5480b);
                return;
            }

            if (IsGoogleAuthFlowUrl(_0xd9c5480b))
            {
                _0xecb8ecc4(true);
                WLog(_0xc4b9e23f._0x50c41416(new byte[41] { 109, 69, 69, 77, 70, 79, 10, 75, 95, 94, 66, 10, 76, 70, 69, 93, 10, 78, 79, 94, 79, 73, 94, 79, 78, 10, 7, 20, 10, 65, 79, 79, 90, 10, 92, 67, 89, 67, 72, 70, 79 }, 42));
                return;
            }

            _0xddd8c26c = true;
            _0xecb8ecc4(true);
            WLog(_0xc4b9e23f._0x50c41416(new byte[43] { 234, 216, 223, 235, 212, 216, 202, 157, 209, 210, 220, 217, 212, 211, 218, 146, 207, 216, 217, 212, 207, 216, 222, 201, 212, 211, 218, 157, 144, 131, 157, 214, 216, 216, 205, 157, 203, 212, 206, 212, 223, 209, 216 }, 189));
        };
        _0xd6e3161b.OnPageCommitted += (_0x4748d4dc, _0xd9c5480b) =>
        {
            if (_0xcb861229 && IsAboutBlank(_0xd9c5480b))
                return;
            WLog(_0xc4b9e23f._0x50c41416(new byte[31] { 125, 81, 89, 94, 16, 103, 85, 82, 102, 89, 85, 71, 16, 127, 94, 96, 81, 87, 85, 115, 95, 93, 93, 89, 68, 68, 85, 84, 10, 16, 27 }, 48) + (Time.realtimeSinceStartup - _0x0167ec95).ToString(_0xc4b9e23f._0x50c41416(new byte[5] { 64, 94, 64, 64, 64 }, 112)) + _0xc4b9e23f._0x50c41416(new byte[2] { 102, 53 }, 21) + _0xd9c5480b);
            if (!firstLoadShown && IsHttpUrl(_0xd9c5480b))
            {
                firstLoadShown = true;
                _0xddd8c26c = false;
                _0xecb8ecc4(false);
                _0x9babd2c1();
                _0xcb7bdc1c();
                _0x4748d4dc.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x54bf2974(_0xc4b9e23f._0x50c41416(new byte[9] { 74, 75, 98, 82, 77, 88, 83, 88, 89 }, 61));
                WLog(_0xc4b9e23f._0x50c41416(new byte[39] { 22, 58, 50, 53, 123, 12, 62, 57, 13, 50, 62, 44, 123, 40, 51, 52, 44, 53, 123, 52, 53, 123, 56, 52, 54, 54, 50, 47, 47, 62, 63, 123, 56, 52, 53, 47, 62, 53, 47 }, 91));
            }
        };
        _0xd6e3161b.OnPageProgressChanged += (_0x4748d4dc, _0xc565a1d7) =>
        {
            if (_0xcb861229)
                return;
            if (!firstLoadShown && _0xc565a1d7 >= 0.65f)
            {
                firstLoadShown = true;
                _0xddd8c26c = false;
                _0xecb8ecc4(false);
                _0x9babd2c1();
                _0xcb7bdc1c();
                _0x4748d4dc.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x54bf2974(_0xc4b9e23f._0x50c41416(new byte[9] { 14, 15, 38, 22, 9, 28, 23, 28, 29 }, 121));
                WLog(_0xc4b9e23f._0x50c41416(new byte[32] { 155, 183, 191, 184, 246, 129, 179, 180, 128, 191, 179, 161, 246, 165, 190, 185, 161, 184, 246, 180, 175, 246, 166, 164, 185, 177, 164, 179, 165, 165, 236, 246 }, 214) + _0xc565a1d7);
            }
        };
        _0xd6e3161b.OnPageFinished += (_0x4748d4dc, _0x968913ba, _0xd9c5480b) =>
        {
            if (_0xcb861229 && IsAboutBlank(_0xd9c5480b))
            {
                _0xcb861229 = false;
                WLog(_0xc4b9e23f._0x50c41416(new byte[28] { 197, 231, 240, 226, 244, 231, 248, 181, 244, 247, 250, 224, 225, 175, 247, 249, 244, 251, 254, 181, 243, 252, 251, 252, 230, 253, 240, 241 }, 149));
                return;
            }

            WLog(_0xc4b9e23f._0x50c41416(new byte[24] { 69, 105, 97, 102, 40, 95, 109, 106, 94, 97, 109, 127, 40, 78, 97, 102, 97, 123, 96, 109, 108, 50, 40, 35 }, 8) + (Time.realtimeSinceStartup - _0x0167ec95).ToString(_0xc4b9e23f._0x50c41416(new byte[5] { 31, 1, 31, 31, 31 }, 47)) + _0xc4b9e23f._0x50c41416(new byte[7] { 143, 220, 159, 147, 152, 153, 193 }, 252) + _0x968913ba + _0xc4b9e23f._0x50c41416(new byte[5] { 87, 2, 5, 27, 74 }, 119) + _0xd9c5480b);
            if (!firstLoadShown)
            {
                firstLoadShown = true;
                _0xddd8c26c = false;
                _0xecb8ecc4(false);
                _0x9babd2c1();
                _0xcb7bdc1c();
                _0x4748d4dc.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x54bf2974(_0xc4b9e23f._0x50c41416(new byte[9] { 217, 216, 241, 193, 222, 203, 192, 203, 202 }, 174));
                WLog(_0xc4b9e23f._0x50c41416(new byte[33] { 119, 91, 83, 84, 26, 109, 95, 88, 108, 83, 95, 77, 26, 92, 83, 72, 73, 78, 26, 86, 85, 91, 94, 26, 89, 85, 87, 74, 86, 95, 78, 95, 94 }, 58));
            }
            else if (_0xddd8c26c)
            {
                _0xddd8c26c = false;
                _0xecb8ecc4(false);
                _0x4748d4dc.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                WLog(_0xc4b9e23f._0x50c41416(new byte[40] { 246, 218, 210, 213, 155, 236, 222, 217, 237, 210, 222, 204, 155, 232, 211, 212, 204, 155, 218, 221, 207, 222, 201, 155, 215, 212, 218, 223, 210, 213, 220, 155, 221, 210, 213, 210, 200, 211, 222, 223 }, 187));
            }
            else
            {
                _0xecb8ecc4(false);
            }

            if (_0x999cc648 && !IsGoogleAuthFlowUrl(_0xd9c5480b) && !IsGoogleAuthFlowUrl(_0xd9c5480b))
            {
                WLog(_0xc4b9e23f._0x50c41416(new byte[48] { 124, 84, 84, 92, 87, 94, 27, 90, 78, 79, 83, 27, 72, 94, 94, 86, 72, 27, 93, 82, 85, 82, 72, 83, 94, 95, 27, 22, 5, 27, 73, 94, 72, 79, 84, 73, 94, 27, 95, 94, 93, 90, 78, 87, 79, 27, 110, 122 }, 59));
                _0x999cc648 = false;
                _0x93930a98.SetUserAgent("");
            }
        };
        _0xd6e3161b.OnShouldClose += _0x4748d4dc =>
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[41] { 54, 57, 8, 30, 25, 48, 77, 32, 12, 4, 3, 77, 58, 8, 15, 59, 4, 8, 26, 77, 34, 3, 62, 5, 2, 24, 1, 9, 46, 1, 2, 30, 8, 77, 4, 3, 27, 2, 6, 8, 9 }, 109));
            _0x445b0684();
            return false;
        };
        // POPUP HANDLING LOGIC
        _0xd6e3161b.SetPopupPageEventEnabled(true);
        bool _0x18aa43b8 = false;
        bool _0x44bf7522 = false;
        _0xd6e3161b.OnMultipleWindowOpened += (_0x4748d4dc, _0x20420f0a) =>
        {
            _0x4748d4dc.ScrollTo(0, 0, false);
            WLog(_0xc4b9e23f._0x50c41416(new byte[43] { 227, 236, 221, 203, 204, 229, 152, 245, 217, 209, 214, 152, 239, 221, 218, 238, 209, 221, 207, 152, 245, 205, 212, 204, 209, 200, 212, 221, 239, 209, 214, 220, 215, 207, 152, 247, 200, 221, 214, 221, 220, 130, 152 }, 184) + _0x20420f0a);
            var _0x1157bef7 = _0xd6e3161b.GetPopupWindow(_0x20420f0a);
            if (_0x1157bef7 == null)
                return;
            _0x9f92c081.Add(_0x1157bef7);
            Debug.Log($"[Test] Popup ID: {_0x1157bef7.Id}");
            _0x1157bef7.OnPageStarted += (_0xcf28fe75, _0xd9c5480b) =>
            {
                WLog(_0xc4b9e23f._0x50c41416(new byte[36] { 158, 145, 160, 182, 177, 152, 229, 149, 170, 181, 176, 181, 229, 146, 160, 167, 147, 172, 160, 178, 229, 138, 171, 149, 164, 162, 160, 150, 177, 164, 183, 177, 160, 161, 255, 229 }, 197) + _0xd9c5480b);
                _0xfc2ff2db = 0;
                if (string.IsNullOrEmpty(_0xd9c5480b) || IsAboutBlank(_0xd9c5480b))
                    return;
                if (IsGoogleAuthFlowUrl(_0xd9c5480b))
                {
                    WLog(_0xc4b9e23f._0x50c41416(new byte[57] { 212, 219, 234, 252, 251, 210, 175, 223, 224, 255, 250, 255, 175, 200, 224, 224, 232, 227, 234, 175, 238, 250, 251, 231, 175, 233, 227, 224, 248, 175, 162, 177, 175, 252, 255, 224, 224, 233, 175, 200, 224, 224, 232, 227, 234, 175, 204, 231, 253, 224, 226, 234, 175, 218, 206, 181, 175 }, 143) + _0xd9c5480b);
                    _0x18aa43b8 = false;
                    _0x2ae14c8b();
                    if (_0xcf28fe75 != null && _0xcf28fe75.IsAlive)
                        _0xcf28fe75.EvaluateJavaScript(_0x75ab3f25());
                    return;
                }

                if (_0x93930a98 == null)
                    return;
                if (!_0x18aa43b8)
                {
                    _0x18aa43b8 = true;
                    _0x93930a98.SetUserAgent(WindowsDesktopUserAgent);
                    WLog(_0xc4b9e23f._0x50c41416(new byte[39] { 196, 203, 250, 236, 235, 194, 191, 207, 240, 239, 234, 239, 191, 254, 239, 239, 243, 230, 191, 200, 246, 241, 251, 240, 232, 236, 191, 251, 250, 236, 244, 235, 240, 239, 191, 202, 222, 165, 191 }, 159) + _0xd9c5480b);
                }

                if (_0xcf28fe75 != null && _0xcf28fe75.IsAlive)
                    _0xcf28fe75.EvaluateJavaScript(_0xe0826c2f());
                if (!_0x44bf7522 && _0xcf28fe75 != null && _0xcf28fe75.IsAlive && IsHttpUrl(_0xd9c5480b))
                {
                    _0x44bf7522 = true;
                }
            };
            _0x1157bef7.OnPageFinished += (_0xcf28fe75, _0x9728278f) =>
            {
                string _0x8db97ae1 = _0x9728278f != null ? _0x9728278f.data : string.Empty;
                WLog(_0xc4b9e23f._0x50c41416(new byte[35] { 32, 47, 30, 8, 15, 38, 91, 43, 20, 11, 14, 11, 91, 44, 30, 25, 45, 18, 30, 12, 91, 61, 18, 21, 18, 8, 19, 30, 31, 65, 91, 14, 9, 23, 70 }, 123) + _0x8db97ae1);
                if (_0xcf28fe75 == null || !_0xcf28fe75.IsAlive)
                    return;
                if (IsGoogleAuthFlowUrl(_0x8db97ae1))
                {
                    _0x2ae14c8b();
                    _0xcf28fe75.EvaluateJavaScript(_0x75ab3f25());
                    return;
                }

                if (!_0x18aa43b8)
                    return;
                _0xcf28fe75.EvaluateJavaScript(_0xe0826c2f());
            };
        };
        _0xd6e3161b.OnMultipleWindowClosed += (_0x4748d4dc, _0x20420f0a) =>
        {
            _0x9f92c081.RemoveAll(_0x696dceb8 => _0x696dceb8 == null || _0x696dceb8.Id == _0x20420f0a || !_0x696dceb8.IsAlive);
            _0xecb8ecc4(false);
            if (_0x9f92c081.Count == 0 && _0x93930a98 != null)
            {
                _0x18aa43b8 = false;
                _0x44bf7522 = false;
                _0x7cd03dba();
            }

            WLog(_0xc4b9e23f._0x50c41416(new byte[43] { 59, 52, 5, 19, 20, 61, 64, 45, 1, 9, 14, 64, 55, 5, 2, 54, 9, 5, 23, 64, 45, 21, 12, 20, 9, 16, 12, 5, 55, 9, 14, 4, 15, 23, 64, 35, 12, 15, 19, 5, 4, 90, 64 }, 96) + _0x20420f0a);
        };
        _0xd6e3161b.RegisterOnRequestMediaCapturePermission(_0x129a8c24 =>
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
                return UniWebViewMediaCapturePermissionDecision.Prompt;
            }

            return UniWebViewMediaCapturePermissionDecision.Grant;
        });
    }

    private bool _0x5da73ea8 = false;
    private bool _0x3e91aed1()
    {
        var _0xe942fa9d = _0x4fc78c0b();
        if (_0xe942fa9d == null)
            return false;
        WLog(_0xc4b9e23f._0x50c41416(new byte[31] { 173, 132, 151, 129, 146, 132, 151, 128, 197, 135, 132, 134, 142, 197, 200, 219, 197, 149, 138, 149, 144, 149, 197, 162, 138, 167, 132, 134, 142, 223, 197 }, 229) + _0xe942fa9d.Id);
        _0xe942fa9d.GoBack();
        return true;
    }

    private async Task<bool> _0x65c709a6(int _0x261595c2 = 5, int _0x3b930e58 = 500)
    {
        List<EntityData> _0xbc6bddf1 = new List<EntityData>();
        int _0x0242d4b1 = 0;
        do
        {
            try
            {
                _0xbc6bddf1 = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0xc4b9e23f._0x50c41416(new byte[8] { 92, 64, 77, 85, 73, 94, 101, 72 }, 44), _0xba5b794d, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0xc4b9e23f._0x50c41416(new byte[9] { 131, 153, 186, 152, 131, 156, 139, 137, 147 }, 234) }), new QueryOptions())).ToList();
            }
            catch (Exception e)
            {
                {
#if B_LOGS
                    {
                        Debug.Log(_0xc4b9e23f._0x50c41416(new byte[32] { 27, 20, 37, 51, 52, 29, 96, 49, 53, 37, 50, 57, 1, 51, 57, 46, 35, 18, 37, 51, 53, 44, 52, 51, 96, 37, 50, 50, 47, 50, 122, 96 }, 64) + e.Message);
                    }
#endif
                }
            }

            await Task.Delay(_0x3b930e58);
        }
        while (_0xbc6bddf1.Count == 0 && _0x0242d4b1++ < _0x261595c2);
        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[32] { 197, 202, 251, 237, 234, 195, 190, 215, 237, 206, 236, 247, 232, 255, 253, 231, 190, 207, 235, 251, 236, 231, 190, 236, 251, 237, 235, 242, 234, 237, 164, 190 }, 158) + JsonConvert.SerializeObject(_0xbc6bddf1, Formatting.Indented));
            }
#endif
        }

        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[38] { 23, 24, 41, 63, 56, 17, 108, 5, 63, 28, 62, 37, 58, 45, 47, 53, 108, 29, 57, 41, 62, 53, 108, 62, 41, 63, 57, 32, 56, 63, 108, 47, 35, 57, 34, 56, 118, 108 }, 76) + _0xbc6bddf1.Count);
            }
#endif
        }

        bool _0xe92d19ec = true;
        if (_0xbc6bddf1.Count == 0)
        {
            _0xe92d19ec = false;
        }
        else
        {
            _0xe92d19ec = _0xbc6bddf1.Any(_0x583313a4 => _0x583313a4.Data.Any(IsPrivacyItemTrue));
        }

        {
#if B_LOGS
            {
                Debug.Log(_0xc4b9e23f._0x50c41416(new byte[25] { 219, 212, 229, 243, 244, 221, 160, 201, 243, 208, 242, 233, 246, 225, 227, 249, 160, 242, 229, 243, 245, 236, 244, 186, 160 }, 128) + _0xe92d19ec);
            }
#endif
        }

        return _0xe92d19ec;
    }

    private async Task<bool> _0xff23ee14()
    {
        {
#if B_LOGS
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[29] { 104, 103, 86, 64, 71, 110, 19, 122, 64, 99, 65, 90, 69, 82, 80, 74, 114, 93, 87, 96, 82, 69, 86, 87, 112, 91, 86, 80, 88 }, 51));
#endif
        }

        string _0x73efc403 = "";
        for (int _0x7c05e948 = 0; _0x7c05e948 < 2; _0x7c05e948++)
        {
            if (await _0x65c709a6(1, 100))
            {
                await _0x54bf2974(_0xc4b9e23f._0x50c41416(new byte[7] { 80, 94, 93, 81, 89, 87, 86 }, 50));
                _0xbb066f8e();
                return true;
            }

            _0x73efc403 = await _0x7e78f5e3(1, 100);
            if (!string.IsNullOrEmpty(_0x73efc403))
                break;
        }

        try
        {
            if (!string.IsNullOrEmpty(_0x73efc403))
            {
                if (!string.IsNullOrEmpty(_0x40b3e17c))
                {
                    _0x73efc403 = _0x7283c5fa(_0x73efc403, _0x40b3e17c);
                    {
#if B_LOGS
                        Debug.Log(_0xc4b9e23f._0x50c41416(new byte[53] { 55, 56, 9, 31, 24, 49, 76, 47, 13, 15, 4, 9, 8, 76, 10, 5, 2, 13, 0, 57, 30, 0, 76, 27, 5, 24, 4, 76, 31, 9, 2, 8, 5, 8, 76, 142, 234, 254, 76, 31, 4, 3, 27, 76, 59, 9, 14, 58, 5, 9, 27, 86, 76 }, 108) + _0x73efc403);
#endif
                    }
                }
                else
                {
                    {
#if B_LOGS
                        Debug.Log(_0xc4b9e23f._0x50c41416(new byte[39] { 66, 77, 124, 106, 109, 68, 57, 90, 120, 122, 113, 124, 125, 57, 127, 112, 119, 120, 117, 76, 107, 117, 57, 251, 159, 139, 57, 106, 113, 118, 110, 57, 78, 124, 123, 79, 112, 124, 110 }, 25));
#endif
                    }
                }

                _0x5da73ea8 = true;
                _0x90f2cbd8(_0x73efc403);
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[44] { 169, 166, 151, 129, 134, 175, 210, 183, 138, 145, 151, 130, 134, 155, 157, 156, 210, 133, 154, 155, 158, 151, 210, 145, 154, 151, 145, 153, 155, 156, 149, 210, 129, 147, 132, 151, 150, 210, 158, 155, 156, 153, 200, 210 }, 242) + e.Message);
                }
#endif
            }

            return true;
        }
    }

    private bool _0x1b71bca0 = false;
    // MAIN FLOW
    private bool _0xd05d0799 { get; set; }

    private UniWebViewPopup _0x4fc78c0b()
    {
        for (int _0x1d3876ec = _0x9f92c081.Count - 1; _0x1d3876ec >= 0; _0x1d3876ec--)
        {
            var _0x963ff0e8 = _0x9f92c081[_0x1d3876ec];
            if (_0x963ff0e8 != null && _0x963ff0e8.IsAlive)
                return _0x963ff0e8;
            _0x9f92c081.RemoveAt(_0x1d3876ec);
        }

        return null;
    }

    private void _0x90f2cbd8(string _0x8a5d859a)
    {
        _0x14eb421e();
        StartCoroutine(_0xa9f90edd(_0x8a5d859a));
    }

    // NATIVE WEB VIEW METHODS
    private UniWebView _0x93930a98 = null;
    private string _0x069628e2 = "";
    private string _0xb5ee7f14 = "";
    private static string ReadPushField(Dictionary<string, object> _0x690a8ebb, string _0x5772cd92)
    {
        if (_0x690a8ebb == null || string.IsNullOrEmpty(_0x5772cd92))
            return string.Empty;
        if (_0x690a8ebb.TryGetValue(_0xc4b9e23f._0x50c41416(new byte[16] { 178, 179, 168, 181, 186, 181, 191, 189, 168, 181, 179, 178, 152, 189, 168, 189 }, 220), out var raw))
        {
            try
            {
                var _0x0e55335c = JsonConvert.DeserializeObject<Dictionary<string, object>>(raw?.ToString());
                if (_0x0e55335c != null && _0x0e55335c.TryGetValue(_0x5772cd92, out var nestedVal))
                {
                    var _0x2977aecf = nestedVal?.ToString();
                    if (!string.IsNullOrEmpty(_0x2977aecf))
                        return _0x2977aecf;
                }
            }
            catch
            {
            }
        }

        if (_0x690a8ebb.TryGetValue(_0x5772cd92, out var flatVal))
            return flatVal?.ToString() ?? string.Empty;
        return string.Empty;
    }

    // WEB VIEW LOGIC
    public bool _0x936330f6 { get; set; }

    private string _0x90979726 = "";
    internal bool isDestroyedForce = false;
    private string _0x40b3e17c;
    internal bool IsAboutBlank(string _0xa54278a5)
    {
        if (string.IsNullOrEmpty(_0xa54278a5))
            return false;
        return _0xa54278a5.StartsWith(_0xc4b9e23f._0x50c41416(new byte[11] { 102, 101, 104, 114, 115, 61, 101, 107, 102, 105, 108 }, 7), StringComparison.OrdinalIgnoreCase);
    }

    private string _0xeb87ca69 = "";
    internal string _0xa58c5fc8(string _0xa83bf986)
    {
        int _0xfcbb67fa = _0xa83bf986.IndexOf(_0xc4b9e23f._0x50c41416(new byte[3] { 182, 187, 226 }, 223), StringComparison.OrdinalIgnoreCase);
        if (_0xfcbb67fa < 0)
            return null;
        string _0x5080bd6b = _0xa83bf986.Substring(_0xfcbb67fa + 3);
        int _0xe7e7fe7b = _0x5080bd6b.IndexOf('&');
        return _0xe7e7fe7b >= 0 ? _0x5080bd6b.Substring(0, _0xe7e7fe7b) : _0x5080bd6b;
    }

    private Text _0x0af05949;
    internal bool isApplicationFocus = false;
    private bool _0xfa20af44(string _0x1f2108d0)
    {
        try
        {
            using (var _0xb2e6b3bb = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[30] { 56, 52, 54, 117, 46, 53, 50, 47, 34, 104, 63, 117, 43, 55, 58, 34, 62, 41, 117, 14, 53, 50, 47, 34, 11, 55, 58, 34, 62, 41 }, 91)))
            using (var _0xa1e30212 = _0xb2e6b3bb.GetStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 45, 59, 60, 60, 43, 32, 58, 15, 45, 58, 39, 56, 39, 58, 55 }, 78)))
            using (var _0x6b930a2e = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[15] { 91, 84, 94, 72, 85, 83, 94, 20, 84, 95, 78, 20, 111, 72, 83 }, 58)))
            using (var _0x0ce77649 = _0x6b930a2e.CallStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[5] { 45, 60, 47, 46, 56 }, 93), _0x1f2108d0))
            using (var _0xac74c946 = new AndroidJavaObject(_0xc4b9e23f._0x50c41416(new byte[22] { 11, 4, 14, 24, 5, 3, 14, 68, 9, 5, 4, 30, 15, 4, 30, 68, 35, 4, 30, 15, 4, 30 }, 106), _0xc4b9e23f._0x50c41416(new byte[26] { 128, 143, 133, 147, 142, 136, 133, 207, 136, 143, 149, 132, 143, 149, 207, 128, 130, 149, 136, 142, 143, 207, 183, 168, 164, 182 }, 225), _0x0ce77649))
            {
                WLog(_0xc4b9e23f._0x50c41416(new byte[26] { 58, 17, 11, 22, 20, 28, 53, 16, 18, 28, 89, 22, 9, 28, 23, 89, 28, 1, 13, 28, 11, 23, 24, 21, 67, 89 }, 121) + _0x1f2108d0);
                _0xac74c946.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[11] { 137, 140, 140, 171, 137, 156, 141, 143, 135, 154, 145 }, 232), _0xc4b9e23f._0x50c41416(new byte[33] { 1, 14, 4, 18, 15, 9, 4, 78, 9, 14, 20, 5, 14, 20, 78, 3, 1, 20, 5, 7, 15, 18, 25, 78, 34, 50, 47, 55, 51, 33, 34, 44, 37 }, 96));
                _0xac74c946.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[8] { 107, 110, 110, 76, 102, 107, 109, 121 }, 10), 0x10000000);
                _0xa1e30212.Call(_0xc4b9e23f._0x50c41416(new byte[13] { 158, 153, 140, 159, 153, 172, 142, 153, 132, 155, 132, 153, 148 }, 237), _0xac74c946);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0xc4b9e23f._0x50c41416(new byte[28] { 155, 176, 170, 183, 181, 189, 148, 177, 179, 189, 248, 189, 160, 172, 189, 170, 182, 185, 180, 248, 190, 185, 177, 180, 189, 188, 226, 248 }, 216) + e.Message);
            Application.OpenURL(_0x1f2108d0);
            return true;
        }
    }

    private string _0x80fc142b = "";
    // WS_SOURCE MONO
    public static _0x163f5a1a _0x76d4b68d { get; private set; }

    private string _0xf814c017 = "";
    // PART 3
    private string _0x460472c0()
    {
        try
        {
            var _0xe369d3d5 = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[30] { 243, 255, 253, 190, 229, 254, 249, 228, 233, 163, 244, 190, 224, 252, 241, 233, 245, 226, 190, 197, 254, 249, 228, 233, 192, 252, 241, 233, 245, 226 }, 144));
            var _0xddc365d0 = _0xe369d3d5.GetStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 106, 124, 123, 123, 108, 103, 125, 72, 106, 125, 96, 127, 96, 125, 112 }, 9));
            var _0x3fe75785 = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[57] { 81, 93, 95, 28, 85, 93, 93, 85, 94, 87, 28, 83, 92, 86, 64, 93, 91, 86, 28, 85, 95, 65, 28, 83, 86, 65, 28, 91, 86, 87, 92, 70, 91, 84, 91, 87, 64, 28, 115, 86, 68, 87, 64, 70, 91, 65, 91, 92, 85, 123, 86, 113, 94, 91, 87, 92, 70 }, 50));
            var _0x4507aeac = _0x3fe75785.CallStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[20] { 253, 255, 238, 219, 254, 236, 255, 232, 238, 243, 233, 243, 244, 253, 211, 254, 211, 244, 252, 245 }, 154), _0xddc365d0);
            var _0x879f45fb = _0x4507aeac.Call<string>(_0xc4b9e23f._0x50c41416(new byte[5] { 121, 123, 106, 87, 122 }, 30));
            {
#if B_LOGS
                Debug.Log($"[Test] Google Advertiding Id (ad id): {_0x879f45fb}");
#endif
            }

            return string.IsNullOrEmpty(_0x879f45fb) ? "" : _0x879f45fb;
        }
        catch
        {
            return "";
        }
    }

    private void _0xaf04c0a0()
    {
        {
#if B_LOGS
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[22] { 239, 224, 209, 199, 192, 233, 148, 231, 192, 219, 198, 209, 240, 209, 194, 221, 215, 209, 253, 218, 210, 219 }, 180));
#endif
        }

        _0xb5ee7f14 = SystemInfo.deviceModel;
        _0x32a0a20c = Application.version;
        _0x90c68e54 = Application.installMode;
        _0xee90543b = Application.installerName;
        _0x90979726 = Application.identifier;
        _0x1c669fe8 = _0x460472c0();
        _0xec9de758 = _0xd9969d78();
        _0x069628e2 = SystemInfo.deviceUniqueIdentifier;
        _0x80fc142b = SystemInfo.graphicsDeviceName;
        _0xc72bc106 = SystemInfo.processorType;
        {
#if B_LOGS
            {
                _0x32a0a20c = _0xc4b9e23f._0x50c41416(new byte[5] { 38, 63, 38, 63, 38 }, 17);
                _0x90c68e54 = ApplicationInstallMode.Store;
                _0xee90543b = _0xc4b9e23f._0x50c41416(new byte[19] { 76, 64, 66, 1, 78, 65, 75, 93, 64, 70, 75, 1, 89, 74, 65, 75, 70, 65, 72 }, 47);
                _0xec9de758 = _0xc4b9e23f._0x50c41416(new byte[8] { 119, 127, 98, 102, 107, 50, 103, 115 }, 18);
                _0x069628e2 = Guid.NewGuid().ToString().Replace(_0xc4b9e23f._0x50c41416(new byte[1] { 66 }, 111), "");
            }
#endif
        }

        {
#if B_LOGS
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[17] { 98, 109, 92, 74, 77, 100, 25, 93, 92, 79, 116, 86, 93, 92, 85, 3, 25 }, 57) + _0xb5ee7f14);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[19] { 98, 109, 92, 74, 77, 100, 25, 88, 73, 73, 111, 92, 75, 74, 80, 86, 87, 3, 25 }, 57) + _0x32a0a20c);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[20] { 17, 30, 47, 57, 62, 23, 106, 35, 36, 57, 62, 43, 38, 38, 7, 37, 46, 47, 112, 106 }, 74) + _0x90c68e54);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[23] { 221, 210, 227, 245, 242, 219, 166, 239, 232, 245, 242, 231, 234, 234, 227, 244, 213, 242, 233, 244, 227, 188, 166 }, 134) + _0xee90543b);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[14] { 161, 174, 159, 137, 142, 167, 218, 155, 138, 138, 179, 158, 192, 218 }, 250) + _0x90979726);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[14] { 145, 158, 175, 185, 190, 151, 234, 171, 174, 188, 131, 174, 240, 234 }, 202) + _0x1c669fe8);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[18] { 87, 88, 105, 127, 120, 81, 44, 121, 127, 105, 126, 77, 107, 105, 98, 120, 54, 44 }, 12) + _0xec9de758);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[17] { 206, 193, 240, 230, 225, 200, 181, 230, 236, 230, 209, 240, 227, 220, 241, 175, 181 }, 149) + _0x069628e2);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[12] { 29, 18, 35, 53, 50, 27, 102, 33, 54, 51, 124, 102 }, 70) + _0x80fc142b);
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[12] { 134, 137, 184, 174, 169, 128, 253, 190, 173, 168, 231, 253 }, 221) + _0xc72bc106);
#endif
        }
    }

    private string _0x48fc01ff = "";
    private string _0xd9969d78()
    {
        try
        {
            using (var _0x2aa2fd4f = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[30] { 87, 91, 89, 26, 65, 90, 93, 64, 77, 7, 80, 26, 68, 88, 85, 77, 81, 70, 26, 97, 90, 93, 64, 77, 100, 88, 85, 77, 81, 70 }, 52)))
            {
                var _0x4bd2c14b = _0x2aa2fd4f.GetStatic<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[15] { 239, 249, 254, 254, 233, 226, 248, 205, 239, 248, 229, 250, 229, 248, 245 }, 140));
                var _0xe9495857 = _0x4bd2c14b.Call<AndroidJavaObject>(_0xc4b9e23f._0x50c41416(new byte[21] { 57, 59, 42, 31, 46, 46, 50, 55, 61, 63, 42, 55, 49, 48, 29, 49, 48, 42, 59, 38, 42 }, 94));
                using (var _0x9c358b5f = new AndroidJavaClass(_0xc4b9e23f._0x50c41416(new byte[26] { 22, 25, 19, 5, 24, 30, 19, 89, 0, 18, 21, 28, 30, 3, 89, 32, 18, 21, 36, 18, 3, 3, 30, 25, 16, 4 }, 119)))
                {
                    return _0x9c358b5f.CallStatic<string>(_0xc4b9e23f._0x50c41416(new byte[19] { 50, 48, 33, 17, 48, 51, 52, 32, 57, 33, 0, 38, 48, 39, 20, 50, 48, 59, 33 }, 85), _0xe9495857);
                }
            }
        }
        catch
        {
            return "";
        }
    }

    private bool _0xcb861229 = false;
    private async Task<bool> _0x68fde62c()
    {
        _0x755be608.Instance?._0x1ecaa974();
        PushNotificationsService.Instance.OnRemoteNotificationReceived += (_0xaf2f93f3) =>
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[32] { 24, 23, 38, 48, 55, 30, 99, 22, 45, 42, 55, 58, 99, 19, 54, 48, 43, 99, 13, 44, 55, 42, 37, 42, 32, 34, 55, 42, 44, 45, 121, 99 }, 67) + string.Join(_0xc4b9e23f._0x50c41416(new byte[1] { 24 }, 17), _0xaf2f93f3));
                }
#endif
            }
        };
        try
        {
            _0xeb87ca69 = await PushNotificationsService.Instance.RegisterForPushNotificationsAsync();
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xc4b9e23f._0x50c41416(new byte[31] { 38, 41, 24, 14, 9, 32, 93, 59, 28, 20, 17, 24, 25, 93, 9, 18, 93, 26, 24, 9, 93, 13, 8, 14, 21, 93, 9, 18, 22, 24, 19 }, 125));
                }
#endif
            }

            _0xeb87ca69 = "";
        }

        _0x984fed58 = !string.IsNullOrEmpty(_0xeb87ca69);
        _0x81a500c8 = _0xc2423bf4();
        {
#if B_LOGS
            Debug.Log(_0xc4b9e23f._0x50c41416(new byte[25] { 54, 57, 8, 30, 25, 48, 77, 56, 3, 4, 25, 20, 77, 61, 24, 30, 5, 77, 57, 2, 6, 8, 3, 87, 77 }, 109) + _0xeb87ca69);
#endif
        }

        _0x755be608.Instance?._0x81c2b168();
        return false;
    }
}

internal static class _0xc4b9e23f
{
    internal static string _0x50c41416(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
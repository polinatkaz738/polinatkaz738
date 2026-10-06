using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static _0xea334b23;

public class _0x9d5294e1 : MonoBehaviour
{
    public static _0x5a36e82d _0x3f250610 => _0x5a36e82d.ALL_SCENES_SETTING_SINGLETONS[Instance._0xb61a7ebd];

    private void _0xfcefa3a5(bool _0xe31936e6)
    {
        Rigidbody2D[] _0x0ebe902d = this.RootGameObject.GetComponentsInChildren<Rigidbody2D>(true);
        foreach (Rigidbody2D _0x7a235daf in _0x0ebe902d)
            if (_0xe31936e6)
                _0x7a235daf.constraints = RigidbodyConstraints2D.FreezeAll;
            else
                _0x7a235daf.constraints = RigidbodyConstraints2D.None;
    }

    public void _0x8bcf8e94(bool _0xa0b4c72d)
    {
        this._0xc6e1c633 = _0xa0b4c72d;
        this._0xfcefa3a5(!this._0xc6e1c633);
        Physics2D.simulationMode = this._0xc6e1c633 ? SimulationMode2D.FixedUpdate : SimulationMode2D.Script;
        if (this.EnvironmentWithTweensToToggle != null)
            this._0x1e674e73(this.EnvironmentWithTweensToToggle);
    }

    public int _0xb61a7ebd => SceneManager.GetActiveScene().buildIndex;

    private static _0x5a36e82d GAME_INDEX_SETTINGS(int _0x75c01b48)
    {
        return _0x5a36e82d.ALL_SCENES_SETTING_SINGLETONS[_0x75c01b48];
    }

    public void _0x0bba6988()
    {
        foreach (_0x70838940 _0xf8e7c310 in this.MoneyCountContainers)
            _0xf8e7c310._0x083add14();
    }

    public bool _0xc6e1c633 { get; private set; }

    private void Start()
    {
        if (this._0xb61a7ebd != _0xa4801ffa.SCENE_0)
            Screen.orientation = ScreenOrientation.Portrait;
        this.DeleteProgressDataButton?.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            //AudioController.Instance.UpdateMusics();
            //AudioController.Instance.UpdateSfxes();
            Instance.LoadSceneByIndex(_0xa4801ffa.SCENE_0);
        });
        this.ShowResetTutorialButton?.onClick.AddListener(() =>
        {
            _0x3f250610._0x70fd5b16 = false;
            _0x2cc5c82d.Instance._0xc6c86a07();
            _0x8fc0d527.Instance._0x226158a4(_0x29a65535.TUTORIAL0);
        });
    }

    public Transform Environment;
    public Canvas MainCanvas;
    public Button ShowResetTutorialButton;
    private static void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator _0x3919a199(string _0x2cf27854)
    {
        _0x8fc0d527.Instance._0x226158a4(_0x29a65535.SPLASH);
        //AudioController.Instance.SaveLastMusicTimes();
        AsyncOperation _0xfbf72020 = SceneManager.LoadSceneAsync(_0x2cf27854);
        while (!_0xfbf72020.isDone)
            yield return null;
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x9d5294e1>();
        this.RootGameObject = GameObject.FindWithTag(_0x7b72da55._0x4109524a(new byte[4] { 172, 145, 145, 138 }, 254));
        if (this._0xb61a7ebd == _0xa4801ffa.SCENE_0)
            this._0x8bcf8e94(true);
        else
            this._0x8bcf8e94(false);
        this.MoneyCountContainers = this.RootGameObject.GetComponentsInChildren<_0x70838940>(true).ToList();
    }

    public void _0x3a8da579()
    {
        this.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
    }

    public static bool IsAfterLevelFailed = false;
    private void _0x1e674e73(Transform _0x784e1da8)
    {
        Transform[] _0x387c5e05 = _0x784e1da8.GetComponentsInChildren<Transform>();
        foreach (Transform _0xda1232f4 in _0x387c5e05)
            if (_0xda1232f4 != null && DOTween.IsTweening(_0xda1232f4))
            {
                if (this._0xc6e1c633)
                    DOTween.Play(_0xda1232f4);
                else
                    DOTween.Pause(_0xda1232f4);
            }
    }

    private void _0x92b067fc()
    {
        IsAfterLevelComplete = true;
        Instance.LoadSceneByIndex(_0xa4801ffa.SCENE_0);
    }

    public static _0x9d5294e1 Instance;
    public Button DeleteProgressDataButton;
    private static _0x5a36e82d _0x5946ee26 => _0x5a36e82d.ALL_SCENES_SETTING_SINGLETONS[0];

    [HideInInspector]
    public List<_0x70838940> MoneyCountContainers = new();
    public static bool IsAfterLevelComplete;
    [HideInInspector]
    public GameObject RootGameObject; // tag - "Root"
    public void LoadSceneByIndex(int _0x8c8c51c2)
    {
        //if (SceneManager.GetActiveScene().buildIndex == sceneIndex)
        //    AdsInitializer.Instance?.ShowAd();
        this.StartCoroutine(this._0x7a5ab471(_0x8c8c51c2));
    }

    private static void MakeGrid(List<RectTransform> _0xb9447ade, AspectRatioFitter _0xf5a32051, float _0x425b684e, int _0xa4ec076f, int _0xb4d7e5ff)
    {
        _0xf5a32051.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
        _0xf5a32051.aspectRatio = _0x425b684e;
        foreach (RectTransform _0x775a8df8 in _0xb9447ade)
        {
            int _0xe6c38f4e = _0x775a8df8.transform.GetSiblingIndex();
            _0x775a8df8.anchorMin = new Vector3(Mathf.FloorToInt((float)_0xe6c38f4e % _0xa4ec076f) * (1f / _0xa4ec076f), (_0xb4d7e5ff - (Mathf.FloorToInt((float)_0xe6c38f4e / _0xa4ec076f) % _0xb4d7e5ff + 1f)) * (1f / _0xb4d7e5ff));
            _0x775a8df8.anchorMax = new Vector3(Mathf.FloorToInt((float)_0xe6c38f4e % _0xa4ec076f + 1f) * (1f / _0xa4ec076f), (_0xb4d7e5ff - Mathf.FloorToInt((float)_0xe6c38f4e / _0xa4ec076f) % _0xb4d7e5ff) * (1f / _0xb4d7e5ff));
            _0x775a8df8.offsetMin = Vector2.zero;
            _0x775a8df8.offsetMax = Vector2.zero;
        }
    }

    public Transform EnvironmentWithTweensToToggle;
    private IEnumerator _0x7a5ab471(int _0xfa5be890)
    {
        _0x8fc0d527.Instance._0x226158a4(_0x29a65535.SPLASH);
        AsyncOperation _0xc832b459 = SceneManager.LoadSceneAsync(_0xfa5be890);
        while (!_0xc832b459.isDone)
            yield return null;
    }

    public void _0x17042614()
    {
        _0x3f250610._0x70fd5b16 = true;
    }
}

internal static class _0x7b72da55
{
    internal static string _0x4109524a(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
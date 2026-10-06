using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0xea334b23;

public class _0x8fc0d527 : MonoBehaviour
{
    public void _0xefd24e41()
    {
        this.LastPanelIndexes.RemoveAll(_0x79b4c762 => _0x79b4c762 == this.CurrentPanelIndex);
        int _0x18662279 = this.LastPanelIndexes.Last();
        this._0x47f906f4(_0x18662279);
        this._0x378c5bf8(_0x18662279);
        this.CurrentPanelIndex = _0x18662279;
        this.Panels[_0x18662279].Show();
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x8fc0d527>();
    }

    private void SwitchSplash()
    {
        if (_0x6efa701a.Instance.IsTutorialEnabled && !_0x9d5294e1._0x3f250610._0x70fd5b16)
            this._0x226158a4(_0x29a65535.TUTORIAL0);
        else
            this._0x226158a4(_0x29a65535.DEFAULT);
    }

    public List<_0xcd23417c> Panels;
    public float ScaleDuration = 0.4f;
    private void _0xd9c1205a()
    {
        this._0x8dde8211(_0x29a65535.SPLASH);
        if (_0x9d5294e1.Instance._0xb61a7ebd == _0xa4801ffa.SCENE_0)
        {
        }
        else
        {
            this.Invoke(nameof(this.SwitchSplash), _0x755be608.Instance.DefaultAnimationTime);
        }
    }

    public bool IsShowSplashOnStart = true;
    private _0xcd23417c _0xbf97bf41(int _0xd714edf4)
    {
        return this.Panels[_0xd714edf4];
    }

    private void _0x378c5bf8(int _0x1344b204)
    {
        this.LastPanelIndexes.Add(_0x1344b204);
        this.CurrentPanelIndex = _0x1344b204;
        for (int _0x4b4698af = 0; _0x4b4698af < this.Panels.Count; _0x4b4698af++)
            if (_0x4b4698af != _0x1344b204 && this.Panels[_0x4b4698af] != null)
                this.Panels[_0x4b4698af]._0x7f445771();
    }

    public void _0x226158a4(int _0x72b5927a)
    {
        this._0xb9c7a15f(_0x72b5927a);
        this._0x47f906f4(_0x72b5927a);
        this.CurrentPanelIndex = _0x72b5927a;
        this.Panels[_0x72b5927a].Show();
    }

    private void _0xb9c7a15f(int _0xf738ee26)
    {
        this.LastPanelIndexes.Add(_0xf738ee26);
        this.CurrentPanelIndex = _0xf738ee26;
        for (int _0xad95b766 = 0; _0xad95b766 < this.Panels.Count; _0xad95b766++)
            if (_0xad95b766 != _0xf738ee26 && this.Panels[_0xad95b766] != null)
                this.Panels[_0xad95b766]._0x7f445771();
    }

    private void Start()
    {
        this._0xd9c1205a();
    }

    public void _0x1f1fd6f2(int _0xf40d0cdc)
    {
        if (_0xf40d0cdc == _0x29a65535.SPLASH && _0x9d5294e1.Instance._0xb61a7ebd != _0xa4801ffa.SCENE_0)
            _0x755be608.Instance._0xb70b9997();
        if (_0x9d5294e1.Instance._0xb61a7ebd != _0xa4801ffa.SCENE_0)
        {
            if (_0xf40d0cdc == _0x29a65535.SPLASH || _0xf40d0cdc == _0x29a65535.TUTORIAL0)
                _0x9d5294e1.Instance._0x8bcf8e94(false);
            else if (_0xf40d0cdc == _0x29a65535.DEFAULT)
                _0x9d5294e1.Instance._0x8bcf8e94(true);
        }
    }

    public int CurrentPanelIndex;
    private void _0x47f906f4(int _0xbdeb3145)
    {
        if (_0xbdeb3145 == _0x29a65535.SPLASH)
            _0x755be608.Instance._0xe5ab3db8();
        if (_0x9d5294e1.Instance._0xb61a7ebd == _0xa4801ffa.SCENE_0)
        {
        }
    }

    [HideInInspector]
    public List<int> LastPanelIndexes = new()
    {
        1
    };
    public float StaticBlurMaterialInitialValue;
    private void _0x8dde8211(int _0x28659fde)
    {
        this._0xb9c7a15f(_0x28659fde);
        this._0x47f906f4(_0x28659fde);
        this.CurrentPanelIndex = _0x28659fde;
        this.Panels[_0x28659fde]._0x0a621ea2();
    }

    public static _0x8fc0d527 Instance;
}
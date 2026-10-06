using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xd04c7b71 : MonoBehaviour
{
    private void Start()
    {
        this.IsGameEnd = false;
        this.TimeLeft = this._0x4a71cdca;
        this.CurrentGameIndex = _0x9d5294e1.Instance._0xb61a7ebd;
        foreach (Button _0x8528c8e9 in this.HomeButtons)
            _0x8528c8e9.onClick.AddListener(() =>
            {
                this._0x25b1684e();
            });
        foreach (Button _0xefd8e4f5 in this.PauseButtons)
            _0xefd8e4f5.onClick.AddListener(() =>
            {
                _0x9d5294e1.Instance._0x8bcf8e94(false);
                _0x2cc5c82d.Instance._0x6dedd689(_0xea334b23._0xca25cf66.PAUSE);
            });
        this._0x2e02b594();
        this.LevelNumberText.ForEach(_0xfd944e15 => _0xfd944e15.text = $"LVL {_0x9d5294e1._0x3f250610._0x2b68d4d9 + 1}");
        if (_0x6efa701a.Instance.IsTimerEnabled)
        {
            this._0xadbc616d();
            this.StartCoroutine(this._0x9b27be25());
        }
    }

    private int _0xc642e88b => this.CustomTargetScore + _0x9d5294e1._0x3f250610._0x2b68d4d9 * 10;

    public void _0x25b1684e()
    {
        _0x9d5294e1.Instance._0x8bcf8e94(true);
        _0x9d5294e1.Instance.LoadSceneByIndex(_0xea334b23._0xa4801ffa.SCENE_0);
    }

    public List<Button> HomeButtons = new();
    private IEnumerator _0x9b27be25()
    {
        this._0xadbc616d();
        while (!this.IsGameEnd && this.TimeLeft > 0 && _0x9d5294e1.Instance._0xb61a7ebd == this.CurrentGameIndex)
        {
            yield return new WaitForSeconds(1f);
            if (_0x9d5294e1.Instance._0xc6e1c633)
            {
                if (this.IsGameEnd)
                    break;
                this.TimeLeft--;
                this._0xadbc616d();
            }
        }

        if (!this.IsGameEnd)
            this._0x1f8a249c();
    }

    [HideInInspector]
    public bool IsGameEnd;
    private void _0xb86cf937()
    {
        this.IsGameEnd = true;
        _0x9d5294e1.IsAfterLevelComplete = true;
    }

    public List<TMP_Text> TimerText = new();
    public List<Button> PauseButtons = new();
    public void _0x1f8a249c()
    {
        if (_0x6efa701a.Instance.IsOnlyWinGameEndEnabled)
            this._0x99a0ad9f();
        if (!this.IsGameEnd)
        {
            this._0xb86cf937();
            _0x9d5294e1.IsAfterLevelComplete = false;
            _0x9d5294e1.IsAfterLevelFailed = true;
            _0x30b2da79 _0xd0428ab8 = _0x2cc5c82d.Instance._0x594a6eda(_0xea334b23._0xca25cf66.LOSE).GetComponent<_0x30b2da79>();
            if (_0x6efa701a.Instance.IsCheckScoreEnabled)
                _0xd0428ab8.ContentMainText.text = $"{this.ScoreCurrent}/{this._0xc642e88b}";
            else
                _0xd0428ab8.ContentMainText.text = $"{this.ScoreCurrent}";
            _0xd0428ab8.ContentAdditionalText.text = $"{0}";
            _0xea334b23._0xdb0cb883._0xd71b9dc9 += 0;
            _0x2cc5c82d.Instance._0x6dedd689(_0xea334b23._0xca25cf66.LOSE);
        }
    }

    public List<TMP_Text> SubtitleText = new();
    [HideInInspector]
    public int TimeLeft;
    private int _0x66351537 => this.ScoreCurrent;

    public int CustomTimeInitial = 30;
    private int _0x4a71cdca => this.CustomTimeInitial + _0x9d5294e1._0x3f250610._0x2b68d4d9 * 10;

    public void _0xb872bc65(int scoreToAdd)
    {
        if (!this.IsGameEnd)
        {
            this.ScoreCurrent += scoreToAdd;
            this._0x2e02b594();
            this._0x73792c88();
        }
    }

    private void _0x73792c88()
    {
        if (this.ScoreCurrent > _0x9d5294e1._0x3f250610._0xeda6d1fb)
            _0x9d5294e1._0x3f250610._0xeda6d1fb = this.ScoreCurrent;
        if (_0x6efa701a.Instance.IsCheckScoreEnabled)
            if (this.ScoreCurrent >= this._0xc642e88b)
                this._0x99a0ad9f();
    }

    public int CustomTargetScore = 10;
    private void _0xadbc616d()
    {
        this.TimerText.ForEach(_0xfd944e15 => _0xfd944e15.text = TimeSpan.FromSeconds(this.TimeLeft).ToString(_0x52607ed1._0x5d0ff654(new byte[6] { 133, 133, 180, 210, 155, 155 }, 232)));
    }

    private void _0x991ee8f7()
    {
        if (this.ScoreCurrent >= this._0xc642e88b)
            this._0x99a0ad9f();
        else
            this._0x1f8a249c();
    }

    private void _0x2e02b594()
    {
        if (_0x6efa701a.Instance.IsCheckScoreEnabled)
            this.ScoreText.ForEach(_0xfd944e15 => _0xfd944e15.text = $"{this.ScoreCurrent}/{this._0xc642e88b}");
        else
            this.ScoreText.ForEach(_0xfd944e15 => _0xfd944e15.text = $"{this.ScoreCurrent}");
    }

    public List<TMP_Text> LevelNumberText = new();
    private void Awake()
    {
        _0x0249d26d = this.gameObject.GetComponent<_0xd04c7b71>();
    }

    [HideInInspector]
    public int ScoreCurrent;
    public void _0x99a0ad9f()
    {
        if (!this.IsGameEnd)
        {
            this._0xb86cf937();
            _0x9d5294e1.IsAfterLevelComplete = true;
            _0x9d5294e1.IsAfterLevelFailed = false;
            _0x30b2da79 _0xc4914538 = _0x2cc5c82d.Instance._0x594a6eda(_0xea334b23._0xca25cf66.WIN).GetComponent<_0x30b2da79>();
            if (_0x6efa701a.Instance.IsCheckScoreEnabled)
                _0xc4914538.ContentMainText.text = $"{this.ScoreCurrent}/{this._0xc642e88b}";
            else
                _0xc4914538.ContentMainText.text = $"{this.ScoreCurrent}";
            if (_0x6efa701a.Instance.IsBestScoreEnabled)
            {
                if (this.ScoreCurrent > _0xea334b23._0xdb0cb883._0xd71b9dc9)
                    _0xea334b23._0xdb0cb883._0xd71b9dc9 = this.ScoreCurrent;
                _0xc4914538.ContentAdditionalText.text = $"{_0xea334b23._0xdb0cb883._0xd71b9dc9}";
            }
            else
            {
                _0xc4914538.ContentAdditionalText.text = $"{this._0x66351537}";
                _0xea334b23._0xdb0cb883._0xd71b9dc9 += this._0x66351537;
            }

            if (_0x6efa701a.Instance.IsLevelIncrementOnWin)
                ++_0x9d5294e1._0x3f250610._0x2b68d4d9;
            _0x2cc5c82d.Instance._0x6dedd689(_0xea334b23._0xca25cf66.WIN);
        }
    }

    private static _0xd04c7b71 _0x0249d26d;
    [HideInInspector]
    public int CurrentGameIndex;
    public List<TMP_Text> ScoreText = new();
}

internal static class _0x52607ed1
{
    internal static string _0x5d0ff654(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
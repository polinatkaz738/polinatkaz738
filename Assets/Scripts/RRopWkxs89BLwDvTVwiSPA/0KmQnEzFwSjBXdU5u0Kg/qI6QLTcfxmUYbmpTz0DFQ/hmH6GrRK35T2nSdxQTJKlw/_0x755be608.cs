using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0x755be608 : MonoBehaviour
{
    public float FirstAnimationTime = 10.0f;
    private void _0xcb433d0e()
    {
        this.AnimationSlider.value = 0.05f;
        _0xec74669c = !_0xec74669c;
        this._0x4ce6eec4 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x194628ff => this.AnimationSlider.value = _0x194628ff, 1f, this.FirstAnimationTime)).SetEase(Ease.Linear).OnComplete(() =>
        {
            _0x163f5a1a._0x76d4b68d?._0xa16d7b56();
        });
    }

    public void _0xe5ab3db8()
    {
        this._0x4ce6eec4?.Kill();
        this.AnimationSlider.value = _0xec74669c ? this.SecondPassSliderValue : 0.05f;
    }

    public GameObject Error;
    public float DefaultAnimationTime = 0.4f;
    public Slider AnimationSlider;
    private static bool _0xec74669c = false;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == _0xea334b23._0xa4801ffa.SCENE_0 && !_0xec74669c)
        {
            this._0xcb433d0e();
        }
        else
        {
            this._0xb70b9997();
        }
    }

    public void _0x1ecaa974()
    {
        this._0x4ce6eec4?.Pause();
    }

    public static _0x755be608 Instance;
    public float SecondPassSliderValue = 0.5f;
    private Sequence _0x4ce6eec4;
    public void _0x81c2b168()
    {
        this._0x4ce6eec4?.Play();
    }

    public GameObject Content;
    public GameObject Background;
    public void _0xb70b9997()
    {
        this._0xe5ab3db8();
        bool _0xd0a99138 = _0xec74669c;
        this._0x4ce6eec4 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x194628ff => this.AnimationSlider.value = _0x194628ff, _0xd0a99138 ? 1f : this.SecondPassSliderValue, this.DefaultAnimationTime)).SetEase(Ease.Linear);
        _0xec74669c = !_0xec74669c;
    }

    public void _0x67775186()
    {
        {
#if B_LOGS
            {
                Debug.Log($"[Test] Animate Force");
            }
#endif
        }

        this._0x4ce6eec4?.Kill();
        if (AnimationSlider != null)
            this.AnimationSlider.value = 1f;
        _0xec74669c = false;
    }

    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x755be608>();
    }
}
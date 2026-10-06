using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xcd23417c : MonoBehaviour
{
    public GameObject Content;
    public void _0x0a621ea2()
    {
        this._0x8e030b50();
        this.Content.SetActive(true);
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.localScale = Vector3.one;
        _0x8fc0d527.Instance._0x1f1fd6f2(_0x8fc0d527.Instance.CurrentPanelIndex);
    }

    private bool _0xd5014070 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.OuterBackground != null)
            this.OuterBackground.gameObject.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0xb8cf6aa0();
    }

    public TMP_Text MainText;
    public Ease Ease = Ease.OutSine;
    public GameObject OuterBackground;
    public TMP_Text HeaderText;
    private void _0x47d0f10e()
    {
        if (this.OuterBackground != null)
        {
            Image _0x65211793 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x65211793, true);
            _0x65211793.DOFade(1f, this.ScaleDuration / 2f);
        }
    }

    public void _0x7f445771()
    {
        this._0xbc019bf5();
        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
        {
            this.Content.SetActive(false);
        });
    }

    private void _0xbc019bf5()
    {
        if (this.OuterBackground != null)
        {
            Image _0x8f799f59 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x8f799f59, true);
            _0x8f799f59.DOFade(0f, this.ScaleDuration);
        }
    }

    public bool IsScaledDownOnAwake = true;
    private void _0x8e030b50()
    {
        if (this.OuterBackground != null)
        {
            Image _0xe950cf62 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0xe950cf62, true);
            _0xe950cf62.DOFade(1f, 0f);
        }
    }

    private void _0xb8cf6aa0()
    {
        if (this.OuterBackground != null)
        {
            Image _0x89fd0136 = this.OuterBackground.GetComponent<Image>();
            DOTween.Kill(_0x89fd0136, true);
            _0x89fd0136.DOFade(0f, 0.01f);
        }

        DOTween.Kill(this.Content.transform, true);
        this.Content.transform.DOScale(0f, 0.01f);
    }

    public float ScaleDuration = 0.4f;
    public void Show()
    {
        this._0x47d0f10e();
        if (this.Content != null)
        {
            DOTween.Kill(this.Content.transform, true);
            this.Content.SetActive(true);
            this.Content.transform.DOScale(1f, this.ScaleDuration).SetEase(this.Ease).OnComplete(() =>
            {
                _0x8fc0d527.Instance._0x1f1fd6f2(_0x8fc0d527.Instance.CurrentPanelIndex);
            });
        }
    }
}
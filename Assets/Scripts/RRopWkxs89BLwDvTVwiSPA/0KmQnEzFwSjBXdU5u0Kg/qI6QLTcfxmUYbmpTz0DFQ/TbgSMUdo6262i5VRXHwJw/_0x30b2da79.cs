using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0x30b2da79 : MonoBehaviour
{
    public void _0xe6a4b14a()
    {
        if (this.Content.gameObject.activeSelf)
        {
            DOTween.Kill(this.Content.transform, true);
            if (this.IsOnlyYScale)
                this.Content.transform.DOScaleY(0f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
                {
                    this.Content.SetActive(false);
                });
            else
                this.Content.transform.DOScale(0f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
                {
                    this.Content.SetActive(false);
                });
        }
    }

    public static void HideAllPops()
    {
        _0x2cc5c82d.Instance._0xc6c86a07();
    }

    public TMP_Text ContentAdditionalText;
    private void _0xf079dea3()
    {
        DOTween.Kill(this.Content.transform, true);
        if (this.IsOnlyYScale)
            this.Content.transform.DOScaleY(0f, 0.01f);
        else
            this.Content.transform.DOScale(0f, 0.01f);
        this.Content.SetActive(false);
    }

    public Image ContentImage;
    public TMP_Text ContentHeaderText;
    public GameObject Content;
    private void Start()
    {
    // Content.SetActive(false);
    }

    public TMP_Text ContentMainText;
    public bool IsOnlyYScale;
    public Ease ease = Ease.OutSine;
    private bool _0xd77b9c01 => this.Content.transform.localScale.x > 0.5f && this.Content.transform.localScale.y > 0.5f;

    public bool IsScaledDownOnAwake = true;
    public float scaleDuration = 0.4f;
    private void Awake()
    {
        this.Content.SetActive(true);
        if (this.IsScaledDownOnAwake)
            this._0xf079dea3();
    }

    public void Show()
    {
        this.Content.SetActive(true);
        if ((DOTween.TweensByTarget(this.Content.transform)?.Count ?? 0) > 0)
            DOTween.Kill(this.Content.transform, true);
        if (this.IsOnlyYScale)
            this.Content.transform.DOScaleY(1f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
            {
            });
        else
            this.Content.transform.DOScale(1f, this.scaleDuration).SetEase(this.ease).OnComplete(() =>
            {
            });
    }
}
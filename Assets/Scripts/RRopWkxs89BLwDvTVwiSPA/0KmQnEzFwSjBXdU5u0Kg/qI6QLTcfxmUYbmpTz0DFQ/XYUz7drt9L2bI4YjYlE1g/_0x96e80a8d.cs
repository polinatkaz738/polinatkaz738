using UnityEngine;
using UnityEngine.UI;

public class _0x96e80a8d : MonoBehaviour
{
    public Button Button;
    private void Start()
    {
        if (this.IsShowLastPop)
            this.Button.onClick.AddListener(() =>
            {
                _0x2cc5c82d.Instance._0x18b68593();
            });
        else if (this.IsHideAllPops)
            this.Button.onClick.AddListener(() => _0x2cc5c82d.Instance._0xc6c86a07());
        else
            this.Button.onClick.AddListener(() => _0x2cc5c82d.Instance._0x6dedd689(this.PopToShowIndex));
    }

    public int PopToShowIndex;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    public bool IsShowLastPop;
    public bool IsHideAllPops;
}
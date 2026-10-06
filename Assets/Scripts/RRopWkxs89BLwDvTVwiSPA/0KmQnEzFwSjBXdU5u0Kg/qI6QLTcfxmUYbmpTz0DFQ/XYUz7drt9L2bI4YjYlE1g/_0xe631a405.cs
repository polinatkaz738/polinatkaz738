using UnityEngine;
using UnityEngine.UI;

public class _0xe631a405 : MonoBehaviour
{
    public Button Button;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        this.Button.onClick.AddListener(() => _0x9d5294e1.Instance._0x8bcf8e94(this.IsPhysicsRunOnClick));
    }

    public bool IsPhysicsRunOnClick;
}
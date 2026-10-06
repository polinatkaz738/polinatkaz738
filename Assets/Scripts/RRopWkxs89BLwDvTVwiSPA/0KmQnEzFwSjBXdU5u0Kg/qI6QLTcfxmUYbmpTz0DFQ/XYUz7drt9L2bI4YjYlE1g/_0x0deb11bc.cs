using UnityEngine;
using UnityEngine.UI;

public class _0x0deb11bc : MonoBehaviour
{
    private void Start()
    {
        if (this._0x75a41bbb)
            this._0x4b10951d.onClick.AddListener(() => _0x8fc0d527.Instance._0xefd24e41());
        else
            this._0x4b10951d.onClick.AddListener(() => _0x8fc0d527.Instance._0x226158a4(this._0xee6cc5ae));
    }

    private void Awake()
    {
        if (this._0x4b10951d == null)
            if (!this.TryGetComponent(out this._0x4b10951d))
                this._0x4b10951d = this.GetComponentInChildren<Button>();
    }

    private int _0xee6cc5ae;
    private bool _0x75a41bbb;
    private Button _0x4b10951d;
}
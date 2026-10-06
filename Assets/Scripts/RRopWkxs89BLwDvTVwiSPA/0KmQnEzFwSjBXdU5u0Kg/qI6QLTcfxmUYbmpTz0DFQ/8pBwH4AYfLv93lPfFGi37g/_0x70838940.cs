using TMPro;
using UnityEngine;
using static _0xea334b23;

public class _0x70838940 : MonoBehaviour
{
    public TMP_Text MoneyCountText;
    public void _0x083add14()
    {
        this.MoneyCountText.text = _0xdb0cb883._0xd71b9dc9.ToString();
    }

    private void Start()
    {
        if (this.MoneyCountText == null)
        {
            TMP_Text _0x7bc366a2;
            if (this.gameObject.TryGetComponent(out _0x7bc366a2))
                this.MoneyCountText = _0x7bc366a2;
        }

        this._0x083add14();
    }
}
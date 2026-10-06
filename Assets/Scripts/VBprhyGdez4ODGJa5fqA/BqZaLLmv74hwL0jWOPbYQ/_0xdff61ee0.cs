using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xdff61ee0 : MonoBehaviour
{
    private Image _0x37f289f3;
    private TMP_Text _0x777aad55;
    private void _0x198ba4ec()
    {
        if (this._0x37f289f3.canvasRenderer.GetColor() != this._0x777aad55.canvasRenderer.GetColor())
            this._0x777aad55.canvasRenderer.SetColor(this._0x37f289f3.canvasRenderer.GetColor());
    }

    private void Update()
    {
        this._0x198ba4ec();
    }
}
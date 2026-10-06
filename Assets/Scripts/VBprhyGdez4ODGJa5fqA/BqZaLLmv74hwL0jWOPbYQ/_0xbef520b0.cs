using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class _0xbef520b0 : MonoBehaviour
{
    private TMP_Text _0xf6815654;
    private float _0x82430ae4 = 1.5f;
    private float _0x6a18acf7 = 0.6f;
    private void Update()
    {
        int _0xfe39cccb = 1;
        if (this._0x1ea42d48.Count > 0)
        {
            string _0x3965589f = this._0xf6815654.text;
            foreach (string _0xb8c6583e in this._0x1ea42d48)
                while (_0x3965589f.Contains(_0xb8c6583e))
                    _0x3965589f = _0x3965589f.Replace(_0xb8c6583e, "");
            _0xfe39cccb = _0x3965589f.Length;
        }
        else
        {
            _0xfe39cccb = this._0xf6815654.text.Length;
        }

        float _0xa3c74816 = Mathf.Clamp(this._0x06a65838 + this._0x6a18acf7 * _0xfe39cccb, this._0x82430ae4, this._0xa9bab4cc);
        if (!Mathf.Approximately(this._0xf6dde256.aspectRatio, _0xa3c74816))
            this._0xf6dde256.aspectRatio = _0xa3c74816;
    }

    private float _0x06a65838;
    private List<string> _0x1ea42d48 = new();
    private float _0xa9bab4cc = 4;
    private AspectRatioFitter _0xf6dde256;
}
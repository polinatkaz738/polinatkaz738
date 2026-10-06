using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The court's favour: a bar that drains slowly on its own and is topped up by
/// catching fruit. The drain is deliberately gentle - at 0.6 a second a completely
/// passive run survives past 160 seconds, so the bar is never what ends a round
/// inside the review capture window (CLAUDE-unity.md C.5).
/// </summary>
public sealed class _0xea3c1a17 : MonoBehaviour
{
    public void _0x7705f3e4()
    {
        this._0xed5ce9e1 = this._startValue;
        this._0xe87b5d60();
    }

    [SerializeField]
    private float _drainPerSecond = 0.6f;
    public void _0x4f341c4e(float deltaTime)
    {
        this._0xed5ce9e1 = Mathf.Clamp(this._0xed5ce9e1 - (this._drainPerSecond * deltaTime), 0f, this._ceiling);
        this._0xe87b5d60();
    }

    public void Add(float _0x6fadc6fe)
    {
        this._0xed5ce9e1 = Mathf.Clamp(this._0xed5ce9e1 + _0x6fadc6fe, 0f, this._ceiling);
        this._0xe87b5d60();
    }

    [SerializeField]
    private Image _icon;
    private void _0xe87b5d60()
    {
        if (this._fill != null)
        {
            this._fill.fillAmount = Mathf.Clamp01(this._0xed5ce9e1 / this._ceiling);
            // Overfill reads gold, ordinary favour reads leaf-green, a dying bar reads coral.
            if (this._0xed5ce9e1 > this._startValue)
            {
                this._fill.color = _0xd2ac8035.Gold;
            }
            else if (this._0xed5ce9e1 < this._startValue * 0.25f)
            {
                this._fill.color = _0xd2ac8035.Coral;
            }
            else
            {
                this._fill.color = _0xd2ac8035.Leaf;
            }
        }

        if (this._icon != null)
        {
            this._icon.color = _0xd2ac8035.Gold;
        }

        if (this._valueText != null)
        {
            this._valueText.text = _0x3668a273._0x76e3abf5(new byte[6] { 55, 48, 39, 62, 35, 81 }, 113) + Mathf.RoundToInt(this._0xed5ce9e1).ToString();
        }
    }

    private void Start()
    {
        _0x05c27b73.ApplyOutline(this._valueText);
    }

    [SerializeField]
    private TMP_Text _valueText;
    public bool _0x8d388a6a
    {
        get
        {
            return this._0xed5ce9e1 <= 0f;
        }
    }

    private float _0xed5ce9e1;
    public float _0x8f94c4ce
    {
        get
        {
            return this._0xed5ce9e1;
        }
    }

    [SerializeField]
    private float _startValue = 100f;
    [SerializeField]
    private Image _fill;
    [SerializeField]
    private float _ceiling = 140f;
}

internal static class _0x3668a273
{
    internal static string _0x76e3abf5(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dresses the splash loading bar in the game's own colours.
///
/// The template ships it white-on-white: the fill is plain white at full alpha and
/// the track is white at 1/255, which is invisible at any size (rule G). Both are
/// retinted here; the bar's authored height is left alone on purpose, because
/// shrinking the root is what collapses the inset Fill Area to nothing.
///
/// The slider is reached through the panel list rather than by name - the panel
/// controller addresses its pages by index, which is the one handle obfuscation
/// cannot rewrite.
/// </summary>
public sealed class _0x54d36f0b : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _caption;
    [SerializeField]
    private int _splashPanelIndex;
    private void Start()
    {
        if (this._caption != null)
        {
            this._caption.text = _0x7535bdb4._0xa289fe0b(new byte[19] { 73, 75, 92, 73, 88, 75, 80, 87, 94, 57, 77, 81, 92, 57, 90, 86, 76, 75, 77 }, 25);
            this._caption.color = _0xd2ac8035.Cream;
            _0x05c27b73.ApplyLayout(this._caption, 40f, 32f);
            _0x05c27b73.ApplyOutline(this._caption);
        }

        this._0x30005420();
    }

    private void _0x30005420()
    {
        _0x8fc0d527 _0x3e6897fc = _0x8fc0d527.Instance;
        if (_0x3e6897fc == null || _0x3e6897fc.Panels == null)
        {
            return;
        }

        if (this._splashPanelIndex < 0 || this._splashPanelIndex >= _0x3e6897fc.Panels.Count)
        {
            return;
        }

        _0xcd23417c _0x2e2d3a63 = _0x3e6897fc.Panels[this._splashPanelIndex];
        if (_0x2e2d3a63 == null || _0x2e2d3a63.Content == null)
        {
            return;
        }

        Slider _0x2c56f992 = _0x2e2d3a63.Content.GetComponentInChildren<Slider>(true);
        if (_0x2c56f992 == null)
        {
            return;
        }

        Image _0x3fd228b7 = _0x2c56f992.fillRect == null ? null : _0x2c56f992.fillRect.GetComponent<Image>();
        if (_0x3fd228b7 != null)
        {
            _0x3fd228b7.color = _0xd2ac8035.Leaf;
        }

        Image _0x0ad90e38 = _0x2c56f992.fillRect == null || _0x2c56f992.fillRect.parent == null ? null : _0x2c56f992.fillRect.parent.GetComponent<Image>();
        if (_0x0ad90e38 != null)
        {
            _0x0ad90e38.color = _0xd2ac8035.Fade(_0xd2ac8035.Deep, 0.85f);
        }

        if (_0x2c56f992.handleRect != null)
        {
            _0x2c56f992.handleRect.gameObject.SetActive(false);
        }
    }
}

internal static class _0x7535bdb4
{
    internal static string _0xa289fe0b(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
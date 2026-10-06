using TMPro;
using UnityEngine;

/// <summary>
/// Labels created or retouched from code are invisible to the pipeline's contrast
/// stage (it only reads serialized scenes and prefabs), so the outline has to be
/// applied here - CLAUDE-unity.md C.10. Reading fontMaterial creates a per-label
/// material INSTANCE, so the shared font asset is never modified.
/// </summary>
public static class _0x05c27b73
{
    /// <summary>Gives the label an outline that contrasts with its own face colour.</summary>
    public static void ApplyOutline(TMP_Text _0x5fbdefdb)
    {
        if (_0x5fbdefdb == null)
        {
            return;
        }

        Color _0x87c18658 = _0x5fbdefdb.color;
        float _0x9101bc97 = (0.299f * _0x87c18658.r) + (0.587f * _0x87c18658.g) + (0.114f * _0x87c18658.b);
        Material _0xc4b711dc = _0x5fbdefdb.fontMaterial;
        if (_0xc4b711dc == null)
        {
            return;
        }

        _0xc4b711dc.SetColor(ShaderUtilities.ID_OutlineColor, _0x9101bc97 < 0.5f ? _0xd2ac8035.Cream : _0xd2ac8035.Ink);
        _0xc4b711dc.SetFloat(ShaderUtilities.ID_OutlineWidth, OutlineWidth);
    }

    private const float OutlineWidth = 0.18f;
    /// <summary>
    /// The layout contract from C.10: the engine never decides where a line ends,
    /// and a line that does not fit shrinks rather than overflowing - but never
    /// below the readability floor of C.12.
    /// </summary>
    public static void ApplyLayout(TMP_Text _0x31e43a7d, float _0x80689a24, float _0x9d3f5f22)
    {
        if (_0x31e43a7d == null)
        {
            return;
        }

        _0x31e43a7d.enableWordWrapping = false;
        _0x31e43a7d.overflowMode = TextOverflowModes.Overflow;
        _0x31e43a7d.enableAutoSizing = true;
        _0x31e43a7d.fontSizeMin = _0x9d3f5f22;
        _0x31e43a7d.fontSizeMax = _0x80689a24;
    }
}
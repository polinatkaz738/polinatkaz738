using UnityEngine;

/// <summary>
/// The whole colour vocabulary of the game, in one place. Every value is a plain
/// literal: nothing here reads anything else, so the static initialisers cannot
/// depend on each other after the obfuscator reorders declarations (CLAUDE-unity.md
/// C.52). Every text colour is LIGHT on purpose - the font material carries one
/// dark outline for the whole app (C.14).
/// </summary>
public static class _0xd2ac8035
{
    public static readonly Color Gold = new Color(0.9607843f, 0.7686275f, 0.3176471f, 1f); // #F5C451
    public static readonly Color Muted = new Color(0.227451f, 0.3529412f, 0.2588235f, 1f); // #3A5A42
    public static readonly Color Leaf = new Color(0.4862745f, 0.7960784f, 0.3568628f, 1f); // #7CCB5B
    public static readonly Color Base = new Color(0.09019608f, 0.1882353f, 0.1254902f, 1f); // #173020
    public static readonly Color Shadow = new Color(0.02745098f, 0.07450981f, 0.04705882f, 1f); // #07130C
    public static readonly Color Raised = new Color(0.1176471f, 0.2352941f, 0.1568628f, 1f); // #1E3C28
    public static readonly Color Ink = new Color(0.04705882f, 0.1137255f, 0.07450981f, 1f); // #0C1D13
    public static readonly Color Cream = new Color(1f, 0.9647059f, 0.8980392f, 1f); // #FFF6E5
    /// <summary>Same hue, different transparency - used for tracks, dimmers and fades.</summary>
    public static Color Fade(Color _0xeecbb5fd, float _0xe73404e6)
    {
        return new Color(_0xeecbb5fd.r, _0xeecbb5fd.g, _0xeecbb5fd.b, _0xe73404e6);
    }

    public static readonly Color Coral = new Color(0.9333333f, 0.4196078f, 0.3333333f, 1f); // #EE6B55
    public static readonly Color Royal = new Color(0.5529412f, 0.4039216f, 0.7803922f, 1f); // #8D67C7
    public static readonly Color Deep = new Color(0.05490196f, 0.1254902f, 0.08627451f, 1f); // #0E2016
    /// <summary>The fruit colour for a section index, so tray and fruit never disagree.</summary>
    public static Color Section(int _0x45ba1d24)
    {
        if (_0x45ba1d24 == 1)
        {
            return Gold;
        }

        if (_0x45ba1d24 == 2)
        {
            return Coral;
        }

        return Leaf;
    }
}
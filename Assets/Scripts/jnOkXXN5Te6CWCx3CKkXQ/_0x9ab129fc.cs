using UnityEngine;

/// <summary>
/// Per-stage best harvest and the attempt counter that seeds every round.
///
/// The PlayerPrefs keys are built in the CONSTRUCTOR, never in a static
/// initialiser: after string encryption a `const string` becomes a field filled at
/// runtime, and a static field that depends on another one dies in the class
/// constructor once the obfuscator reorders the declarations (CLAUDE-unity.md C.52).
/// </summary>
public sealed class _0x9ab129fc
{
    /// <summary>A stage is open once the one before it has been cleared at least once.</summary>
    public bool _0x093b9e3f(int _0xd2dc0b91)
    {
        return _0xd2dc0b91 <= 0 || this._0x672ab235(_0xd2dc0b91 - 1) > 0;
    }

    private readonly string _0x804aed03;
    public _0x9ab129fc()
    {
        this._0x804aed03 = _0x3d0f292e._0x42c167bb(new byte[8] { 114, 98, 127, 66, 69, 83, 84, 127 }, 32);
        this._0xecc5a975 = _0x3d0f292e._0x42c167bb(new byte[10] { 155, 139, 150, 168, 189, 189, 172, 164, 185, 189 }, 201);
        this._0x2972c5e7 = _0x3d0f292e._0x42c167bb(new byte[8] { 120, 104, 117, 89, 94, 75, 77, 79 }, 42);
    }

    public int _0x672ab235(int _0x7729f362)
    {
        return PlayerPrefs.GetInt(this._0x804aed03 + _0x7729f362.ToString(), 0);
    }

    private readonly string _0xecc5a975;
    private readonly string _0x2972c5e7;
    public void _0xef2def7b(int _0x48786cb5, int _0x800e2f28)
    {
        if (_0x800e2f28 > this._0x672ab235(_0x48786cb5))
        {
            PlayerPrefs.SetInt(this._0x804aed03 + _0x48786cb5.ToString(), _0x800e2f28);
            PlayerPrefs.Save();
        }
    }

    /// <summary>Bumped once per round so two runs of the same stage never match.</summary>
    public int _0xa00e5485()
    {
        int _0x66b8e2a7 = PlayerPrefs.GetInt(this._0xecc5a975, 0) + 1;
        PlayerPrefs.SetInt(this._0xecc5a975, _0x66b8e2a7);
        PlayerPrefs.Save();
        return _0x66b8e2a7;
    }

    public int _0x2d5afef4
    {
        get
        {
            return PlayerPrefs.GetInt(this._0x2972c5e7, 0);
        }

        set
        {
            PlayerPrefs.SetInt(this._0x2972c5e7, value);
            PlayerPrefs.Save();
        }
    }
}

internal static class _0x3d0f292e
{
    internal static string _0x42c167bb(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}
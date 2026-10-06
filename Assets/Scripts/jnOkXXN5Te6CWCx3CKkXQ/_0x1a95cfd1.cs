using UnityEngine;

/// <summary>
/// The four stages of the court, held as parallel [SerializeField] arrays so the
/// data survives symbol obfuscation untouched (only field names decide how Unity
/// deserialises, and [SerializeField] names are never renamed).
///
/// The schedules are chosen so that a run with ZERO player input still lasts well
/// over a minute on every stage - CLAUDE-unity.md C.5. With no catches the only way
/// to die is to drop five crowned plums, which happens at
/// crownFirst + 4 * crownInterval seconds: 76 / 72 / 67 / 64.
/// </summary>
public sealed class _0x1a95cfd1 : MonoBehaviour
{
    public int _0x596276ec(int _0x5f481451)
    {
        return this._0xd0b894fb(_0x5f481451) ? this._targets[_0x5f481451] : 12;
    }

    public string _0xe2dcb2f2(int _0xb8a15b52)
    {
        return this._0xd0b894fb(_0xb8a15b52) ? this._names[_0xb8a15b52] : string.Empty;
    }

    public float _0x14b049f7(int _0x308e1a6f)
    {
        return this._0xd0b894fb(_0x308e1a6f) ? this._fallSpeeds[_0x308e1a6f] : 2.6f;
    }

    [SerializeField]
    private string[] _names;
    [SerializeField]
    private int[] _targets;
    [SerializeField]
    private float[] _spawnIntervals;
    [SerializeField]
    private float[] _crownIntervals;
    [SerializeField]
    private float[] _fallSpeeds;
    public float _0x3f394375(int _0xa5b2239c)
    {
        return this._0xd0b894fb(_0xa5b2239c) ? this._crownIntervals[_0xa5b2239c] : 16f;
    }

    public float _0xf19c3530(int _0xfc0570b1)
    {
        return this._0xd0b894fb(_0xfc0570b1) ? this._spawnIntervals[_0xfc0570b1] : 1.95f;
    }

    public float _0xc2abad76(int _0x48918955)
    {
        return this._0xd0b894fb(_0x48918955) ? this._crownFirst[_0x48918955] : 12f;
    }

    public int _0x86b3dc30
    {
        get
        {
            return this._names == null ? 0 : this._names.Length;
        }
    }

    private bool _0xd0b894fb(int _0x3c156c20)
    {
        return this._names != null && _0x3c156c20 >= 0 && _0x3c156c20 < this._names.Length;
    }

    [SerializeField]
    private float[] _crownFirst;
}
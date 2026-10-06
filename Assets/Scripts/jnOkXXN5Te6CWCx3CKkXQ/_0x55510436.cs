/// <summary>
/// Everything one attempt is made of, produced by the generator and then replayed
/// by the spawner. Holding it as a value object (rather than spawning straight from
/// the random source) is what makes the run checkable BEFORE the player sees it -
/// CLAUDE-unity.md C.11 wants proven-clearable layouts, not hopeful ones.
/// </summary>
public sealed class _0x55510436
{
    public int[] Lane;
    public bool[] Crowned;
    public int[] Decor;
    public float[] Time;
    public int StartSection;
    public float[] Speed;
    public int[] Colour;
    public float StartX;
    public _0x55510436(int _0x7a0899f7, int _0x2817ecc2)
    {
        this.Count = _0x7a0899f7;
        this.Time = new float[_0x7a0899f7];
        this.Lane = new int[_0x7a0899f7];
        this.Colour = new int[_0x7a0899f7];
        this.Crowned = new bool[_0x7a0899f7];
        this.Speed = new float[_0x7a0899f7];
        this.Decor = new int[_0x2817ecc2];
    }

    public int Count;
}
using UnityEngine;

/// <summary>
/// Shows and hides one of OUR OWN scene objects. Codegen only reliably controls what
/// it created itself (CLAUDE-unity.md C.2), so every optional overlay is reached
/// through a serialized reference held here rather than by looking anything up.
/// </summary>
public sealed class _0x719cb13d : MonoBehaviour
{
    public void _0x3ffd2908()
    {
        this._0x6594c513(!this._0x8137a7fd);
    }

    [SerializeField]
    private bool _visibleOnStart;
    public bool _0x8137a7fd
    {
        get
        {
            return this._content != null && this._content.activeSelf;
        }
    }

    private void Start()
    {
        this._0x6594c513(this._visibleOnStart);
    }

    public void _0x6594c513(bool _0x4e330bd9)
    {
        if (this._content != null)
        {
            this._content.SetActive(_0x4e330bd9);
        }
    }

    [SerializeField]
    private GameObject _content;
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0xea334b23;

public class _0x2cc5c82d : MonoBehaviour
{
    public void _0x18b68593()
    {
        this.LastPopIndexes.RemoveAll(_0x79b4c762 => _0x79b4c762 == this.CurrentPopIndex);
        if (this.LastPopIndexes.Count <= 0)
            this._0xc6c86a07();
        else
            this._0x6dedd689(this.LastPopIndexes.Last());
    }

    public List<int> LastPopIndexes = new();
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x2cc5c82d>();
    }

    private void Start()
    {
        this.BackgroundHidden();
        foreach (_0x30b2da79 _0xad57b386 in this.Pops)
            if (_0xad57b386 != null)
                _0xad57b386.gameObject.SetActive(true);
    }

    private void BackgroundHidden()
    {
        this.BlurBackground.gameObject.SetActive(false);
    }

    private void _0x9b20f923(bool _0x6efab205 = false)
    {
        for (int _0x53b3a0f2 = 0; _0x53b3a0f2 < this.Pops.Count; ++_0x53b3a0f2)
            if (this.Pops[_0x53b3a0f2] != null && !(_0x53b3a0f2 == this.CurrentPopIndex && _0x6efab205))
                this.Pops[_0x53b3a0f2]._0xe6a4b14a();
    }

    public void _0x6dedd689(int _0x957aa11e)
    {
        this.CurrentPopIndex = _0x957aa11e;
        this.LastPopIndexes.Add(this.CurrentPopIndex);
        this._0x9b20f923(true);
        this._0xc8f1e670();
        this.Pops[_0x957aa11e].Show();
        foreach (GameObject _0xd2c35f59 in this.GameObjectsToHide)
            _0xd2c35f59.SetActive(false);
    }

    public GameObject BlurBackground;
    private void _0xc8f1e670()
    {
        this.BlurBackground.gameObject.SetActive(true);
    }

    private void _0x2e704bbd()
    {
        this.Invoke(nameof(this.BackgroundHidden), this.ScaleDuration);
    }

    public void _0xc6c86a07()
    {
        this.LastPopIndexes.Clear();
        this._0x9b20f923();
        foreach (GameObject _0x17460ad9 in this.GameObjectsToHide)
            if (_0x17460ad9 != null)
                _0x17460ad9.SetActive(true);
        this._0x2e704bbd();
    }

    public float ScaleDuration = 0.4f;
    public _0x30b2da79 _0x594a6eda(int _0xdfaf505d)
    {
        return this.Pops[_0xdfaf505d];
    }

    public List<_0x30b2da79> Pops;
    public List<GameObject> GameObjectsToHide;
    public static _0x2cc5c82d Instance;
    public int CurrentPopIndex;
}
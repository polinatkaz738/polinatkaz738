using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class _0xb99a7ab7 : MonoBehaviour
{
    private void _0x5c42df39()
    {
        float _0x85547cdf, _0x784d446b, _0x28888eb1, _0x3dcca36a;
        if (this._0xe31a1ea3 == _0x92ed0f2c.Landscape)
            this._0x2f3bf9f3.orthographicSize = 1f / this._0x2f3bf9f3.aspect * this._0x9fe68610 / 2f;
        else
            this._0x2f3bf9f3.orthographicSize = this._0x9fe68610 / 2f;
        this._0x0184e599 = 2f * this._0x2f3bf9f3.orthographicSize;
        this._0x73303a25 = this._0x0184e599 * this._0x2f3bf9f3.aspect;
        float _0xa02fc01d = this._0x2f3bf9f3.transform.position.x;
        float _0xea0bb71a = this._0x2f3bf9f3.transform.position.y;
        _0x85547cdf = _0xa02fc01d - this._0x73303a25 / 2;
        _0x784d446b = _0xa02fc01d + this._0x73303a25 / 2;
        _0x28888eb1 = _0xea0bb71a + this._0x0184e599 / 2;
        _0x3dcca36a = _0xea0bb71a - this._0x0184e599 / 2;
        this._0x19e07406 = new Vector3(_0x85547cdf, _0x3dcca36a, 0);
        this._0x9de0a7b4 = new Vector3(_0xa02fc01d, _0x3dcca36a, 0);
        this._0xfb87bcde = new Vector3(_0x784d446b, _0x3dcca36a, 0);
        this._0xe5bc2cc2 = new Vector3(_0x85547cdf, _0xea0bb71a, 0);
        this._0x884a8a4c = new Vector3(_0xa02fc01d, _0xea0bb71a, 0);
        this._0xe61d6c43 = new Vector3(_0x784d446b, _0xea0bb71a, 0);
        this._0xfedb7b7f = new Vector3(_0x85547cdf, _0x28888eb1, 0);
        this._0x49eb3ed6 = new Vector3(_0xa02fc01d, _0x28888eb1, 0);
        this._0xb41ccb5f = new Vector3(_0x784d446b, _0x28888eb1, 0);
    }

    private static _0xb99a7ab7 _0xb06b64c0;
    public enum _0x92ed0f2c
    {
        Landscape,
        Portrait
    }

    private _0x92ed0f2c _0xe31a1ea3 = _0x92ed0f2c.Portrait;
    private Vector3 _0xe5bc2cc2 { get; set; }
    private Vector3 _0x49eb3ed6 { get; set; }
    private Vector3 _0xfb87bcde { get; set; }

    private void Awake()
    {
        this._0x2f3bf9f3 = this.GetComponent<Camera>();
        _0xb06b64c0 = this;
        this._0x5c42df39();
    }

    private Vector3 _0xe61d6c43 { get; set; }

    private float _0x9fe68610 = 1;
    private Vector3 _0x19e07406 { get; set; }
    //public bool executeInUpdate;
    private float _0x73303a25 { get; set; }
    private Vector3 _0x9de0a7b4 { get; set; }
    private Vector3 _0x884a8a4c { get; set; }
    private Vector3 _0xfedb7b7f { get; set; }

    private new Camera _0x2f3bf9f3;
    private void OnDrawGizmos()
    {
        Gizmos.color = this._0x9ee0afe2;
        Matrix4x4 _0xe407d5bb = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
        if (this._0x2f3bf9f3.orthographic)
        {
            float _0x0300b8af = this._0x2f3bf9f3.farClipPlane - this._0x2f3bf9f3.nearClipPlane;
            float _0x010da6bc = (this._0x2f3bf9f3.farClipPlane + this._0x2f3bf9f3.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, _0x010da6bc), new Vector3(this._0x2f3bf9f3.orthographicSize * 2 * this._0x2f3bf9f3.aspect, this._0x2f3bf9f3.orthographicSize * 2, _0x0300b8af));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, this._0x2f3bf9f3.fieldOfView, this._0x2f3bf9f3.farClipPlane, this._0x2f3bf9f3.nearClipPlane, this._0x2f3bf9f3.aspect);
        }

        Gizmos.matrix = _0xe407d5bb;
    }

    private Vector3 _0xb41ccb5f { get; set; }
    private float _0x0184e599 { get; set; }

    private Color _0x9ee0afe2 = Color.white;
}
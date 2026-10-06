using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0xce12f8fe : MonoBehaviour
{
    public int LoadSceneId;
    public Button Button;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        if (this.IsLoadCurrentScene)
            this.Button.onClick.AddListener(() =>
            {
                _0x9d5294e1.Instance.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
            });
        else
            this.Button.onClick.AddListener(() => _0x9d5294e1.Instance.LoadSceneByIndex(this.LoadSceneId));
    }

    public bool IsLoadCurrentScene;
}
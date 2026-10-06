using UnityEngine;
using UnityEngine.UI;

public class _0x2a35787f : MonoBehaviour
{
    public Button NextTutorialButton;
    private void Start()
    {
        if (this.NextTutorialButton != null)
        {
            if (this.IsTutorialEndPanel)
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x8fc0d527.Instance._0x226158a4(this.EndTutorialPanelIndex));
                this.NextTutorialButton.onClick.AddListener(() => _0x9d5294e1.Instance._0x17042614());
            }
            else
            {
                this.NextTutorialButton.onClick.AddListener(() => _0x8fc0d527.Instance._0x226158a4(this.NextTutorialPanelIndex));
            }
        }

        if (this.TutorialEndButton != null)
        {
            this.TutorialEndButton.onClick.AddListener(() => _0x8fc0d527.Instance._0x226158a4(this.EndTutorialPanelIndex));
            this.TutorialEndButton.onClick.AddListener(() => _0x9d5294e1.Instance._0x17042614());
        }
    }

    public int EndTutorialPanelIndex = 1;
    public Button TutorialEndButton;
    public int NextTutorialPanelIndex;
    public bool IsTutorialEndPanel;
}
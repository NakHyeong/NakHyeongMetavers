using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Button closeButton;

    void Start()
    {
        // 시작할 때 패널이 자동으로 보여짐
        tutorialPanel.SetActive(true);
        closeButton.onClick.AddListener(() =>
        {
            tutorialPanel.SetActive(false);
        });
    }
}

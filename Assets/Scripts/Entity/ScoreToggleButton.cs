using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToggleButton : MonoBehaviour
{
    public GameObject scorePanel; // ScorePanel 오브젝트 연결 (점수 UI 전체)

    // 외부에서 호출 가능한 토글 함수 (버튼에 연결)
    public void ToggleScorePanel()
    {
        if (scorePanel != null)
        {
            bool isActive = scorePanel.activeSelf;
            scorePanel.SetActive(!isActive);
        }
    }

    // Exit 버튼에서 호출할 닫기 함수 (단순히 꺼지게만)
    public void CloseScorePanel()
    {
        if (scorePanel != null)
        {
            scorePanel.SetActive(false);
        }
    }
}

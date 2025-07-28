using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject restartButton;
    public GameObject exitButton;

    void Start()
    {
        if (restartButton == null)
            Debug.LogError("restart text is null");

        if (scoreText == null)
            Debug.LogError("score text is null");

        if (exitButton == null)
            Debug.LogError("exitButton is null");

        // 게임 시작 시 두 버튼 모두 비활성화
        restartButton.gameObject.SetActive(false);
        exitButton.SetActive(false);
    }

    public void SetRestart()
    {
        restartButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    void Start()
    {
        if (restartText == null)
            Debug.LogError("restartText가 할당되지 않았습니다.");
        if (scoreText == null)
            Debug.LogError("scoreText가 할당되지 않았습니다.");

        restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetRestart(bool active)
    {
        restartText.gameObject.SetActive(active);
    }
}

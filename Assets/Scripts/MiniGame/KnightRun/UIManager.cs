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
            Debug.LogError("restartText�� �Ҵ���� �ʾҽ��ϴ�.");
        if (scoreText == null)
            Debug.LogError("scoreText�� �Ҵ���� �ʾҽ��ϴ�.");

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

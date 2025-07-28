using TMPro;
using UnityEngine;

public class MainMapScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI miniGameNameText;   // 미니게임 이름 텍스트
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        void Start()
        {
            int bestScore = PlayerPrefs.GetInt("HighScore", 0);
            int lastScore = PlayerPrefs.GetInt("LastScore", 0);

            miniGameNameText.text = "나이트런";

            bestScoreText.text = $"베스트 점수: {bestScore}";
            lastScoreText.text = $"이번 점수: {lastScore}";
        }

    }

}
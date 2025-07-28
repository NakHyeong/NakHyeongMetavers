using TMPro;
using UnityEngine;

public class MainMapScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI miniGameNameText;   // 미니게임 이름 텍스트
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);

        miniGameNameText.text = "KnightRun";

        bestScoreText.text = $"BestScore: {bestScore}";
        lastScoreText.text = $"LastScore: {lastScore}";
    }
}

using TMPro;
using UnityEngine;

public class MainMapScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI miniGameNameText;   // �̴ϰ��� �̸� �ؽ�Ʈ
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        void Start()
        {
            int bestScore = PlayerPrefs.GetInt("HighScore", 0);
            int lastScore = PlayerPrefs.GetInt("LastScore", 0);

            miniGameNameText.text = "����Ʈ��";

            bestScoreText.text = $"����Ʈ ����: {bestScore}";
            lastScoreText.text = $"�̹� ����: {lastScore}";
        }

    }

}
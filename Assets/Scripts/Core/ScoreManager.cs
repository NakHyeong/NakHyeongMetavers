using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int score = 0;

    private bool alreadySaved = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환시 파괴 방지
        }
        else
        {
            Destroy(gameObject); //중복방지
        }
    }

    public void AddScore(int value) //점수누적호출
    {
        score += value;
        
    }

    public void ResetScore() //점수초기화
    {
        score = 0;
        alreadySaved = false;

    }
    public void SaveScoresIfNeeded() // 저장중복방지
    {
        if (alreadySaved) return;

        SaveHighScore();
        SaveLastScore();

        alreadySaved = true; // 저장 후 다시 저장되지 않도록 플래그 설정
    }
    public void SaveHighScore()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    public void SaveLastScore() //마지막점수저장
    {
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();
        alreadySaved = true;
    }
    public int GetHighScore() //저장된 최고점수불러오기
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public int GetLastScore() //저장된 마지막점수불러오기
    {
        return PlayerPrefs.GetInt("LastScore", 0);
    }
}

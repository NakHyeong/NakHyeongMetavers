using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        // UI 업데이트 제거
    }

    public void ResetScore()
    {
        score = 0;
        // UI 업데이트 제거
    }

    // 나머지 저장/불러오기 메서드 유지
}

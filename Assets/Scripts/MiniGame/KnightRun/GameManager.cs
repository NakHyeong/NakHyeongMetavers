using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int currentScore = 0;

    private UIManager uiManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // 싱글톤 중복 방지

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart(true);
        // 필요 시 게임 오버 상태 처리 변수 추가 가능
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

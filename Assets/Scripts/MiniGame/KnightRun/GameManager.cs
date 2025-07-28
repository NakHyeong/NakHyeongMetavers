using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager; // 게임 매니저 클래스의 유일한 인스턴스를 저장하는 static 변수

    public static GameManager Instance { get { return gameManager; } } // 외부에서 접근할 수 있게 제공

    private int currentScore = 0; // 점수

    UIManager uiManager; // UIManager 인스턴스

    public UIManager UIManager { get { return uiManager; } } // 외부에서 읽기 전용으로 제공
    public bool IsGameOver { get { return isGameOver; } }
    private bool isGameOver = false;


    private void Awake()
    {
        gameManager = this; // 싱글톤 인스턴스로 등록
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0); // 게임 시작 시 0점으로 UI 초기화
        Time.timeScale = 1f; // 혹시 이전에 0으로 멈췄다면 다시 정상화
        isGameOver = false;   // 게임 시작 시 게임오버 초기화
    }
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f;
        Debug.Log("Game Over");
        uiManager.SetRestart(); // UI에서 재시작 텍스트 표시
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 다시 불러옴
    }


    public void ExitToZEP()
    {
        Time.timeScale = 1f; // 씬 전환 전 시간 정지 해제
        SceneManager.LoadScene("MainGame");
    }

    public void EndGame()
    {
        // ScoreManager의 최고 점수 저장 호출 
        ScoreManager.Instance.SaveHighScore();

        // ScoreManager에 마지막 점수 저장 호출
        ScoreManager.Instance.SaveLastScore();
    }
}

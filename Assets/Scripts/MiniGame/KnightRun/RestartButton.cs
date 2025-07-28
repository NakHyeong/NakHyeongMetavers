using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnClickRestart()
    {
        if (GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.RestartGame();
        }
    }
}

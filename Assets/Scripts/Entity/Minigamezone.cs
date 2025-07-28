using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameZone : MonoBehaviour
{
    [SerializeField] private GameObject interactionPopup; // UI ÆË¾÷ (¿¹: Press Space or Click to Start)

    private bool isPlayerInZone = false;

    private void Update()
    {
        if (isPlayerInZone && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene("KnightRun"); // ¾À ÀÌ¸§ °íÁ¤
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;

            if (interactionPopup != null)
                interactionPopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;

            if (interactionPopup != null)
                interactionPopup.SetActive(false);
        }
    }
}

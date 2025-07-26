using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactionTrigger : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = false;
    }
}

//상호작용 가능한 오브젝트에 BoxCollider2D (IsTrigger 체크) 추가
//위 스크립트 붙이기
//sceneNameToLoad에 이동할 씬 이름 입력


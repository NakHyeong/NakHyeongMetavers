using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}


//상호작용 가능한 오브젝트에 BoxCollider2D (IsTrigger 체크) 추가
//위 스크립트 붙이기
//sceneNameToLoad에 이동할 씬 이름 입력


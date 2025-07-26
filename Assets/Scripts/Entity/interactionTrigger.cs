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

//��ȣ�ۿ� ������ ������Ʈ�� BoxCollider2D (IsTrigger üũ) �߰�
//�� ��ũ��Ʈ ���̱�
//sceneNameToLoad�� �̵��� �� �̸� �Է�


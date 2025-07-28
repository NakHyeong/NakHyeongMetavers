using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToggleButton : MonoBehaviour
{
    public GameObject scorePanel; // ScorePanel ������Ʈ ���� (���� UI ��ü)

    // �ܺο��� ȣ�� ������ ��� �Լ� (��ư�� ����)
    public void ToggleScorePanel()
    {
        if (scorePanel != null)
        {
            bool isActive = scorePanel.activeSelf;
            scorePanel.SetActive(!isActive);
        }
    }

    // Exit ��ư���� ȣ���� �ݱ� �Լ� (�ܼ��� �����Ը�)
    public void CloseScorePanel()
    {
        if (scorePanel != null)
        {
            scorePanel.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Ground�� ����
    public float groundWidth = 3f;

    private void Awake()
    {
        // �ڽ� ������Ʈ �� SpriteRenderer�� ã�Ƽ� groundWidth�� ����
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            groundWidth = sr.bounds.size.x;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name}�� �ڽ� SpriteRenderer�� �����ϴ�.");
            groundWidth = 3f; // �⺻�� �Ҵ�
        }
    }

    // ��ġ ���ġ �Լ�: ���� ��ġ�� �޾Ƽ� ���� �Ÿ� �����ʿ� ��ġ��Ű��
    public Vector3 SetRandomPlace(Vector3 lastPos)
    {
        Vector3 newPos = lastPos;
        newPos.x += groundWidth; // ���� �Ÿ� ������ �̵�

        transform.position = newPos;
        return newPos;
    }
}

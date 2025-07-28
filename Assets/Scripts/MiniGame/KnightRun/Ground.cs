using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Ground의 길이
    public float groundWidth = 3f;

    private void Awake()
    {
        // 자식 오브젝트 중 SpriteRenderer를 찾아서 groundWidth를 설정
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            groundWidth = sr.bounds.size.x;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name}에 자식 SpriteRenderer가 없습니다.");
            groundWidth = 3f; // 기본값 할당
        }
    }

    // 위치 재배치 함수: 이전 위치를 받아서 일정 거리 오른쪽에 위치시키기
    public Vector3 SetRandomPlace(Vector3 lastPos)
    {
        Vector3 newPos = lastPos;
        newPos.x += groundWidth; // 일정 거리 오른쪽 이동

        transform.position = newPos;
        return newPos;
    }
}

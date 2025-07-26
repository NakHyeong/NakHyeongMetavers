using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;         // 따라갈 대상

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // 기본 위치 = 타겟 위치
        Vector3 newPosition = target.position;

        // Z 고정 (카메라 원래 위치 유지)
        newPosition.z = transform.position.z;

        // 카메라 위치 갱신 (즉시 이동)
        transform.position = newPosition;
    }
}

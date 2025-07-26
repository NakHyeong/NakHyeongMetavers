using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float widthPaddingMin = 4f;
    public float widthPaddingMax = 6f;

    public float holeWidthMin = 1f;  // 최소 구멍 크기 (x축 스케일)
    public float holeWidthMax = 3f;  // 최대 구멍 크기

    // 이전 위치 받아서 새로운 위치와 크기를 랜덤으로 정함
    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        // 1. 이전 구멍 위치에서 x축 거리 랜덤으로 이동
        float randomDistance = Random.Range(widthPaddingMin, widthPaddingMax);
        Vector3 placePosition = lastPosition + new Vector3(randomDistance, 0, 0);

        // 2. 구멍 너비 랜덤으로 조정 (x축 스케일)
        float randomWidth = Random.Range(holeWidthMin, holeWidthMax);
        Vector3 newScale = transform.localScale;
        newScale.x = randomWidth;
        transform.localScale = newScale;

        // 3. 위치 적용
        transform.position = placePosition;

        return placePosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float widthPaddingMin = 4f;
    public float widthPaddingMax = 6f;

    // 위치 설정
    public Vector3 SetRandomPlace(Vector3 lastPosition, int totalCount)
    {
        float randomDistance = Random.Range(widthPaddingMin, widthPaddingMax);
        Vector3 placePosition = lastPosition + new Vector3(randomDistance, 0, 0);
        transform.position = placePosition;
        return placePosition;
    }
}


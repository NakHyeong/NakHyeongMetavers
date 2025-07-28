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

        // 4. ScoreZone 위치도 Hole 위치에 맞춰 상대 위치 조정 (필요 시 y값 등 조절)
        Transform scoreZone = transform.Find("ScoreZone");
        if (scoreZone != null)
        {
            Vector3 localPos = scoreZone.localPosition;
            // 예시: Y 위치를 살짝 아래로 내려서 플레이어가 반드시 지나가도록 조정
            localPos.y = -0.5f;
            scoreZone.localPosition = localPos;
        }
        // 5. ScoreZone 초기화
        ScoreZone scoreZoneScript = scoreZone.GetComponent<ScoreZone>();
        if (scoreZoneScript != null)
        {
            scoreZoneScript.ResetScore();
        }

        return placePosition;
    }
    public int GetScoreByWidth()
    {
        float width = transform.localScale.x;

        float range = holeWidthMax - holeWidthMin;
        float lowerThird = holeWidthMin + range / 3f;
        float upperThird = holeWidthMax - range / 3f;

        if (width <= lowerThird) // 좁은 구멍
            return 1;
        else if (width >= upperThird) // 넓은 구멍
            return 3;
        else // 중간 크기
            return 2;
    }

}

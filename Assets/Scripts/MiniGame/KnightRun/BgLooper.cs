using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 10; // 배경 개수
    public int holeCount;

    // Hole 및 Ground 마지막 위치 추적 변수
    public Vector3 holeLastPosition = Vector3.zero;
    public Vector3 groundLastPosition = Vector3.zero;

    // 아침(BackgroundDay)과 밤(BackgroundNight) 배경 마지막 위치 추적 변수
    private Vector3 dayLastPosition = Vector3.zero;
    private Vector3 nightLastPosition = Vector3.zero;

    void Start()
    {
        // WaterHole (= Hole) 객체들 모두 가져오기
        Hole[] holes = GameObject.FindObjectsOfType<Hole>();
        if (holes.Length == 0)
        {
            Debug.LogError("Hole 오브젝트가 없습니다!");
            return;
        }

        holeLastPosition = holes[0].transform.position;
        holeCount = holes.Length;

        for (int i = 0; i < holeCount; i++)
        {
            holeLastPosition = holes[i].SetRandomPlace(holeLastPosition);
        }

        Ground[] grounds = GameObject.FindObjectsOfType<Ground>();
        if (grounds.Length == 0)
        {
            Debug.LogError("Ground 오브젝트가 없습니다!");
            return;
        }

        System.Array.Sort(grounds, (a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        // 가장 오른쪽에 위치한 Ground의 위치를 기준값으로 설정
        groundLastPosition = grounds[grounds.Length - 1].transform.position;

        // 아침 배경(BackgroundDay) 객체들 가져오기
        GameObject[] days = GameObject.FindGameObjectsWithTag("BackgroundDay");
        if (days.Length > 0)
        {
            // x 위치 기준 오름차순 정렬 (왼쪽 -> 오른쪽)
            System.Array.Sort(days, (a, b) => a.transform.position.x.CompareTo(b.transform.position.x));
            // 가장 오른쪽 아침 배경 위치 저장
            dayLastPosition = days[days.Length - 1].transform.position;
        }

        // 밤 배경(BackgroundNight) 객체들 가져오기
        GameObject[] nights = GameObject.FindGameObjectsWithTag("BackgroundNight");
        if (nights.Length > 0)
        {
            // x 위치 기준 오름차순 정렬
            System.Array.Sort(nights, (a, b) => a.transform.position.x.CompareTo(b.transform.position.x));
            // 가장 오른쪽 밤 배경 위치 저장
            nightLastPosition = nights[nights.Length - 1].transform.position;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger된 객체: " + collision.name);

        if (collision.CompareTag("BackgroundDay"))
        {
            // BoxCollider2D의 재배치할 거리
            float width = ((BoxCollider2D)collision).size.x;

            // 현재 위치 복사
            Vector3 pos = collision.transform.position;

            // 마지막 아침 배경 위치에서 오른쪽으로 이동 배치
            pos.x = dayLastPosition.x + width;
            pos.z = 0; // z는 0으로 고정

            // 위치 변경
            collision.transform.position = pos;

            // 마지막 아침 위치 업데이트
            dayLastPosition = pos;

            // SpriteRenderer 컴포넌트 가져와서 정렬 순서 설정
            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sortingOrder = 0; // 아침 배경 sortingOrder 0
            }

            return;
        }
        // 아침이 아닐경우 밤으로해서  밤 배경 처리
        else if (collision.CompareTag("BackgroundNight"))
        {
            float width = ((BoxCollider2D)collision).size.x;

            Vector3 pos = collision.transform.position;

            pos.x = nightLastPosition.x + width;
            pos.z = 0;

            collision.transform.position = pos;

            nightLastPosition = pos;

            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sortingOrder = 0; // 밤 배경 sortingOrder 0 
            }

            return;
        }

        //Hole(WaterHole) 충돌 시 재배치
        Hole hole = collision.GetComponent<Hole>();
        if (hole != null)
        {
            holeLastPosition = hole.SetRandomPlace(holeLastPosition);
        }

        Ground ground = collision.GetComponent<Ground>();
        if (ground != null)
        {
            
            groundLastPosition = ground.SetRandomPlace(groundLastPosition);
            return;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 10; // 배경 개수
    public int holeCount;
    public Vector3 holeLastPosition = Vector3.zero;
    public Vector3 groundLastPosition = Vector3.zero;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger된 객체: " + collision.name);

        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            pos.z = 0; // z값 고정
            collision.transform.position = pos;

            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                if (collision.name.Contains("Day"))
                {
                    sr.sortingOrder = 0; // Day가 앞에 보이도록 높은 숫자
                    Debug.Log("Day 배경 sortingOrder 1로 설정");
                }
                else if (collision.name.Contains("Night"))
                {
                    sr.sortingOrder = 1; // Night는 뒤쪽에 보이도록 낮은 숫자
                    Debug.Log("Night 배경 sortingOrder 0으로 설정");
                }
                else
                {
                    // 이름에 Day, Night가 없으면 기본값
                    sr.sortingOrder = 0;
                    Debug.Log("이름에 Day/Night 없음, sortingOrder 0으로 설정");
                }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5; // 배경 개수
    public int holeCount;
    public Vector3 holeLastPosition = Vector3.zero;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger된 객체: " + collision.name);

        //Background 충돌 시 재배치
        if (collision.CompareTag("Background")) // Tag 꼭 대소문자 맞춰주세요
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        //Hole(WaterHole) 충돌 시 재배치
        Hole hole = collision.GetComponent<Hole>();
        if (hole != null)
        {
            holeLastPosition = hole.SetRandomPlace(holeLastPosition);
        }
    }
}

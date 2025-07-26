using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int holeCount = 0;
    public Vector3 holeLastPosition = Vector3.zero;

    void Start()
    {
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
            holeLastPosition = holes[i].SetRandomPlace(holeLastPosition, holeCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hole hole = collision.GetComponent<Hole>();
        if (hole)
        {
            holeLastPosition = hole.SetRandomPlace(holeLastPosition, holeCount);
        }
    }
}

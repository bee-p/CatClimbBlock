using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObjectGenerator : MonoBehaviour
{
    public GameObject birdsPrefab;      // type: 0
    public GameObject rocketPrefab;     // type: 1

    public void GenerateEventObject(int type, float yPos)
    {
        if (type == 0)      // birds 생성
        {
            GameObject go = Instantiate(birdsPrefab);
            go.transform.position = new Vector3(-6f, yPos, 0f);
        }
        else if (type == 1) // rocket 생성
        {
            GameObject go = Instantiate(rocketPrefab);
            go.transform.position = new Vector3(-6f, yPos, 0f);
        }
    }
}

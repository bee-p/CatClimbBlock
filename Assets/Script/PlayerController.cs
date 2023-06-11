using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int count = 0;              // 블럭 카운트

    // 바로 위의 블럭을 가져와서 반환하는 함수
    private GameObject findBlock()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Block");   // 블럭들 가져오기

        return obj[count];
    }

    // 빨간 블럭이 맞다면 이동
    public void moveRedBlock()
    {
        Debug.Log("빨간 버튼을 눌렀습니다.");

        GameObject block = findBlock();

        if (block.name == "blockRedPrefab(Clone)")
        {
            Debug.Log("빨간 블럭이 맞습니다!");

            // 1. 블럭 한 단계 이동
            transform.position = new Vector3(block.transform.position.x, block.transform.position.y + 1, 0);

            // 2. 블럭 카운트 증가
            count++;
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    // 파란 블럭이 맞다면 이동
    public void moveBlueBlock()
    {
        Debug.Log("파란 버튼을 눌렀습니다.");

        GameObject block = findBlock();

        if (block.name == "blockBluePrefab(Clone)")
        {
            Debug.Log("파란 블럭이 맞습니다!");

            // 1. 블럭 한 단계 이동
            transform.position = new Vector3(block.transform.position.x, block.transform.position.y + 1, 0);

            // 2. 블럭 카운트 증가
            count++;
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    // 초록 블럭이 맞다면 이동
    public void moveGreenBlock()
    {
        Debug.Log("초록 버튼을 눌렀습니다.");

        GameObject block = findBlock();

        if (block.name == "blockGreenPrefab(Clone)")
        {
            Debug.Log("초록 블럭이 맞습니다!");

            // 1. 블럭 한 단계 이동
            transform.position = new Vector3(block.transform.position.x, block.transform.position.y + 1, 0);

            // 2. 블럭 카운트 증가
            count++;
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}

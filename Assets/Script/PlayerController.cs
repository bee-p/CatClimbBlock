using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int count = 0;              // 블럭 카운트

    // 바로 위의 블럭을 가져와서 반환하는 함수
    private GameObject FindNextBlock()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Block");   // 블럭들 가져오기

        return obj[count];
    }

    // 빨간 버튼을 눌렀을 때 실행할 함수
    public void ClickedRedButton()
    {
        // 다음 블럭 가져오기
        GameObject block = FindNextBlock();

        // 다음 블럭이 빨간 블럭이라면
        if (block.name == "blockRedPrefab(Clone)")
        {
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

    // 파란 버튼을 눌렀을 때 실행할 함수
    public void ClickedBlueButton()
    {
        // 다음 블럭 가져오기
        GameObject block = FindNextBlock();

        // 다음 블럭이 파란 블럭이라면
        if (block.name == "blockBluePrefab(Clone)")
        {
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

    // 초록 버튼을 눌렀을 때 실행할 함수
    public void ClickedGreenButton()
    {
        // 다음 블럭 가져오기
        GameObject block = FindNextBlock();

        // 다음 블럭이 초록 블럭이라면
        if (block.name == "blockGreenPrefab(Clone)")
        {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject gameDirector;
    GameObject eventObjectGenerator;

    private int count = 0;                  // 블럭 누적 카운트
    private int eventRatio = 5;             // 돌발 이벤트가 발생되는 확률
    private bool isPermitEvent = false;     // 이벤트 발동 허용 플래그
    private bool isActiveEvent = false;     // 현재 이벤트가 활성화 되었는지(진행 중인지) 여부
    private bool isGameOver = false;

    public int GetBlockCount()
    {
        return this.count;
    }

    public void SetEventRatio(int ratio)
    {
        this.eventRatio = ratio;
    }

    public void SetIsActiveEvent(bool isActiveEvent)
    {
        this.isActiveEvent = isActiveEvent;
    }

    // 바로 위의 블럭을 가져와서 반환하는 함수
    private GameObject FindNextBlock()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Block");   // 블럭들 가져오기

        return obj[count];
    }

    // 빨간 버튼을 눌렀을 때 실행할 함수
    public void ClickedRedButton()
    {
        ClickedButton("blockRedPrefab(Clone)");
    }

    // 파란 버튼을 눌렀을 때 실행할 함수
    public void ClickedBlueButton()
    {
        ClickedButton("blockBluePrefab(Clone)");
    }

    // 초록 버튼을 눌렀을 때 실행할 함수
    public void ClickedGreenButton()
    {
        ClickedButton("blockGreenPrefab(Clone)");
    }

    private void ClickedButton(string buttonName)
    {
        // 다음 블럭 가져오기
        GameObject block = FindNextBlock();

        // 다음 블럭과 누른 버튼의 색깔이 일치하고, 이벤트가 진행 중이 아니라면
        if (block.name == buttonName && !isActiveEvent)
        {
            // 1. 블럭 한 단계 이동
            transform.position = new Vector3(block.transform.position.x, block.transform.position.y + 1, 0);

            // 2. 블럭 카운트 증가
            count++;

            // 3. 이벤트 발동 허용 플래그 ON
            isPermitEvent = true;
        }
        else
        {
            Debug.Log("Game Over");

            gameDirector.GetComponent<GameDirector>().ShowGameOverUI();
            isGameOver = true;
        }
    }

    private void Start()
    { 
        this.gameDirector = GameObject.Find("GameDirector");
        this.eventObjectGenerator = GameObject.Find("EventObjectGenerator");
    }

    private void Update()
    {
        // 이벤트 발동이 허용된 상태인지 체크
        if (isPermitEvent)
        {
            int dice = Random.Range(1, 101);    // 1~100

            if (dice < eventRatio)
            {
                // 이벤트 발동
                isActiveEvent = true;
                
                int typeDice = Random.Range(0, 2);  // 0~1
                
                GameObject nextBlock = FindNextBlock();
                float yPos = nextBlock.transform.position.y;

                eventObjectGenerator.GetComponent<EventObjectGenerator>().GenerateEventObject(typeDice, yPos);
            }

            // 이벤트 발동 허용 플래그 내리기
            isPermitEvent = false;
        }

        // 현재 게임오버 상태인지 체크
        if (isGameOver)
        {
            // 캐릭터 밑으로 떨어지게 함
            GetComponent<BoxCollider2D>().isTrigger = true;

            // 처음 시작 지점 쯤까지 오면 (떨어지는 위치가 땅 위일 경우) 땅에 착지할 수 있도록 함
            if (transform.position.y < -5.1f)
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
                isGameOver = false;
            }
        }
    }
}

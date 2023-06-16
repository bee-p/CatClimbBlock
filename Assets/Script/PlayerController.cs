using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private GameObject gameDirector;
    private GameObject eventObjectGenerator;

    private AudioSource takeItemSound;              // 아이템 획득 효과음

    private int count = 0;                  // 블럭 누적 카운트
    private int eventRatio = 5;             // 돌발 이벤트가 발생되는 확률
    private bool isPermitEvent = false;     // 이벤트 발동 허용 플래그
    private bool isActiveEvent = false;     // 현재 이벤트가 활성화 되었는지(진행 중인지) 여부
    private bool isGameOver = false;        // 게임오버 플래그

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
        // 블럭들 가져오기
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Block");

        // 현재 기준 캐릭터 바로 위의 블럭 반환
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
            // 1-1. 한 단계 위의 블럭으로 이동
            transform.position = new Vector3(block.transform.position.x, block.transform.position.y + 1, 0);

            // 1-2. 오르기 효과음 재생
            GetComponent<AudioSource>().Play();

            // 1-3. 오르기 애니메이션 재생
            animator.Play("climb");

            // 2. 블럭 카운트 증가
            count++;

            // 3. 이벤트 발동 허용 플래그 ON
            isPermitEvent = true;
        }
        else
        {
            // 블럭 색이 일치하지 않거나, 이벤트가 진행 중일 때 버튼을 눌렀을 시 게임 오버
            Debug.Log("Game Over");

            gameDirector.GetComponent<GameDirector>().ShowGameOverUI();
            isGameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // switch item과 부딪쳤을 경우
        if (collision.name == "itemSwitchPrefab(Clone)")
        {
            // 획득 사운드 재생
            takeItemSound.Play();

            // 버튼 순서 교체 실시
            gameDirector.GetComponent<GameDirector>().SwitchButtonUI();
            
            // 아이템 제거
            Destroy(collision.gameObject);
        }
    }

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.gameDirector = GameObject.Find("GameDirector");
        this.eventObjectGenerator = GameObject.Find("EventObjectGenerator");

        this.takeItemSound = GameObject.Find("TakeItemSource").GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 이벤트 발동이 허용된 상태인지 체크
        if (isPermitEvent)
        {
            int dice = Random.Range(1, 101);    // 1~100

            if (dice < eventRatio)
            {
                // 이벤트 발동 플래그 ON
                isActiveEvent = true;

                // 이벤트 종류 선택 다이스
                // 0: 새, 1: 로켓
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
            if (transform.position.y < -4f)
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
                isGameOver = false;
            }
        }
    }
}

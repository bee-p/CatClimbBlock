using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private GameObject player;
    private GameObject blockGenerator;

    // 버튼의 위치를 서로 바꾸기 위해 사용
    private string[] buttonOrder = { "red", "blue", "green" };
    private RectTransform buttonRedPos;       // 빨간 버튼 위치
    private RectTransform buttonBluePos;      // 파란 버튼 위치
    private RectTransform buttonGreenPos;     // 초록 버튼 위치

    private GameObject currenScoreUI;   // 게임 중일 때 나타나는 현재 점수
    private GameObject lastScoreUI;     // 게임오버 됐을 때 나타나는 점수 UI

    public void SwitchButtonUI()    // 하단의 색 버튼 순서를 무작위로 바꾸는 함수
    {
        // 1. 순서 바꾸기
        string temp;
        int orderDice;

        // 버튼이 3개이므로 순서는 총 3번 바꾸도록 함
        for (int i = 0; i < 3; i++)
        {
            orderDice = Random.Range(0, 3); // 0~2

            // 랜덤으로 나온 위치의 색 이름과 i번째 색 이름을 서로 교체
            temp = buttonOrder[i];
            buttonOrder[i] = buttonOrder[orderDice];
            buttonOrder[orderDice] = temp;
        }

        // 2. 바뀐 순서로 버튼 UI 재배치
        int xPos = -300;

        for (int i = 0; i < 3; i++)
        {
            // 색 이름으로 판별
            switch (buttonOrder[i])
            {
                case "red":
                    buttonRedPos.anchoredPosition = new Vector2(xPos, buttonRedPos.anchoredPosition.y);
                    break;

                case "blue":
                    buttonBluePos.anchoredPosition = new Vector2(xPos, buttonBluePos.anchoredPosition.y);
                    break;

                case "green":
                    buttonGreenPos.anchoredPosition = new Vector2(xPos, buttonGreenPos.anchoredPosition.y);
                    break;
            }

            // x 좌표값 한 단계 증가
            xPos += 300;
        }
    }

    public void ShowGameOverUI()
    {
        // GameOverUI 활성화 (GameOver)
        lastScoreUI.transform.Find("gameOverPanel").gameObject.SetActive(true);

        // 최종 점수 가져와서 적용
        lastScoreUI.transform.Find("gameOverPanel").transform.Find("gameOver").transform.
            Find("lastScore").GetComponent<Text>().text = player.GetComponent<PlayerController>().GetBlockCount().ToString();

        // 기존 점수 UI 점수 초기화 및 숨기기
        currenScoreUI.transform.Find("backgroundScore").transform.Find("score").GetComponent<Text>().text = "0";
        currenScoreUI.transform.Find("backgroundScore").gameObject.SetActive(false);
    }

    public void ClickedGameOverUI()
    {
        // 게임 재시작
        SceneManager.LoadScene("GameScene");
    }

    private void Start()
    {
        // 초기 배경 음악 정지
        GameObject startAudio = GameObject.Find("StartAudio");
        Destroy(startAudio);

        player = GameObject.Find("cat");
        blockGenerator = GameObject.Find("BlockGenerator");

        buttonRedPos = GameObject.Find("buttonRed").GetComponent<RectTransform>();
        buttonBluePos = GameObject.Find("buttonBlue").GetComponent<RectTransform>();
        buttonGreenPos = GameObject.Find("buttonGreen").GetComponent<RectTransform>();

        currenScoreUI = GameObject.Find("currentScoreUI");
        lastScoreUI = GameObject.Find("lastScoreUI");
    }

    private void Update()
    {
        // 블럭을 오른 개수로 점수 업데이트
        currenScoreUI.transform.Find("backgroundScore").transform.
            Find("score").GetComponent<Text>().text = player.GetComponent<PlayerController>().GetBlockCount().ToString();

        // 레벨 디자인
        int currentCount = player.GetComponent<PlayerController>().GetBlockCount(); // 현재 오른 블럭의 개수 가져옴
        if (10 <= currentCount && currentCount < 18)
        {
            player.GetComponent<PlayerController>().SetEventRatio(7);
        }
        else if (18 <= currentCount && currentCount < 27)
        {
            player.GetComponent<PlayerController>().SetEventRatio(12);
        }
        else if (27 <= currentCount && currentCount < 35)
        {
            player.GetComponent<PlayerController>().SetEventRatio(15);
        }
        else if (35 <= currentCount && currentCount < 39)
        {
            player.GetComponent<PlayerController>().SetEventRatio(25);
        }
        else if (39 <= currentCount && currentCount < 48)
        {
            player.GetComponent<PlayerController>().SetEventRatio(32);

            // switch item 등장
            blockGenerator.GetComponent<BlockGenerator>().SetItemRatio(10);
        }
        else if (48 <= currentCount)
        {
            player.GetComponent<PlayerController>().SetEventRatio(26);

            // switch item 확률 증가
            blockGenerator.GetComponent<BlockGenerator>().SetItemRatio(20);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private GameObject player;

    private GameObject currenScoreUI;
    private GameObject lastScoreUI;

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
        SceneManager.LoadScene("GameScene");
    }

    private void Start()
    {
        player = GameObject.Find("cat");

        currenScoreUI = GameObject.Find("currentScoreUI");
        lastScoreUI = GameObject.Find("lastScoreUI");
    }

    private void Update()
    {
        currenScoreUI.transform.Find("backgroundScore").transform.
            Find("score").GetComponent<Text>().text = player.GetComponent<PlayerController>().GetBlockCount().ToString();

        // 레벨 디자인
        int currentCount = player.GetComponent<PlayerController>().GetBlockCount();
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
        }
        else if (48 <= currentCount)
        {
            player.GetComponent<PlayerController>().SetEventRatio(26);
        }
    }
}

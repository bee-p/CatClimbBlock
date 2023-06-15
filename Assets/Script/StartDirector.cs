using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    private GameObject highlight;
    private bool active = false;     // 하이라이트 활성화/비활성화 조작을 위한 변수

    public void ClickedStartButton()
    {
        // 게임 화면으로 이동
        SceneManager.LoadScene("GameScene");
    }

    private void ChangeActiveHighlight()
    {
        // 현재 active 값으로 하이라이트 이미지 활성화/비활성화
        highlight.transform.Find("highlightStart").gameObject.SetActive(active);

        // active 플래그 전환
        active = !active;
    }

    private void Start()
    {
        this.highlight = GameObject.Find("highlight");

        // 0.6초마다 하이라이트 활성화/비활성화 조작
        // 하이라이트 이미지가 깜빡깜빡하게 함
        InvokeRepeating("ChangeActiveHighlight", 0f, 0.6f);
    }
}

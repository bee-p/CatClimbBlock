using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    private GameObject highlight;
    private GameObject button;       // 버튼 클릭시 효과음 집어넣기 위해 가져옴
    private bool active = false;     // 하이라이트 활성화/비활성화 조작을 위한 변수

    // 다음 씬으로 이동하는 함수
    private void GoNextScene()
    {
        // 스토리 화면으로 이동
        SceneManager.LoadScene("StoryScene");
    }

    public void ClickedStartButton()
    {
        // 효과음 재생
        button.GetComponent<AudioSource>().Play();

        // 0.5초 뒤 다음 씬으로 이동
        Invoke("GoNextScene", 0.5f);
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
        this.button = GameObject.Find("buttonStart");
        this.highlight = GameObject.Find("highlight");

        // 0.47초마다 하이라이트 활성화/비활성화 조작
        // 하이라이트 이미지가 깜빡깜빡하게 함
        InvokeRepeating("ChangeActiveHighlight", 0f, 0.47f);
    }
}

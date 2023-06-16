using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDirector : MonoBehaviour
{
    private GameObject story;   // 스토리 이미지들을 담고 있는 상위 오브젝트 객체
    private int storyCount = 1; // 스토리 이미지 순서(2번째 이미지부터 동적으로 활성화)

    private void ShowStoryImage()
    {
        // 현재 순서의 이미지 띄움
        story.transform.GetChild(storyCount).gameObject.SetActive(true);
        // 순서 카운트 증가
        storyCount++;
    }

    void Start()
    {
        this.story = GameObject.Find("StoryImage");
        InvokeRepeating("ShowStoryImage", 1.2f, 1.2f);  // 1.2초 후, 1.2초 간격마다 ShowStoryImage() 실행
    }

    void Update()
    {
        if (storyCount > 3) // 3장을 활성화 시킨 상태라면
        {
            CancelInvoke("ShowStoryImage"); // 스토리 이미지 띄우는 함수 반복 실행 취소

            // 방금 전 띄웠던 이미지 비활성화
            story.transform.GetChild(storyCount - 1).gameObject.SetActive(false);
            // 바로 다음 이미지로 교체 (물고기를 따로 움직이게 하기 위함)
            story.transform.GetChild(storyCount).gameObject.SetActive(true);
            story.transform.GetChild(storyCount + 1).gameObject.SetActive(true);
        }
    }
}

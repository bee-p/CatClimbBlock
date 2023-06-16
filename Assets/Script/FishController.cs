using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishController : MonoBehaviour
{
    private Vector3 targetPos = new Vector3(0f, 1.4f, 0f);  // 물고기가 이동할 목표 지점
    private bool isNextScene = false;                       // 다음 씬으로 넘어가도 되는 지에 대한 여부

    // 다음 씬으로 넘어가는 함수
    private void GoNextScene()
    {
        // 게임 화면으로 넘어감
        SceneManager.LoadScene("GameScene");
    }

    void Update()
    {
        // 물고기를 목표 지점까지 서서히 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.01f);

        // 물고기가 목표 지점에 도착했다면
        if (transform.position == targetPos)
        {
            // 다음 씬으로 넘어가도 된다는 것을 표시
            isNextScene = true;
        }

        // 다음 씬으로 넘어가도 된다면
        if (isNextScene)
        {
            // 0.4초 후 다음 씬으로 넘어가기
            Invoke("GoNextScene", 0.4f);

            // 함수 중복 실행을 방지하기 위해 플래그 내리기
            isNextScene = false;
        }
    }
}

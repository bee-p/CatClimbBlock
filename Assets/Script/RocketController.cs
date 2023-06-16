using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private GameObject player;
    private float speed = 0.12f;     // 로켓이 날아가는 속도

    private void Start()
    {
        this.player = GameObject.Find("cat");
    }

    private void Update()
    {
        // speed 만큼 우측으로 등속 이동
        transform.Translate(speed, 0, 0);

        // 화면 밖으로 나가면 오브젝트를 소멸
        if (transform.position.x > 5.5f)
        {
            Destroy(gameObject);

            // 이벤트 진행 중임을 표시하는 플래그 내리기
            player.GetComponent<PlayerController>().SetIsActiveEvent(false);
        }
    }
}

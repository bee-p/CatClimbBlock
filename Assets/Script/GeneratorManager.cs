using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    private GameObject player;
    private GameObject blockGenerator;
    private GameObject backgroundGenerator;

    private int heightPoint = 9;      // 오브젝트를 생성할 기준 높이(캐릭터가 이 높이에 오면 생성)
    private int distance = 19;        // 배경 간 거리(높이 차)

    private void Start()
    {
        this.player = GameObject.Find("cat");
        this.blockGenerator = GameObject.Find("BlockGenerator");
        this.backgroundGenerator = GameObject.Find("BackgroundGenerator");
    }

    private void Update()
    {
        // 플레이어의 현재 높이가 기준 높이를 넘을 경우
        if (player.transform.position.y >= heightPoint)
        {
            // 블록, 배경 생성 플래그 올림
            blockGenerator.GetComponent<BlockGenerator>().setIsCreateBlock(true);
            backgroundGenerator.GetComponent<BackgroundGenerator>().setIsCreateBackground(true);

            // 기준 높이 업데이트
            heightPoint += distance;
        }
    }
}

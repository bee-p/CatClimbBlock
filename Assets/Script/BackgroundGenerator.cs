using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject bgSkyPrefab;
    public GameObject bgSkyToSpacePrefab;
    public GameObject bgSpacePrefab;

    private int count = 0;                      // 생성한 전체 배경 개수(누적)
    private int createHeight = 19;              // 실제 배경을 생성할 높이
    private int distance = 19;                  // 배경 간 거리(높이 차)
    private bool isCreateBackground = false;    // 배경 생성 트리거(true == 생성)

    public void SetIsCreateBackground(bool isCreateBackground)
    {
        this.isCreateBackground = isCreateBackground;
    }

    private void Update()
    {
        if (isCreateBackground)
        {
            GameObject background;

            if (count < 3)          // 하늘 배경 생성(초입-총 3개 생성)
            {
                background = Instantiate(bgSkyPrefab);
            }
            else if (count == 3)    // 하늘->우주 진입 배경 생성
            {
                background = Instantiate(bgSkyToSpacePrefab);
            }
            else                    // 우주 배경 생성(이후 단계)
            {
                background = Instantiate(bgSpacePrefab);
            }

            background.transform.position = new Vector3(0, createHeight, 0);

            createHeight += distance;   // 높이 업데이트
            count++;                    // 생성한 배경 수 +1
            isCreateBackground = false; // 플래그 다시 내리기
        }
    }
}

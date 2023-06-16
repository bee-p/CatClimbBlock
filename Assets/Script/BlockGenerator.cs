using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject blockRedPrefab;       // 빨강 블럭
    public GameObject blockBluePrefab;      // 파랑 블럭
    public GameObject blockGreenPrefab;     // 초록 블럭

    private float yPos = -2.3f;             // 블럭 높이(y좌표, 시작 높이는 -2.3)
    private float plusHeight = 3.2f;        // 블럭 사이 높이 간격
    private int count = 0;                  // 생성한 블럭 개수 카운트
    private int maxCount = 9;               // 한 번에 생성할 최대 블럭 개수
    private bool isCreateBlock = true;      // 블럭 생성 트리거(true == 생성)

    /** 편의상 switch item 생성 관련 코드는 이 스크립트에 구현했습니다. **/
    public GameObject switchItemPrefab;
    private int itemRatio = 0;              // switch item 생성 확률

    public void SetItemRatio(int itemRatio)
    {
        this.itemRatio = itemRatio;
    }

    public void SetIsCreateBlock(bool isCreateBlock)
    {
        this.isCreateBlock = isCreateBlock;
    }

    private void Update()
    {
        // 블럭을 생성해도 된다면
        if (isCreateBlock)
        {
            GameObject block;

            // 색상 선택 다이스(0: red, 1: blue, 2: green)
            int colorDice = Random.Range(0, 3);

            if (colorDice == 0)         // 빨간 블럭 생성
            {
                block = Instantiate(blockRedPrefab);
            }
            else if (colorDice == 1)    // 파란 블럭 생성
            {
                block = Instantiate(blockBluePrefab);
            }
            else                        // 초록 블럭 생성
            {
                block = Instantiate(blockGreenPrefab);
            }

            // 블럭의 x좌표값 다이스
            float xPosDice = Random.Range(-4, 5);
            block.transform.position = new Vector3(xPosDice, yPos, 0f);

            /** switch item 생성 여부 다이스 **/
            int createItemDice = Random.Range(1, 101);  // 1~100
            
            if (createItemDice < itemRatio)
            {   
                // switch item 생성
                GameObject item = Instantiate(switchItemPrefab);
                float itemYPos = block.transform.position.y + 1.6f;
                item.transform.position = new Vector3(block.transform.position.x, itemYPos, 0f);
            }
            /**    ----------------------    **/

            yPos += plusHeight;         // plusHeight만큼 높이 올림

            if (++count >= maxCount)    // maxCount개 생성하면 멈추도록 함
            {
                isCreateBlock = false;
                count = 0;              // 카운트 초기화
            }
        }
    }
}

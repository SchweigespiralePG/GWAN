using UnityEngine;
using System.Collections.Generic;


public class CardSlotGridManager : MonoBehaviour
{
    public GameObject cardSlotPrefab;
    public Transform cardGridParent;
    public Card[] cardDataArray; // 카드 데이터 배열
    public List<Page> pages;//페이지 참조

    void Start()
    {
        GenerateCardSlots();
    }

    void GenerateCardSlots()
    {
        int rows = 3; // 그리드 행 수
        int columns = 3; // 그리드 열 수
        float slotWidth = 0.3f; // 카드 슬롯의 가로 크기
        float slotHeight = 0.1f; // 카드 슬롯의 세로 크기
        float spacingX = 0.025f; // 가로 간격
        float spacingY = 0.2f; // 세로 간격
        float slotDepth = -0.5f; // 카드 슬롯의 Z 좌표 (카메라와 가까운 거리)

        // 페이지 중앙을 기준으로 슬롯의 부모 위치를 조정
        Vector3 targetPosition = new Vector3(0.232f, 0f, -6f); // 지정 좌표
        cardGridParent.localPosition = targetPosition;

        int cardIndex = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // 카드 슬롯의 위치 설정
                Vector3 slotPosition = new Vector3(
                    col * (slotWidth + spacingX) - (columns - 1) * (slotWidth + spacingX) * 0.5f,
                    -row * (slotHeight + spacingY) + (rows - 1) * (slotHeight + spacingY) * 0.5f,
                    slotDepth);

                Quaternion rotation = Quaternion.identity;

                GameObject cardSlot = Instantiate(cardSlotPrefab, Vector3.zero, rotation, cardGridParent);
                cardSlot.transform.localPosition = slotPosition; // 카드 슬롯의 로컬 좌표 조정

                CardSlot slotScript = cardSlot.GetComponent<CardSlot>();

                if (cardIndex < cardDataArray.Length)
                {
                    slotScript.SetCardData(cardDataArray[cardIndex]);
                    pages[cardIndex / (rows * columns)].SetupSlots(new Card[] { cardDataArray[cardIndex] });
                }

                cardIndex++;
            }
        }
    }






    void SetupCardSlots()
    {
        foreach (Page page in cardGridParent.GetComponentsInChildren<Page>())
        {
            page.cardSlots.Clear();
            page.cardSlots.AddRange(page.GetComponentsInChildren<CardSlot>());
            page.SetupSlots(cardDataArray);
        }
    }

}

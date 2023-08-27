using UnityEngine;
using System.Collections.Generic;


public class CardSlotGridManager : MonoBehaviour
{
    public GameObject cardSlotPrefab;
    public Transform cardGridParent;
    public Card[] cardDataArray; // ī�� ������ �迭
    public List<Page> pages;//������ ����

    void Start()
    {
        GenerateCardSlots();
    }

    void GenerateCardSlots()
    {
        int rows = 3; // �׸��� �� ��
        int columns = 3; // �׸��� �� ��
        float slotWidth = 0.3f; // ī�� ������ ���� ũ��
        float slotHeight = 0.1f; // ī�� ������ ���� ũ��
        float spacingX = 0.025f; // ���� ����
        float spacingY = 0.2f; // ���� ����
        float slotDepth = -0.5f; // ī�� ������ Z ��ǥ (ī�޶�� ����� �Ÿ�)

        // ������ �߾��� �������� ������ �θ� ��ġ�� ����
        Vector3 targetPosition = new Vector3(0.232f, 0f, -6f); // ���� ��ǥ
        cardGridParent.localPosition = targetPosition;

        int cardIndex = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // ī�� ������ ��ġ ����
                Vector3 slotPosition = new Vector3(
                    col * (slotWidth + spacingX) - (columns - 1) * (slotWidth + spacingX) * 0.5f,
                    -row * (slotHeight + spacingY) + (rows - 1) * (slotHeight + spacingY) * 0.5f,
                    slotDepth);

                Quaternion rotation = Quaternion.identity;

                GameObject cardSlot = Instantiate(cardSlotPrefab, Vector3.zero, rotation, cardGridParent);
                cardSlot.transform.localPosition = slotPosition; // ī�� ������ ���� ��ǥ ����

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

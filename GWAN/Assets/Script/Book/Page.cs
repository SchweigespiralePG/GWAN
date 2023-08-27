using UnityEngine;
using System.Collections.Generic;

public class Page : MonoBehaviour
{
    public GameObject cardSlotPrefab;
    public Transform cardSlotsParent;
    public List<CardSlot> cardSlots = new List<CardSlot>();

    public void SetupSlots(Card[] cardDataArray)
    {
        for (int i = 0; i < cardDataArray.Length; i++)
        {
            if (i < cardSlots.Count)
            {
                cardSlots[i].SetCardData(cardDataArray[i]);
            }
        }
    }

    void Start()
    {
        // ������ ��ġ ����
        RectTransform pageRectTransform = GetComponent<RectTransform>();
        if (pageRectTransform != null)
        {
            Vector3 desiredPosition = new Vector3(0.232f, 0f, -6f); // ���ϴ� ��ǥ�� ����
            pageRectTransform.localPosition = desiredPosition;
        }
    }

    public void ActivatePage()
    {
        gameObject.SetActive(true);
    }

    public void DeactivatePage()
    {
        gameObject.SetActive(false);
    }
}

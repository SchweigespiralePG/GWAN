using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private PlayerCardManager playerCardManager; // PlayerCardManager�� ������ ����

    public List<PlayerCardManager.PlayerCard> cards; // �ܺο��� ������ cards ����Ʈ

    private void Start()
    {
        // PlayerCardManager�� ã�Ƽ� �����մϴ�.
        playerCardManager = FindObjectOfType<PlayerCardManager>();
        cards = playerCardManager.cards;

        // cards ����Ʈ�� ����Ͽ� ���ϴ� �۾��� �����մϴ�.
    }

    public void CardButton()
    {

    }

}

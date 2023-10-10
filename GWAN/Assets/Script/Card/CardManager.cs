using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private PlayerCardManager playerCardManager; // PlayerCardManager를 참조할 변수

    public List<PlayerCardManager.PlayerCard> cards; // 외부에서 접근할 cards 리스트

    private void Start()
    {
        // PlayerCardManager를 찾아서 참조합니다.
        playerCardManager = FindObjectOfType<PlayerCardManager>();
        cards = playerCardManager.cards;

        // cards 리스트를 사용하여 원하는 작업을 수행합니다.
    }

    public void CardButton()
    {

    }

}

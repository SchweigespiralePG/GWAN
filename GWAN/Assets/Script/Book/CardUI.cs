using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Image cardImage;

    public void Setup(Card cardData)
    {
        cardImage.sprite = cardData.cardImage;
        cardImage.color = cardData.have ? Color.white : Color.black;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    //public Image cardImage;

    public void SetCardData(Card cardData)
    {
        //cardImage.sprite = cardData.cardImage;

        // 카드가 보유 상태인 경우
        if (cardData.have)
        {
            /*cardImage.color = Color.white;*/ // 카드 색상을 원래 색상으로 변경
            // 추가적인 설정 코드 추가 가능
        }
        else
        {
           /* cardImage.color = Color.gray;*/ // 카드 색상을 흑백으로 변경
            // 추가적인 설정 코드 추가 가능
        }
    }
}

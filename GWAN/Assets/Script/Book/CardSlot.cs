using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    //public Image cardImage;

    public void SetCardData(Card cardData)
    {
        //cardImage.sprite = cardData.cardImage;

        // ī�尡 ���� ������ ���
        if (cardData.have)
        {
            /*cardImage.color = Color.white;*/ // ī�� ������ ���� �������� ����
            // �߰����� ���� �ڵ� �߰� ����
        }
        else
        {
           /* cardImage.color = Color.gray;*/ // ī�� ������ ������� ����
            // �߰����� ���� �ڵ� �߰� ����
        }
    }
}

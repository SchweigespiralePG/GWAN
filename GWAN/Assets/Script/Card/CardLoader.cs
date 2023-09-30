using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class CardLoader : MonoBehaviour
{
    public TextAsset cardDataXML; // Unity ���¿��� XML ������ �Ҵ��� �� �ֵ��� public ������ ����մϴ�.

    private List<Card> cards = new List<Card>();

    void Start()
    {
        LoadCardData();
    }

    void LoadCardData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(cardDataXML.text);

        XmlNodeList cardNodes = xmlDoc.SelectNodes("Level_2_Basic_Forward_Card/card");

        foreach (XmlNode cardNode in cardNodes)
        {
            Card card = ScriptableObject.CreateInstance<Card>();

            card.cardName = cardNode.Attributes["name"].Value;
            card.cardRate = int.Parse(cardNode.Attributes["rate"].Value);
            card.cardImage = Resources.Load<Sprite>("CardImages/" + card.cardName); // �̹��� ���ҽ��� �ε��ؾ� �� ���

            // ������ �Ӽ��鵵 �о�ͼ� �Ҵ����ּ���.

            cards.Add(card);
        }

    }
}

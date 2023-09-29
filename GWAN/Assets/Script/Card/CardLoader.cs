using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class CardLoader : MonoBehaviour
{
    public TextAsset cardDataXML; // Unity 에셋에서 XML 파일을 할당할 수 있도록 public 변수를 사용합니다.

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
            card.cardImage = Resources.Load<Sprite>("CardImages/" + card.cardName); // 이미지 리소스를 로드해야 할 경우

            // 나머지 속성들도 읽어와서 할당해주세요.

            cards.Add(card);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerCardManager : MonoBehaviour
{
    [Serializable]
    public struct PlayerCard
    {
        public string name;
        public string description;
        public int ID;
        public int count;
        public string role;
        public int rate;
        public bool ReverseForward;
        public bool Extinction;
        public string bearer;
        public string AcquisitionDifficulty;
    }


    // 스탯 데이터를 저장할 리스트를 생성합니다.
    public List<PlayerCard> playercard = new List<PlayerCard>();

    public List<int> HaveCard = new List<int>();

    private DataManager dataManager;
    private void Start()
    {
        dataManager = DataManager.instance;
        HaveCard = dataManager.NowPlayerData.HaveCard;
        LoadStatsFromXML();
    }

    // XML 파일에서 스탯 데이터를 읽어와 리스트에 저장하는 메서드입니다.

    private void LoadStatsFromXML()
    {
        // XML 파일을 불러옵니다.
        TextAsset xmlFile = Resources.Load<TextAsset>("XML/Card");
        if (xmlFile == null)
        {
            Debug.LogError("XML 파일을 로드할 수 없습니다.");
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text);

        // <Card> 엘리먼트들을 가져옵니다.
        XmlNodeList cardNodes = xmlDoc.SelectNodes("/Card/card");

        foreach (XmlNode cardNode in cardNodes)
        {
            PlayerCard card = new PlayerCard();

            // 각각의 필드 값을 XML에서 가져와서 PlayerCard 구조체에 할당합니다.
            card.name = cardNode.Attributes["name"].Value;
            card.description = cardNode.Attributes["description"].Value;
            card.ID = int.Parse(cardNode.Attributes["ID"].Value);
            card.count = int.Parse(cardNode.Attributes["count"].Value);
            card.role = cardNode.Attributes["role"].Value;
            card.rate = int.Parse(cardNode.Attributes["rate"].Value);
            card.ReverseForward = bool.Parse(cardNode.Attributes["ReverseForward"].Value);
            card.Extinction = bool.Parse(cardNode.Attributes["Extinction"].Value);
            card.bearer = cardNode.Attributes["bearer"].Value;
            card.AcquisitionDifficulty = cardNode.Attributes["AcquisitionDifficulty"].Value;

            // PlayerCard를 playercard 리스트에 추가합니다.
            playercard.Add(card);
        }
    }

}

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


    // ���� �����͸� ������ ����Ʈ�� �����մϴ�.
    public List<PlayerCard> playercard = new List<PlayerCard>();

    public List<int> HaveCard = new List<int>();

    private DataManager dataManager;
    private void Start()
    {
        dataManager = DataManager.instance;
        HaveCard = dataManager.NowPlayerData.HaveCard;
        LoadStatsFromXML();
    }

    // XML ���Ͽ��� ���� �����͸� �о�� ����Ʈ�� �����ϴ� �޼����Դϴ�.

    private void LoadStatsFromXML()
    {
        // XML ������ �ҷ��ɴϴ�.
        TextAsset xmlFile = Resources.Load<TextAsset>("XML/Card");
        if (xmlFile == null)
        {
            Debug.LogError("XML ������ �ε��� �� �����ϴ�.");
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text);

        // <Card> ������Ʈ���� �����ɴϴ�.
        XmlNodeList cardNodes = xmlDoc.SelectNodes("/Card/card");

        foreach (XmlNode cardNode in cardNodes)
        {
            PlayerCard card = new PlayerCard();

            // ������ �ʵ� ���� XML���� �����ͼ� PlayerCard ����ü�� �Ҵ��մϴ�.
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

            // PlayerCard�� playercard ����Ʈ�� �߰��մϴ�.
            playercard.Add(card);
        }
    }

}

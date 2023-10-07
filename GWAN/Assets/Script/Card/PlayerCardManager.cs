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

    // XML ������ ��θ� �����մϴ�.
    string xmlFilePath = "Assets/Resources/XML/HaveCard.xml";

    // ���� �����͸� ������ ����Ʈ�� �����մϴ�.
    public List<PlayerCard> playercard = new List<PlayerCard>();

    private void Start()
    {
        try
        {
            // XML ������ �о�� ���� �����͸� �Ľ��մϴ�.
            LoadStatsFromXML();

            // ����Ʈ ������ ������մϴ�.
            DebugPlayerCardList();
        }
        catch (Exception e)
        {
            // ���ܰ� �߻��� ��� ���� �޽����� Unity Debug�� ����մϴ�.
            UnityEngine.Debug.LogError("Error loading stats: " + e.Message);
        }
    }

    // XML ���Ͽ��� ���� �����͸� �о�� ����Ʈ�� �����ϴ� �޼����Դϴ�.
    private void LoadStatsFromXML()
    {
        // XML ������ �ε��մϴ�.
        TextAsset xmlAsset = Resources.Load<TextAsset>("XML/HaveCard");
        if (xmlAsset == null)
        {
            UnityEngine.Debug.LogError("XML file not found at path: " + xmlFilePath);
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlAsset.text);

        // XML���� ��� "HaveCard" ������Ʈ�� �����ɴϴ�.
        XmlNodeList cardNodes = xmlDoc.SelectNodes("/HaveCard/card");

        foreach (XmlNode cardNode in cardNodes)
        {
            PlayerCard card = new PlayerCard();
            card.name = cardNode.SelectSingleNode("name").InnerText;
            card.description = cardNode.SelectSingleNode("description").InnerText;
            card.ID = int.Parse(cardNode.SelectSingleNode("ID").InnerText);
            card.count = int.Parse(cardNode.SelectSingleNode("count").InnerText);
            card.role = cardNode.SelectSingleNode("role").InnerText;
            card.rate = int.Parse(cardNode.SelectSingleNode("rate").InnerText);
            card.ReverseForward = bool.Parse(cardNode.SelectSingleNode("ReverseForward").InnerText);
            card.Extinction = bool.Parse(cardNode.SelectSingleNode("Extinction").InnerText);
            card.bearer = cardNode.SelectSingleNode("bearer").InnerText;
            card.AcquisitionDifficulty = cardNode.SelectSingleNode("AcquisitionDifficulty").InnerText;

            // �Ľ̵� �����͸� ����Ʈ�� �߰��մϴ�.
            playercard.Add(card);
        }

        // ������ �ε��� �Ϸ�Ǹ� ����Ʈ�� ����� ī�� ������ ����� �� �ֽ��ϴ�.
        Debug.Log("Loaded " + playercard.Count + " player cards from XML.");
    }

    // �÷��̾� ī�� ����Ʈ�� ������ϴ� �޼���
    private void DebugPlayerCardList()
    {
        if (playercard.Count > 0)
        {
            foreach (PlayerCard card in playercard)
            {
                Debug.Log("Name: " + card.name);
                Debug.Log("Description: " + card.description);
                Debug.Log("ID: " + card.ID);
                Debug.Log("Count: " + card.count);
                Debug.Log("Role: " + card.role);
                Debug.Log("Rate: " + card.rate);
                Debug.Log("ReverseForward: " + card.ReverseForward);
                Debug.Log("Extinction: " + card.Extinction);
                Debug.Log("Bearer: " + card.bearer);
                Debug.Log("AcquisitionDifficulty: " + card.AcquisitionDifficulty);
            }
        }
        else
        {
            Debug.Log("Player card list is empty.");
        }
    }
}

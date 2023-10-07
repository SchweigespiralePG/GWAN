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

    // XML 파일의 경로를 지정합니다.
    string xmlFilePath = "Assets/Resources/XML/HaveCard.xml";

    // 스탯 데이터를 저장할 리스트를 생성합니다.
    public List<PlayerCard> playercard = new List<PlayerCard>();

    private void Start()
    {
        try
        {
            // XML 파일을 읽어와 스탯 데이터를 파싱합니다.
            LoadStatsFromXML();

            // 리스트 내용을 디버그합니다.
            DebugPlayerCardList();
        }
        catch (Exception e)
        {
            // 예외가 발생한 경우 오류 메시지를 Unity Debug로 출력합니다.
            UnityEngine.Debug.LogError("Error loading stats: " + e.Message);
        }
    }

    // XML 파일에서 스탯 데이터를 읽어와 리스트에 저장하는 메서드입니다.
    private void LoadStatsFromXML()
    {
        // XML 파일을 로드합니다.
        TextAsset xmlAsset = Resources.Load<TextAsset>("XML/HaveCard");
        if (xmlAsset == null)
        {
            UnityEngine.Debug.LogError("XML file not found at path: " + xmlFilePath);
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlAsset.text);

        // XML에서 모든 "HaveCard" 엘리먼트를 가져옵니다.
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

            // 파싱된 데이터를 리스트에 추가합니다.
            playercard.Add(card);
        }

        // 데이터 로딩이 완료되면 리스트에 저장된 카드 정보를 사용할 수 있습니다.
        Debug.Log("Loaded " + playercard.Count + " player cards from XML.");
    }

    // 플레이어 카드 리스트를 디버그하는 메서드
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

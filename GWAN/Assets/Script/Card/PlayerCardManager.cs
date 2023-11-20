using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static PlayerCardManager;

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
        public string Url;
    }

    public GameObject Details;
    public List<Text>textboxs = new List<Text>();

    // ���� �����͸� ������ ����Ʈ�� �����մϴ�.
    public List<PlayerCard> playercard = new List<PlayerCard>();
    public List<PlayerCard> cards = new List<PlayerCard>(); // cards ����Ʈ�� �����մϴ�.
    public List<RawImage> cardimg = new List<RawImage>();
    public List<RawImage> descriptionimg = new List<RawImage>();
    public List<int> HaveCard = new List<int>();
    public List<GameObject> stars= new List<GameObject>();
    public List<GameObject> descriptionimgobj = new List<GameObject>();

    private DataManager dataManager;
    public static PlayerCardManager instance;
    private void Start()
    {
        dataManager = DataManager.instance;
        HaveCard = dataManager.NowPlayerData.HaveCard;
        LoadStatsFromXML();
        AddMatchingCardsToCardsList(HaveCard);
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
            card.Url = cardNode.Attributes["url"].Value;

            // PlayerCard�� playercard ����Ʈ�� �߰��մϴ�.
            playercard.Add(card);
        }
    }

    private List<PlayerCard> FindMatchingCards(List<int> ids)
    {
        List<PlayerCard> matchingCards = new List<PlayerCard>();
        foreach (int id in ids)
        {
            PlayerCard matchingCard = playercard.Find(card => card.ID == id);
            if (matchingCard.ID == id)
            {
                matchingCards.Add(matchingCard);
            }
        }
        return matchingCards;
    }

    // ����Ʈ�� ��ġ�ϴ� ī�带 �߰��ϴ� �Լ�
    private void AddMatchingCardsToCardsList(List<int> ids)
    {
        List<PlayerCard> matchingCards = FindMatchingCards(ids);
        cards.AddRange(matchingCards);

        StartCoroutine(LoadCardImages());
    }

    private IEnumerator LoadCardImages()
    {
        for (int i = 0; i < cardimg.Count; i++)
        {
            if (cards[i].Url != "null")
            {
                UnityWebRequest www = UnityWebRequestTexture.GetTexture(cards[i].Url);
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("�̹��� �ε� �� ���� �߻�: " + www.error);
                }
                else
                {
                    descriptionimg[i].texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                    cardimg[i].texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                    Debug.Log($"����Ϸ�{i}��ī��");
                }
            }
        }
    }


    public void cardbutton(int number)
    {
        Details.SetActive(true);
        if (textboxs.Count > 3)
        {
            textboxs[0].text = "NO." + cards[number].ID.ToString();
            textboxs[1].text = cards[number].name;
            textboxs[2].text = cards[number].role;
            textboxs[3].text = cards[number].description;

            descriptionimgobj.ForEach(img => img.SetActive(false));
            stars.ForEach(star => star.SetActive(false));
            for (int i = 0;i < cards[number].rate; i++)
            {
                stars[i].SetActive(true);
            }
            descriptionimgobj[number].SetActive(true);



        }
    }




}

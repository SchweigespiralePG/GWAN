using UnityEngine;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.IO;


public class StatManager : MonoBehaviour
{
    // ������ ������ ����ü �Ǵ� Ŭ������ �����մϴ�.
    [Serializable]
    public struct CharacterStats
    {
        public int ID;
        public string Name;
        public int Str;
        public int Con;
        public int Size;
        public int Edu;
        public int Apd;
        public int Dex;
        public int Int;
        public int Luck;
        public int Hp;
        public int RHp;
        public int Dp;
        public int Atk;
        public int AP;
    }

    // XML ������ ��θ� �����մϴ�.
    public string xmlFilePath = "Assets/Resources/XML/status.xml";

    // ���� �����͸� ������ ����Ʈ�� �����մϴ�.
    public List<CharacterStats> statsList = new List<CharacterStats>();


    public static StatManager instance;

    private void Start()
    {
        try
        {
            // XML ������ �о�� ���� �����͸� �Ľ��մϴ�.
            LoadStatsFromXML();
        }
        catch (Exception e)
        {
            // ���ܰ� �߻��� ��� ���� �޽����� Unity Debug�� ����մϴ�.
            UnityEngine.Debug.LogError("Error loading stats: " + e.Message);
        }
    }

    private void LoadStatsFromXML()
    {
        try
        {
            // XML ������ �о�ɴϴ�.
            TextAsset textAsset = Resources.Load<TextAsset>("XML/status");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(textAsset.text);

            // <BasicStats> ��� �ȿ� �ִ� <Stats> ��ҵ��� ��� �����ɴϴ�.
            XmlNodeList statsNodes = xmlDoc.SelectNodes("/BasicStats/Stats");

            // �� <Stats> ��ҿ��� ���� �����͸� �о�� ����Ʈ�� �߰��մϴ�.
            foreach (XmlNode statsNode in statsNodes)
            {
                CharacterStats stats = new CharacterStats();
                stats.ID = int.Parse(statsNode.Attributes["ID"].Value);
                stats.Name = statsNode.Attributes["Name"].Value;
                stats.Str = int.Parse(statsNode.Attributes["Str"].Value);
                stats.Con = int.Parse(statsNode.Attributes["Con"].Value);
                stats.Size = int.Parse(statsNode.Attributes["Size"].Value);
                stats.Edu = int.Parse(statsNode.Attributes["Edu"].Value);
                stats.Apd = int.Parse(statsNode.Attributes["Apd"].Value);
                stats.Dex = int.Parse(statsNode.Attributes["Dex"].Value);
                stats.Int = int.Parse(statsNode.Attributes["Int"].Value);
                stats.Luck = int.Parse(statsNode.Attributes["Luck"].Value);
                stats.Hp = int.Parse(statsNode.Attributes["Hp"].Value);
                stats.RHp = int.Parse(statsNode.Attributes["RHp"].Value);
                stats.Dp = int.Parse(statsNode.Attributes["Dp"].Value);
                stats.Atk = int.Parse(statsNode.Attributes["Atk"].Value);
                stats.AP = int.Parse(statsNode.Attributes["AP"].Value);

                // ���� �����͸� ����Ʈ�� �߰��մϴ�.
                statsList.Add(stats);
            }
        }
        catch (Exception e)
        {
            // ���ܰ� �߻��� ��� ���� �޽����� Unity Debug�� ����ϰ� ���ܸ� �ٽ� throw�մϴ�.
            UnityEngine.Debug.LogError("Error loading stats: " + e.Message);
            throw e;
        }
    }

}
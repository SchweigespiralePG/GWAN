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
    public void ModifyStats(int statID, int newStr, int newCon, int newSize, int newEdu, int newApd, int newDex, int newInt, int newLuck, int newHp, int newRHp, int newDp, int newAtk, int newAP)
    {
        // statID�� �ش��ϴ� ������ ã�Ƽ� �����մϴ�.
        CharacterStats statsToModify = statsList.Find(stat => stat.ID == statID);
        if (statsToModify.ID != 0)
        {
            statsToModify.Str = newStr;
            statsToModify.Con = newCon;
            statsToModify.Size = newSize;
            statsToModify.Edu = newEdu;
            statsToModify.Apd = newApd;
            statsToModify.Dex = newDex;
            statsToModify.Int = newInt;
            statsToModify.Luck = newLuck;
            statsToModify.Hp = newHp;
            statsToModify.RHp = newRHp;
            statsToModify.Dp = newDp;
            statsToModify.Atk = newAtk;
            statsToModify.AP = newAP;

            // ������ �����͸� XML ���Ͽ� �����մϴ�.
            SaveStatsToXML();
        }
    }

    private void SaveStatsToXML()
    {
        try
        {
            XmlDocument xmlDoc = new XmlDocument();

            // �̹� �����ϴ� XML ���� ����
            if (File.Exists(xmlFilePath))
            {
                xmlDoc.Load(xmlFilePath);
            }
            else
            {
                // �������� ������ ���ο� XML ���� ����
                XmlElement rootElement = xmlDoc.CreateElement("BasicStats");
                xmlDoc.AppendChild(rootElement);
            }

            // ���� �����͸� ��ȸ�ϸ� XML ��ҷ� �߰��մϴ�.
            foreach (CharacterStats stats in statsList)
            {
                XmlElement statsElement = xmlDoc.CreateElement("Stats");
                statsElement.SetAttribute("ID", stats.ID.ToString());
                statsElement.SetAttribute("Name", stats.Name);
                statsElement.SetAttribute("Str", stats.Str.ToString());
                statsElement.SetAttribute("Con", stats.Con.ToString());
                statsElement.SetAttribute("Size", stats.Size.ToString());
                statsElement.SetAttribute("Edu", stats.Edu.ToString());
                statsElement.SetAttribute("Apd", stats.Apd.ToString());
                statsElement.SetAttribute("Dex", stats.Dex.ToString());
                statsElement.SetAttribute("Int", stats.Int.ToString());
                statsElement.SetAttribute("Luck", stats.Luck.ToString());
                statsElement.SetAttribute("Hp", stats.Hp.ToString());
                statsElement.SetAttribute("RHp", stats.RHp.ToString());
                statsElement.SetAttribute("Dp", stats.Dp.ToString());
                statsElement.SetAttribute("Atk", stats.Atk.ToString());
                statsElement.SetAttribute("AP", stats.AP.ToString());

                xmlDoc.DocumentElement?.AppendChild(statsElement);
            }

            // XML ���Ͽ� �����մϴ�.
            xmlDoc.Save(xmlFilePath);
        }
        catch (Exception e)
        {
            // ���ܰ� �߻��� ��� ���� �޽����� Unity Debug�� ����մϴ�.
            UnityEngine.Debug.LogError("Error saving stats: " + e.Message);
        }
    }

}
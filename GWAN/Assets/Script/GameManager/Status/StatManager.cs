using UnityEngine;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.IO;


public class StatManager : MonoBehaviour
{
    // 스탯을 저장할 구조체 또는 클래스를 정의합니다.
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

    // XML 파일의 경로를 지정합니다.
    public string xmlFilePath = "Assets/Resources/XML/status.xml";

    // 스탯 데이터를 저장할 리스트를 생성합니다.
    public List<CharacterStats> statsList = new List<CharacterStats>();

    private void Start()
    {
        try
        {
            // XML 파일을 읽어와 스탯 데이터를 파싱합니다.
            LoadStatsFromXML();
        }
        catch (Exception e)
        {
            // 예외가 발생한 경우 오류 메시지를 Unity Debug로 출력합니다.
            UnityEngine.Debug.LogError("Error loading stats: " + e.Message);
        }
    }

    private void LoadStatsFromXML()
    {
        try
        {
            // XML 파일을 읽어옵니다.
            TextAsset textAsset = Resources.Load<TextAsset>("XML/status");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(textAsset.text);

            // <BasicStats> 요소 안에 있는 <Stats> 요소들을 모두 가져옵니다.
            XmlNodeList statsNodes = xmlDoc.SelectNodes("/BasicStats/Stats");

            // 각 <Stats> 요소에서 스탯 데이터를 읽어와 리스트에 추가합니다.
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

                // 스탯 데이터를 리스트에 추가합니다.
                statsList.Add(stats);
            }
        }
        catch (Exception e)
        {
            // 예외가 발생한 경우 오류 메시지를 Unity Debug로 출력하고 예외를 다시 throw합니다.
            UnityEngine.Debug.LogError("Error loading stats: " + e.Message);
            throw e;
        }
    }
    public void ModifyStats(int statID, int newStr, int newCon, int newSize, int newEdu, int newApd, int newDex, int newInt, int newLuck, int newHp, int newRHp, int newDp, int newAtk, int newAP)
    {
        // statID에 해당하는 스탯을 찾아서 수정합니다.
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

            // 수정된 데이터를 XML 파일에 저장합니다.
            SaveStatsToXML();
        }
    }

    private void SaveStatsToXML()
    {
        try
        {
            XmlDocument xmlDoc = new XmlDocument();

            // 이미 존재하는 XML 파일 열기
            if (File.Exists(xmlFilePath))
            {
                xmlDoc.Load(xmlFilePath);
            }
            else
            {
                // 존재하지 않으면 새로운 XML 문서 생성
                XmlElement rootElement = xmlDoc.CreateElement("BasicStats");
                xmlDoc.AppendChild(rootElement);
            }

            // 스탯 데이터를 순회하며 XML 요소로 추가합니다.
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

            // XML 파일에 저장합니다.
            xmlDoc.Save(xmlFilePath);
        }
        catch (Exception e)
        {
            // 예외가 발생한 경우 오류 메시지를 Unity Debug로 출력합니다.
            UnityEngine.Debug.LogError("Error saving stats: " + e.Message);
        }
    }

}
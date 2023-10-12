using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;

public class PlayerData
{
    //저장이름
    public string DataName = $"마지막 위치 ";

    //현재가지고 있는카드

    public List<int> HaveCard = new List<int>() { 51, 52, 53, 54, 55, 56, 57, 58, 59};

    //스테이터스
    public int ID = 0;
    public string Name = "";
    public int Str = 10;
    public int Con = 10;
    public int Size = 10;
    public int Edu = 10;
    public int Apd = 10;
    public int Dex = 10;
    public int Int = 10;
    public int Luck = 10;
    public int Hp = 10;
    public int RHp = 10;
    public int Dp = 10;
    public int Atk = 10;
    public int AP = 10;

    //위치
    public Vector3 PlayerPosition;

    //스테이지, 난이도
    public int Level;
    public int Act;

    //이벤트방문여부

    public List<int> eventvisitValue = new List<int>();

}


public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData NowPlayerData = new PlayerData();

    public string Route;
    public int SaveDataNumber;


    private void Awake()
    {
        Route = Application.persistentDataPath + "/SaveData";
        instance = this;
    }


    public void SaveData()
    {
        string data = JsonUtility.ToJson(NowPlayerData);
        File.WriteAllText(Route +  SaveDataNumber.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(Route + SaveDataNumber.ToString());
        NowPlayerData = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        SaveDataNumber = 0;
        NowPlayerData = new PlayerData();
    }
}

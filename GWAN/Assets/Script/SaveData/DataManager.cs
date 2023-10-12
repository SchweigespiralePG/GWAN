using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;

public class PlayerData
{
    //�����̸�
    public string DataName = $"������ ��ġ ";

    //���簡���� �ִ�ī��

    public List<int> HaveCard = new List<int>() { 51, 52, 53, 54, 55, 56, 57, 58, 59};

    //�������ͽ�
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

    //��ġ
    public Vector3 PlayerPosition;

    //��������, ���̵�
    public int Level;
    public int Act;

    //�̺�Ʈ�湮����

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

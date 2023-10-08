using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;

public class PlayerData
{
    //�����̸�
    public string DataName;

    //���簡���� �ִ�ī��

    public List<int> HaveCard = new List<int>();

    //�������ͽ�
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

    //��ġ
    public Vector3 PlayerPosition;

    //��������
    public List<int> stageValue = new List<int>();

    //�湮����

    public List<int> visitValue = new List<int>();

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
        SaveDataNumber = -1;
        NowPlayerData = new PlayerData();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
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

    private DataManager dataManager;

    private void Start()
    {
        dataManager = DataManager.instance;

        LoadStat();


    }

    void LoadStat()
    {
        if (dataManager != null && dataManager.NowPlayerData != null)
        {
            ID = dataManager.NowPlayerData.ID;
            Name = dataManager.NowPlayerData.Name;
            Str = dataManager.NowPlayerData.Str;
            Con = dataManager.NowPlayerData.Con;
            Size = dataManager.NowPlayerData.Size;
            Edu = dataManager.NowPlayerData.Edu;
            Apd = dataManager.NowPlayerData.Apd;
            Dex = dataManager.NowPlayerData.Dex;
            Int = dataManager.NowPlayerData.Int;
            Luck = dataManager.NowPlayerData.Luck;
            Hp = dataManager.NowPlayerData.Hp;
            RHp = dataManager.NowPlayerData.RHp;
            Dp = dataManager.NowPlayerData.Dp;
            Atk = dataManager.NowPlayerData.Atk;
            AP = dataManager.NowPlayerData.AP;
        }
        else
        {
            Debug.LogWarning("DataManager is not properly initialized or NowPlayerData is null.");
        }
    }

}

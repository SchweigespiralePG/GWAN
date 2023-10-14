using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public List<EnemyStat> enemys = new List<EnemyStat>();

    public GameObject playerbattledisplay;
    public GameObject BattleUI;

    public int playerspeed;
    public List<int> TurnOrder;
    private int TurnDexDecrease;
    private int AvgDex = 0;

    private bool isPlayerATurn = false;

    public static TurnManager instance;

    private void Start()
    {
        

    }

    public void IsBattle()
    {
        playerspeed = DataManager.instance.NowPlayerData.Dex;
        AvgDex = enemys.Sum(enemyStat => enemyStat.enemyStats.Dex);

        int player = playerspeed;
        TurnDexDecrease = Math.Min(AvgDex, player);

        if (TurnDexDecrease == player)
        {
            isPlayerATurn = true;
            Debug.Log("플레이어 A의 Dex가 더 작거나 같습니다.");
        }

        BattleUI.SetActive(true);

        StartTurn();
    }

    public void StartTurn()
    {
        if (enemys.All(enemy => enemy.IsDead))
        {
            Debug.Log("플레이이 승리");
            return;
        }
        
        if(isPlayerATurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    public void PlayerTurn()
    {
        playerbattledisplay.SetActive(true);

    }

    public void PlayerTutnEnd()
    {
        isPlayerATurn = false;
        StartTurn();
    }

    public void EnemyTurn()
    {

    }
}

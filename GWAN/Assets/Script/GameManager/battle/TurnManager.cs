using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public List<EnemyStat> enemys = new List<EnemyStat>();
    public List<EnemyHpBar> gobjenemysEnemyHp = new List<EnemyHpBar>();

    public GameObject playerbattledisplay;
    public GameObject BattleUI;

    public int playerspeed;
    public int TurnDexDecrease;
    public int AvgDex = 0;

    public bool isPlayerATurn = false;

    public static TurnManager instance;

    public void IsBattle()
    {
        playerspeed = DataManager.instance.NowPlayerData.Dex;
        AvgDex = AvgDex = enemys.Sum(enemyStat => enemyStat.enemyStats.Dex)/enemys.Count();

        TurnDexDecrease = Math.Min(AvgDex, playerspeed);

        if (TurnDexDecrease == playerspeed)
        {
            isPlayerATurn = true;
            Debug.Log("�÷��̾� A�� Dex�� �� �۰ų� �����ϴ�.");
        }

        BattleUI.SetActive(true);

        StartTurn();
    }

    public void StartTurn()
    {
        if (enemys.All(enemy => enemy.IsDead))
        {
            Debug.Log("�÷����� �¸�");
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
        Debug.Log("�÷��̾���");
        playerbattledisplay.SetActive(true);

    }

    public void PlayerTutnEnd()
    {
        Debug.Log("������");
        isPlayerATurn = false;
        StartTurn();
    }

    public void EnemyTurn()
    {

    }
    public void EnemyTurnEnd()
    {
        isPlayerATurn = true;
        StartTurn();
    }
}

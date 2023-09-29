using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public StatManager statManager;

    public int Id = 0;
    public int str = 15;
    public int con = 12;
    public int size = 10;
    public int edu = 14;
    public int apd = 13;
    public int dex = 11;
    public int intStat = 16;
    public int luck = 9;
    public int hp = 100;
    public int rHp = 100;
    public int dp = 50;
    public int atk = 20;
    public int ap = 10;
    public bool Dead = false;

    void Start()
    {
        // 플레이어 스탯 초기화
        statManager.ModifyStats(Id, str, con, size, edu, apd, dex, intStat, luck, hp, rHp, dp, atk, ap);
    }
}

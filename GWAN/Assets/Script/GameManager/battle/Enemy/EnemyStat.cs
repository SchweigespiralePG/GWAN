using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatManager;

public class EnemyStat : MonoBehaviour
{
    public StatManager StatManager;
    public int EnemyID;
    public CharacterStats enemyStats;
    public bool IsDead;
    private void Start()
    {
        Invoke("lord", 0.5f);
    }
    void lord()
    {
        enemyStats = StatManager.statsList[EnemyID];

    }
}

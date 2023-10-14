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
        enemyStats = StatManager.statsList[EnemyID];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Stat Player; // 플레이어 스탯을 연결할 변수
    public Stat Enemy;  // 적 스탯을 연결할 변수

    public TurnManager turnManager;

    void Start()
    {
        // 이제 Player와 Enemy 변수를 통해 스탯에 접근할 수 있습니다.
        Debug.Log("플레이어의 체력: " + Player.hp);
        Debug.Log("적의 체력: " + Enemy.hp);
    }

    public void IsDead(Stat TargetStat)
    {
        if (TargetStat.rHp <= 0)
        {
            TargetStat.Dead = true;
        }
    }

    public void PlayerAttack()
    {
        int playerDamage = Player.str + Player.atk;
        int enemtDf = Enemy.apd;
        
        Enemy.rHp -= (playerDamage - enemtDf);
        turnManager.OnNextPhaseButtonClicked();
        IsDead(Enemy);
    }

    public void EnemyAttack()
    {
        int enemtDamage = Enemy.str + Enemy.atk;
        int playerDf = Player.apd;

        Player.rHp -= (enemtDamage - playerDf);

        IsDead(Player);
    }
}

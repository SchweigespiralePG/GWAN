using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Stat Player; // �÷��̾� ������ ������ ����
    public Stat Enemy;  // �� ������ ������ ����

    public TurnManager turnManager;

    void Start()
    {
        // ���� Player�� Enemy ������ ���� ���ȿ� ������ �� �ֽ��ϴ�.
        Debug.Log("�÷��̾��� ü��: " + Player.hp);
        Debug.Log("���� ü��: " + Enemy.hp);
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

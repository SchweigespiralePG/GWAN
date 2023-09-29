using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Stat Player; // �÷��̾� ������ ������ ����
    public Stat Enemy;  // �� ������ ������ ����

    void Start()
    {
        // ���� Player�� Enemy ������ ���� ���ȿ� ������ �� �ֽ��ϴ�.
        Debug.Log("�÷��̾��� ü��: " + Player.hp);
        Debug.Log("���� ü��: " + Enemy.hp);
    }


    public void PlayerAttack()
    {
        int playerDamage = Player.str + Player.atk;
        int enemtDf = Enemy.apd;
        
        Enemy.rHp -= (playerDamage - enemtDf);
    }
    
    public void IsDead(Stat TargetStat)
    {
        if (TargetStat.rHp <= 0) { 
            TargetStat.Dead = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Character_Status characterStatus;  // Character_Status ��ũ��Ʈ�� �ν��Ͻ�

    private void Start()
    {
        characterStatus = GetComponent<Character_Status>();  // Character_Status ��ũ��Ʈ�� ���� ���� ������Ʈ���� Character_Status ��ũ��Ʈ�� ������
    }

    // ���� ���� �޼���
    public void ExecuteAttack(GameObject target)
    {
        // ��� ������Ʈ�� �����ϴ��� Ȯ��
        if (target != null)
        {
            Character_Status targetStatus = target.GetComponent<Character_Status>();
            if (targetStatus != null)
            {
                double damage = CalculateDamage(characterStatus.atk, targetStatus.ad_DP);
                targetStatus.TakeDamage(damage);
                Debug.Log(characterStatus.Name + "��(��) " + targetStatus.Name + "���� " + damage + "�� ���ظ� �������ϴ�.");
            }
        }
    }

    // ���ط� ���
    private double CalculateDamage(double attackerAtk, double targetAdDP)
    {
        double damage = attackerAtk - (targetAdDP / 2);
        damage = Mathf.Max((float)damage, 0);
        return damage;
    }
}

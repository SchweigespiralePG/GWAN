using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public void Attack(GameObject enemy)
    {
        Debug.Log("�Ͼ����ϴ�");
        //Debug.Log(enemy);
        /*Character_Status enemyStatus = enemy.GetComponent<Character_Status>();
        Debug.Log("��� �̸�: " + enemyStatus.Name);
        Debug.Log("��� ü��: " + enemyStatus.currentHP);
        if (enemyStatus == null)
        {
            Debug.LogError("���� ���� ������Ʈ���� Character_Status ��ũ��Ʈ�� ã�� ���߽��ϴ�.");
            return;
        }

        if (enemyStatus.isDefending)
        {
            // ��� ���� �� ������ �۾��� �̰��� �ۼ��ϼ���.
            Debug.Log("���� ��� ���Դϴ�.");
        }
        else
        {
            // ��� ���� �ƴ� �� ������ �۾��� �̰��� �ۼ��ϼ���.
            Debug.Log("���� ��� ���� �ƴմϴ�.");
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public void Attack(GameObject enemy)
    {
        Debug.Log("일없습니다");
        //Debug.Log(enemy);
        /*Character_Status enemyStatus = enemy.GetComponent<Character_Status>();
        Debug.Log("상대 이름: " + enemyStatus.Name);
        Debug.Log("상대 체력: " + enemyStatus.currentHP);
        if (enemyStatus == null)
        {
            Debug.LogError("적의 게임 오브젝트에서 Character_Status 스크립트를 찾지 못했습니다.");
            return;
        }

        if (enemyStatus.isDefending)
        {
            // 방어 중일 때 수행할 작업을 이곳에 작성하세요.
            Debug.Log("적이 방어 중입니다.");
        }
        else
        {
            // 방어 중이 아닐 때 수행할 작업을 이곳에 작성하세요.
            Debug.Log("적이 방어 중이 아닙니다.");
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Character_Status characterStatus;  // Character_Status 스크립트의 인스턴스

    private void Start()
    {
        characterStatus = GetComponent<Character_Status>();  // Character_Status 스크립트를 가진 게임 오브젝트에서 Character_Status 스크립트를 가져옴
    }

    // 공격 실행 메서드
    public void ExecuteAttack(GameObject target)
    {
        // 대상 오브젝트가 존재하는지 확인
        if (target != null)
        {
            Character_Status targetStatus = target.GetComponent<Character_Status>();
            if (targetStatus != null)
            {
                double damage = CalculateDamage(characterStatus.atk, targetStatus.ad_DP);
                targetStatus.TakeDamage(damage);
                Debug.Log(characterStatus.Name + "이(가) " + targetStatus.Name + "에게 " + damage + "의 피해를 입혔습니다.");
            }
        }
    }

    // 피해량 계산
    private double CalculateDamage(double attackerAtk, double targetAdDP)
    {
        double damage = attackerAtk - (targetAdDP / 2);
        damage = Mathf.Max((float)damage, 0);
        return damage;
    }
}

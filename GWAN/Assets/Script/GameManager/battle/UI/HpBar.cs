using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private Slider Hpber;
    public Stat stat;

    public float maxHp;
    public float curHp;
    public float hpUpdateSpeed = 5.0f; // HP 바가 얼마나 빨리 업데이트될지 조절할 변수

    void Start()
    {
        // Stat 스크립트로부터 초기 HP 값을 가져옵니다.
        maxHp = stat.hp;
        curHp = stat.rHp;

        // Slider의 초기 값을 설정합니다.
        Hpber.value = curHp / maxHp;
    }

    void UpdateHpBar()
    {
        maxHp = stat.hp;
        curHp = stat.rHp;
        // 보간된 값을 사용하여 HP 바를 부드럽게 업데이트합니다.
        float targetValue = curHp / maxHp;
        Hpber.value = Mathf.Lerp(Hpber.value, targetValue, Time.deltaTime * hpUpdateSpeed);
    }
}

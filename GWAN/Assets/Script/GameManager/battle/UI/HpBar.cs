using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private Slider Hpber;
    public PlayerStat Playerstat;

    public float maxHp;
    public float curHp;
    public float hpUpdateSpeed = 5.0f; // HP 바가 얼마나 빨리 업데이트될지 조절할 변수

    void Start()
    {
        // Playerstat을 초기화합니다.
        Playerstat = GameObject.Find("Player").GetComponent<PlayerStat>();
        if (Playerstat == null)
        {
            Debug.LogWarning("Playerstat component not found.");
            return;
        }

        // Stat 스크립트로부터 초기 HP 값을 가져옵니다.
        maxHp = Playerstat.Hp;
        curHp = Playerstat.RHp;

        // Slider의 초기 값을 설정합니다.
        Hpber.value = curHp / maxHp;
    }


    void UpdateHpBar()
    {
        maxHp = Playerstat.Hp;
        curHp = Playerstat.RHp;
        // 보간된 값을 사용하여 HP 바를 부드럽게 업데이트합니다.
        float targetValue = curHp / maxHp;
        Hpber.value = Mathf.Lerp(Hpber.value, targetValue, Time.deltaTime * hpUpdateSpeed);
    }
}

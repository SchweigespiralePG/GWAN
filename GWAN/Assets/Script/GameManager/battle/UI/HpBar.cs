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
    public float hpUpdateSpeed = 5.0f; // HP �ٰ� �󸶳� ���� ������Ʈ���� ������ ����

    void Start()
    {
        // Playerstat�� �ʱ�ȭ�մϴ�.
        Playerstat = GameObject.Find("Player").GetComponent<PlayerStat>();
        if (Playerstat == null)
        {
            Debug.LogWarning("Playerstat component not found.");
            return;
        }

        // Stat ��ũ��Ʈ�κ��� �ʱ� HP ���� �����ɴϴ�.
        maxHp = Playerstat.Hp;
        curHp = Playerstat.RHp;

        // Slider�� �ʱ� ���� �����մϴ�.
        Hpber.value = curHp / maxHp;
    }


    void UpdateHpBar()
    {
        maxHp = Playerstat.Hp;
        curHp = Playerstat.RHp;
        // ������ ���� ����Ͽ� HP �ٸ� �ε巴�� ������Ʈ�մϴ�.
        float targetValue = curHp / maxHp;
        Hpber.value = Mathf.Lerp(Hpber.value, targetValue, Time.deltaTime * hpUpdateSpeed);
    }
}

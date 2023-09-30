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
    public float hpUpdateSpeed = 5.0f; // HP �ٰ� �󸶳� ���� ������Ʈ���� ������ ����

    void Start()
    {
        // Stat ��ũ��Ʈ�κ��� �ʱ� HP ���� �����ɴϴ�.
        maxHp = stat.hp;
        curHp = stat.rHp;

        // Slider�� �ʱ� ���� �����մϴ�.
        Hpber.value = curHp / maxHp;
    }

    void UpdateHpBar()
    {
        maxHp = stat.hp;
        curHp = stat.rHp;
        // ������ ���� ����Ͽ� HP �ٸ� �ε巴�� ������Ʈ�մϴ�.
        float targetValue = curHp / maxHp;
        Hpber.value = Mathf.Lerp(Hpber.value, targetValue, Time.deltaTime * hpUpdateSpeed);
    }
}

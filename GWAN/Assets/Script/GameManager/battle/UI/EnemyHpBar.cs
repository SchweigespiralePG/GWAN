using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField]
    private Slider Hpber;
    public EnemyStat Enemystat;

    public static EnemyHpBar Instance;

    public string Enemyname;
    public float maxHp;
    public float curHp;
    public float hpUpdateSpeed = 5.0f; // HP �ٰ� �󸶳� ���� ������Ʈ���� ������ ����

    void Start()
    {
        Invoke("roldstata", 1f);
        
    }

    void roldstata()
    {
        // Playerstat�� �ʱ�ȭ�մϴ�.
        Enemystat = GameObject.Find(name).GetComponent<EnemyStat>();
        if (Enemystat == null)
        {
            Debug.LogWarning("Enemystat component not found.");
            return;
        }

        // Stat ��ũ��Ʈ�κ��� �ʱ� HP ���� �����ɴϴ�.
        maxHp = Enemystat.enemyStats.Hp;
        curHp = Enemystat.enemyStats.RHp;

        // Slider�� �ʱ� ���� �����մϴ�.
        Hpber.value = curHp / maxHp;
    }

    public void UpdateHpBar()
    {
        maxHp = Enemystat.enemyStats.Hp;
        curHp = Enemystat.enemyStats.RHp;
        // ������ ���� ����Ͽ� HP �ٸ� �ε巴�� ������Ʈ�մϴ�.
        Hpber.value = curHp / maxHp;
        //float targetValue = (float)curHp / (float)maxHp;
        //Hpber.value = Mathf.Lerp(Hpber.value, targetValue, Time.deltaTime * hpUpdateSpeed);
    }
}

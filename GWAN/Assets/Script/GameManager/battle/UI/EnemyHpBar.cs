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
    public float hpUpdateSpeed = 5.0f; // HP 바가 얼마나 빨리 업데이트될지 조절할 변수

    void Start()
    {
        Invoke("roldstata", 1f);
        
    }

    void roldstata()
    {
        // Playerstat을 초기화합니다.
        Enemystat = GameObject.Find(name).GetComponent<EnemyStat>();
        if (Enemystat == null)
        {
            Debug.LogWarning("Enemystat component not found.");
            return;
        }

        // Stat 스크립트로부터 초기 HP 값을 가져옵니다.
        maxHp = Enemystat.enemyStats.Hp;
        curHp = Enemystat.enemyStats.RHp;

        // Slider의 초기 값을 설정합니다.
        Hpber.value = curHp / maxHp;
    }

    public void UpdateHpBar()
    {
        maxHp = Enemystat.enemyStats.Hp;
        curHp = Enemystat.enemyStats.RHp;
        // 보간된 값을 사용하여 HP 바를 부드럽게 업데이트합니다.
        Hpber.value = curHp / maxHp;
        //float targetValue = (float)curHp / (float)maxHp;
        //Hpber.value = Mathf.Lerp(Hpber.value, targetValue, Time.deltaTime * hpUpdateSpeed);
    }
}

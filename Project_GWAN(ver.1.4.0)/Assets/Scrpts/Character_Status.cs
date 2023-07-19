using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Status : MonoBehaviour
{
    public string Name;      // 이름
    public int WIL;          // 정신력
    public double atk;       // 근력
    public double con;       // 건강
    public double siz;       // 크기
    public long edu;         // 지식
    public double adp;       // 반응속도
    public double dex;       // 속도
    public double INT;       // 지능
    public double luck;      // 행운
    public long maxHP;       // 최대 체력
    public long currentHP;   // 현재 체력
    public double ad_DP;     // 방어력
    public double ap_DP;     // 마법방어력
    public bool isDefending { get; private set; } = false;  //방어상태

    public BuffDebuffManager buffDebuffManager;  // 버프/디버프 매니저 참조

    // 스테이터스 초기화
    private void Start()
    {
        buffDebuffManager = new BuffDebuffManager();
        //InitializeStats();
    }

    // 스테이터스 초기화 메서드
    private void InitializeStats() 
    {
        InitializeName();
        InitializeWIL();
        InitializeAtk();
        InitializeCon();
        InitializeSiz();
        InitializeEdu();
        InitializeAdp();
        InitializeDex();
        InitializeINT();
        InitializeLuck();
        InitializeMaxHP();
        InitializeCurrentHP();
        InitializeAdDP();
        InitializeApDP();
    }

    private void InitializeName()
    {
        Name = "";   // 이름 초기화
    }

    private void InitializeWIL()
    {
        WIL = 0;     // 정신력 초기화
    }

    private void InitializeAtk()
    {
        atk = 0.0;   // 근력 초기화
    }

    private void InitializeCon()
    {
        con = 0.0;   // 건강 초기화
    }

    private void InitializeSiz()
    {
        siz = 0.0;   // 크기 초기화
    }

    private void InitializeEdu()
    {
        edu = 0;     // 지식 초기화
    }

    private void InitializeAdp()
    {
        adp = 0.0;   // 반응속도 초기화
    }

    private void InitializeDex()
    {
        dex = 0.0;   // 속도 초기화
    }

    private void InitializeINT()
    {
        INT = 0.0;   // 지능 초기화
    }

    private void InitializeLuck()
    {
        luck = 0.0;  // 행운 초기화
    }

    private void InitializeMaxHP()
    {
        maxHP = 0;   // 최대 체력 초기화
    }

    private void InitializeCurrentHP()
    {
        currentHP = 0;  // 현재 체력 초기화
    }

    private void InitializeAdDP()
    {
        ad_DP = 0.0;   // 방어력 초기화
    }

    private void InitializeApDP()
    {
        ap_DP = 0.0;   // 마법방어력 초기화
    }

    public void StartDefending()
    {
        Debug.Log("방어상태 활성");
        isDefending = true; //방어상태 활성
    }

    public void StopDefending()
    {
        Debug.Log("방어상태 비활성");
        isDefending = false;    //방어상태 비활성
    }

    // 대미지를 입는 메서드
    public void TakeDamage(double damage)
    {
        currentHP -= (long)damage;
        Debug.Log(Name + "이(가) " + damage + "의 피해를 입었습니다. 현재 체력: " + currentHP);

        // 체력이 0 이하일 경우에 대한 처리
        if (currentHP <= 0)
        {
            Die();
        }
    }

    // 사망 처리 메서드
    private void Die()
    {
        // 사망 시 수행해야 할 동작 및 게임 오버 등을 구현
        Debug.Log(Name + "이(가) 사망했습니다.");
        // 사망에 따른 추가적인 처리 작성
    }
}
public class BuffDebuff
{
    public string name;  // 버프 또는 디버프의 이름
    public int duration; // 버프 또는 디버프의 지속시간
    public int effect;   // 버프 또는 디버프의 효과 (예: 체력 증가, 방어력 감소 등)
    public Character_Status character; // 이 버프 또는 디버프가 적용되는 캐릭터
}

public class BuffDebuffManager
{
    public List<BuffDebuff> buffs;   // 버프 리스트
    public List<BuffDebuff> debuffs; // 디버프 리스트

    public BuffDebuffManager()
    {
        buffs = new List<BuffDebuff>();
        debuffs = new List<BuffDebuff>();
    }

    // 버프 처리 메서드
    public void ProcessBuffs()
    {
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            BuffDebuff bd = buffs[i];

            // 버프가 "힘"이면 힘 버프를 적용
            if (bd.name == "힘")
            {
                bd.character.atk += 1; // 캐릭터의 근력을 1 증가시킵니다.
            }

            // 버프 지속시간 감소
            bd.duration--;

            // 지속시간이 0 이하인 경우 리스트에서 제거
            if (bd.duration <= 0)
            {
                buffs.RemoveAt(i);
            }
        }
    }

    // 디버프 처리 메서드
    public void ProcessDebuffs()
    {
        for (int i = debuffs.Count - 1; i >= 0; i--)
        {
            BuffDebuff bd = debuffs[i];

            // 디버프가 "독"이면 독 디버프를 적용
            if (bd.name == "독")
            {
                bd.character.currentHP -= 1; // 캐릭터의 체력을 1 감소시킵니다.
            }

            // 디버프 지속시간 감소
            bd.duration--;

            // 지속시간이 0 이하인 경우 리스트에서 제거
            if (bd.duration <= 0)
            {
                debuffs.RemoveAt(i);
            }
        }
    }
}

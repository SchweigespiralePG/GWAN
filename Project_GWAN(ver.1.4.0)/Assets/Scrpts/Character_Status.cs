using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Status : MonoBehaviour
{
    public string Name;   // 이름
    public int WIL;       // 정신력

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

    // 스테이터스 초기화
    private void Start()
    {
        InitializeStats();
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
}

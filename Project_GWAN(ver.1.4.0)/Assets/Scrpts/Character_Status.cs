using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Status : MonoBehaviour
{
    public string Name;   // �̸�
    public int WIL;       // ���ŷ�

    public double atk;       // �ٷ�
    public double con;       // �ǰ�
    public double siz;       // ũ��
    public long edu;         // ����
    public double adp;       // �����ӵ�
    public double dex;       // �ӵ�
    public double INT;       // ����
    public double luck;      // ���
    public long maxHP;       // �ִ� ü��
    public long currentHP;   // ���� ü��
    public double ad_DP;     // ����
    public double ap_DP;     // ��������

    // �������ͽ� �ʱ�ȭ
    private void Start()
    {
        InitializeStats();
    }

    // �������ͽ� �ʱ�ȭ �޼���
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
        Name = "";   // �̸� �ʱ�ȭ
    }

    private void InitializeWIL()
    {
        WIL = 0;     // ���ŷ� �ʱ�ȭ
    }

    private void InitializeAtk()
    {
        atk = 0.0;   // �ٷ� �ʱ�ȭ
    }

    private void InitializeCon()
    {
        con = 0.0;   // �ǰ� �ʱ�ȭ
    }

    private void InitializeSiz()
    {
        siz = 0.0;   // ũ�� �ʱ�ȭ
    }

    private void InitializeEdu()
    {
        edu = 0;     // ���� �ʱ�ȭ
    }

    private void InitializeAdp()
    {
        adp = 0.0;   // �����ӵ� �ʱ�ȭ
    }

    private void InitializeDex()
    {
        dex = 0.0;   // �ӵ� �ʱ�ȭ
    }

    private void InitializeINT()
    {
        INT = 0.0;   // ���� �ʱ�ȭ
    }

    private void InitializeLuck()
    {
        luck = 0.0;  // ��� �ʱ�ȭ
    }

    private void InitializeMaxHP()
    {
        maxHP = 0;   // �ִ� ü�� �ʱ�ȭ
    }

    private void InitializeCurrentHP()
    {
        currentHP = 0;  // ���� ü�� �ʱ�ȭ
    }

    private void InitializeAdDP()
    {
        ad_DP = 0.0;   // ���� �ʱ�ȭ
    }

    private void InitializeApDP()
    {
        ap_DP = 0.0;   // �������� �ʱ�ȭ
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Status : MonoBehaviour
{
    public string Name;      // �̸�
    public int WIL;          // ���ŷ�
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
    public bool isDefending { get; private set; } = false;  //������

    public BuffDebuffManager buffDebuffManager;  // ����/����� �Ŵ��� ����

    // �������ͽ� �ʱ�ȭ
    private void Start()
    {
        buffDebuffManager = new BuffDebuffManager();
        //InitializeStats();
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

    public void StartDefending()
    {
        Debug.Log("������ Ȱ��");
        isDefending = true; //������ Ȱ��
    }

    public void StopDefending()
    {
        Debug.Log("������ ��Ȱ��");
        isDefending = false;    //������ ��Ȱ��
    }

    // ������� �Դ� �޼���
    public void TakeDamage(double damage)
    {
        currentHP -= (long)damage;
        Debug.Log(Name + "��(��) " + damage + "�� ���ظ� �Ծ����ϴ�. ���� ü��: " + currentHP);

        // ü���� 0 ������ ��쿡 ���� ó��
        if (currentHP <= 0)
        {
            Die();
        }
    }

    // ��� ó�� �޼���
    private void Die()
    {
        // ��� �� �����ؾ� �� ���� �� ���� ���� ���� ����
        Debug.Log(Name + "��(��) ����߽��ϴ�.");
        // ����� ���� �߰����� ó�� �ۼ�
    }
}
public class BuffDebuff
{
    public string name;  // ���� �Ǵ� ������� �̸�
    public int duration; // ���� �Ǵ� ������� ���ӽð�
    public int effect;   // ���� �Ǵ� ������� ȿ�� (��: ü�� ����, ���� ���� ��)
    public Character_Status character; // �� ���� �Ǵ� ������� ����Ǵ� ĳ����
}

public class BuffDebuffManager
{
    public List<BuffDebuff> buffs;   // ���� ����Ʈ
    public List<BuffDebuff> debuffs; // ����� ����Ʈ

    public BuffDebuffManager()
    {
        buffs = new List<BuffDebuff>();
        debuffs = new List<BuffDebuff>();
    }

    // ���� ó�� �޼���
    public void ProcessBuffs()
    {
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            BuffDebuff bd = buffs[i];

            // ������ "��"�̸� �� ������ ����
            if (bd.name == "��")
            {
                bd.character.atk += 1; // ĳ������ �ٷ��� 1 ������ŵ�ϴ�.
            }

            // ���� ���ӽð� ����
            bd.duration--;

            // ���ӽð��� 0 ������ ��� ����Ʈ���� ����
            if (bd.duration <= 0)
            {
                buffs.RemoveAt(i);
            }
        }
    }

    // ����� ó�� �޼���
    public void ProcessDebuffs()
    {
        for (int i = debuffs.Count - 1; i >= 0; i--)
        {
            BuffDebuff bd = debuffs[i];

            // ������� "��"�̸� �� ������� ����
            if (bd.name == "��")
            {
                bd.character.currentHP -= 1; // ĳ������ ü���� 1 ���ҽ�ŵ�ϴ�.
            }

            // ����� ���ӽð� ����
            bd.duration--;

            // ���ӽð��� 0 ������ ��� ����Ʈ���� ����
            if (bd.duration <= 0)
            {
                debuffs.RemoveAt(i);
            }
        }
    }
}

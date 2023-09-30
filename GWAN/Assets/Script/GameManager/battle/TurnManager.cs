using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Stat PlayerStat;
    public Stat EnemyStat;

    public Button[] buttons; // ��ư �迭

    private int playerADex;
    private int playerBDex;
    private int TurnDexDecrease;

    private int phase = 1;

    private bool isPlayerATurn = false;
    private bool isTurnEnd = false;

    void Start()
    {
        playerADex = PlayerStat.dex;
        playerBDex = EnemyStat.dex;
        TurnDexDecrease = Math.Min(playerADex, playerBDex);

        if (TurnDexDecrease == playerBDex)
        {
            isPlayerATurn = true;
            Debug.Log("�÷��̾� A�� Dex�� �� �۰ų� �����ϴ�.");
        }

        Debug.Log(phase+"������ ����");
        Debug.Log("�÷��̾� A�� Dex: " + playerADex);
        Debug.Log("�÷��̾� B�� Dex: " + playerBDex);

        StartTurn();
    }

    void StartTurn()
    {
        if (PlayerStat.Dead || EnemyStat.Dead)
        {
            if (PlayerStat.Dead)
            {
                Debug.Log("���� �¸��߽��ϴ�!");
            }
            else if (EnemyStat.Dead)
            {
                Debug.Log("�÷��̾ �¸��߽��ϴ�!");
            }

            Debug.Log("���� ����");

            return;
        }


        ProcessPlayerTurn();

        if (isTurnEnd)
        {
            Debug.Log(phase+"������ ����");
            phase += 1;

            playerADex = PlayerStat.dex;
            playerBDex = EnemyStat.dex;
            TurnDexDecrease = Math.Min(playerADex, playerBDex);
        }
    }

    void ProcessPlayerTurn()
    {
        if (isPlayerATurn)
        {
            Debug.Log("�÷��̾� A�� ��");
            playerADex -= TurnDexDecrease;
            NoOffButtons(true);
            Debug.Log("�÷��̾� A�� Dex ����: " + playerADex);
        }
        else
        {
            Debug.Log("�÷��̾� B�� ��");
            NoOffButtons(false);
            playerBDex -= TurnDexDecrease;
            Debug.Log("�÷��̾� B�� Dex ����: " + playerBDex);
        }

        if (playerADex <= 0 && playerBDex <= 0)
        {
            Debug.Log("������ ����");
            isTurnEnd = true;
        }
        else
        {
            // ���� ��ȯ
            isPlayerATurn = !isPlayerATurn;
        }
    }

    public void OnNextPhaseButtonClicked()
    {
        // ���� ������ ��ȯ
        StartTurn();
    }


    public void NoOffButtons(bool mode)
    {
        foreach (Button button in buttons)
        {
            button.interactable = mode;
        }
    }
}


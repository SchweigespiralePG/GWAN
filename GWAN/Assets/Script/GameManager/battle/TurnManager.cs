using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Stat PlayerStat;
    public Stat EnemyStat;

    public Button[] buttons; // 버튼 배열

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
            Debug.Log("플레이어 A의 Dex가 더 작거나 같습니다.");
        }

        Debug.Log(phase+"페이즈 시작");
        Debug.Log("플레이어 A의 Dex: " + playerADex);
        Debug.Log("플레이어 B의 Dex: " + playerBDex);

        StartTurn();
    }

    void StartTurn()
    {
        if (PlayerStat.Dead || EnemyStat.Dead)
        {
            if (PlayerStat.Dead)
            {
                Debug.Log("적이 승리했습니다!");
            }
            else if (EnemyStat.Dead)
            {
                Debug.Log("플레이어가 승리했습니다!");
            }

            Debug.Log("게임 종료");

            return;
        }


        ProcessPlayerTurn();

        if (isTurnEnd)
        {
            Debug.Log(phase+"페이즈 종료");
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
            Debug.Log("플레이어 A의 턴");
            playerADex -= TurnDexDecrease;
            NoOffButtons(true);
            Debug.Log("플레이어 A의 Dex 감소: " + playerADex);
        }
        else
        {
            Debug.Log("플레이어 B의 턴");
            NoOffButtons(false);
            playerBDex -= TurnDexDecrease;
            Debug.Log("플레이어 B의 Dex 감소: " + playerBDex);
        }

        if (playerADex <= 0 && playerBDex <= 0)
        {
            Debug.Log("페이즈 종료");
            isTurnEnd = true;
        }
        else
        {
            // 턴을 전환
            isPlayerATurn = !isPlayerATurn;
        }
    }

    public void OnNextPhaseButtonClicked()
    {
        // 다음 턴으로 전환
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


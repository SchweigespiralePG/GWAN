using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Battle_Manager : MonoBehaviour
{
    private bool isPlayerTurn = true;  // 플레이어 턴 여부를 나타내는 변수
    private int turnCount = 0;        // 턴 수를 카운트하는 변수

    // 게임 시작 시 호출되는 메서드
    private void Start()
    {
        // 게임을 시작하고 플레이어의 첫 번째 턴으로 설정
        StartPlayerTurn();
    }

    // 플레이어의 턴 시작
    private void StartPlayerTurn()
    {
        isPlayerTurn = true;
        turnCount++;
        Debug.Log("=== 턴 " + turnCount + " ===");
        Debug.Log("플레이어의 턴입니다.");
        // 플레이어의 턴에 필요한 동작 수행
        // 예: 플레이어 입력을 받아 공격을 실행하거나 다른 행동을 수행한다.
        // 다음에 호출될 메서드: EndPlayerTurn();
    }

    // 플레이어의 턴 종료
    private void EndPlayerTurn()
    {
        isPlayerTurn = false;
        Debug.Log("플레이어의 턴이 종료되었습니다.");

        // 상대 NPC 또는 적의 턴으로 전환하는 코드 작성
        // 예: StartEnemyTurn();
    }

    // 상대 NPC 또는 적의 턴 시작
    private void StartEnemyTurn()
    {
        Debug.Log("상대의 턴입니다.");
        // 상대 NPC 또는 적의 턴에 필요한 동작 수행
        // 예: 상대 NPC의 AI 동작을 실행하거나 미리 정의된 동작을 수행한다.
        // 다음에 호출될 메서드: EndEnemyTurn();
    }

    // 상대 NPC 또는 적의 턴 종료
    private void EndEnemyTurn()
    {
        Debug.Log("상대의 턴이 종료되었습니다.");

        // 다시 플레이어의 턴으로 전환하는 코드 작성
        // 예: StartPlayerTurn();
    }

    // 턴 전환 버튼을 클릭할 때 호출되는 메서드
    public void OnTurnButtonClicked()
    {
        if (isPlayerTurn)
        {
            EndPlayerTurn();
        }
        else
        {
            EndEnemyTurn();
        }
    }
}

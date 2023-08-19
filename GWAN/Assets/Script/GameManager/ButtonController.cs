using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    // UI 버튼에 대한 참조
    public Button attackButton;
    public Button defenseButton;
    public Button endTurnButton;

    // 턴 기반 전투 관리 스크립트에 대한 참조
    public Turn_Battle_Manager turnBattleManager;

    // 공격 관리 스크립트에 대한 참조
    public AttackScript attack;

    // 플레이어 캐릭터의 상태에 대한 참조
    public Character_Status playerStatus;

    private void Start()
    {
        // 각 버튼에 대해 이벤트 리스너를 설정합니다.
        // 각각의 버튼이 클릭되면 해당하는 메서드가 호출됩니다.
        attackButton.onClick.AddListener(OnAttackButtonClick);
        defenseButton.onClick.AddListener(OnDefenseButtonClick);
        endTurnButton.onClick.AddListener(OnEndTurnButtonClick);

        // Scene에서 Turn_Battle_Manager 컴포넌트를 찾아 참조로 저장합니다.
        turnBattleManager = GameObject.FindObjectOfType<Turn_Battle_Manager>();

        // Scene에서 AttackScript 컴포넌트를 찾아 참조로 저장합니다.
        attack = gameObject.GetComponent<AttackScript>();

        // "Player" 태그가 붙은 게임 오브젝트에서 Character_Status 컴포넌트를 찾아 참조로 저장합니다.
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Status>();
    }

    // 공격 버튼이 클릭되면 호출되는 메서드
    private void OnAttackButtonClick()
    {
        Debug.Log("공격 버튼이 클릭되었습니다.");

        GameObject enemy = turnBattleManager.GetEnemyCharacter();

        if (enemy == null)
        {
            Debug.LogError("적 게임 오브젝트를 찾지 못했습니다.");
            return;
        }
        Debug.Log("반환된 적 게임 오브젝트");
        Debug.Log(enemy);
        attack.Attack(enemy);


        // 방어 상태 비활성
        playerStatus.StopDefending();

        // 공격이 끝나면 플레이어의 턴을 종료합니다.
        turnBattleManager.EndPlayerTurn();
    }


    // 방어 버튼이 클릭되면 호출되는 메서드
    private void OnDefenseButtonClick()
    {
        Debug.Log("방어 버튼이 클릭되었습니다.");

        //방어상태 활성
        playerStatus.StartDefending();

        // 방어가 시작되면 플레이어의 턴을 종료합니다.
        turnBattleManager.EndPlayerTurn();
    }

    // 턴 넘기기 버튼이 클릭되면 호출되는 메서드
    private void OnEndTurnButtonClick()
    {
        Debug.Log("턴 넘기기 버튼이 클릭되었습니다.");

        //방어상태 비활성
        playerStatus.StopDefending();

        // 플레이어의 턴을 종료합니다.
        turnBattleManager.EndPlayerTurn();
    }
}

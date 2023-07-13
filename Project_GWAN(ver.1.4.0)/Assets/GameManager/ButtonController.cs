using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button attackButton;
    public Button defenseButton;
    public Button endTurnButton;

    private void Start()
    {
        // 공격 버튼 클릭 이벤트 연결
        attackButton.onClick.AddListener(OnAttackButtonClick);

        // 방어 버튼 클릭 이벤트 연결
        defenseButton.onClick.AddListener(OnDefenseButtonClick);

        // 턴 넘기기 버튼 클릭 이벤트 연결
        endTurnButton.onClick.AddListener(OnEndTurnButtonClick);
    }

    private void OnAttackButtonClick()
    {
        Debug.Log("공격 버튼이 클릭되었습니다.");
        // 여기에 공격 버튼이 클릭되었을 때 실행할 동작을 작성하세요.
    }

    private void OnDefenseButtonClick()
    {
        Debug.Log("방어 버튼이 클릭되었습니다.");
        // 여기에 방어 버튼이 클릭되었을 때 실행할 동작을 작성하세요.
    }

    private void OnEndTurnButtonClick()
    {
        Debug.Log("턴 넘기기 버튼이 클릭되었습니다.");
        // 여기에 턴 넘기기 버튼이 클릭되었을 때 실행할 동작을 작성하세요.
    }
}

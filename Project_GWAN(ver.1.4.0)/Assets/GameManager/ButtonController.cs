using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button attackButton;
    public Button defenseButton;
    public Button endTurnButton;

    // Turn_Battle_Manager ��ũ��Ʈ�� ���� ���� �߰�
    public Turn_Battle_Manager turnBattleManager;

    private void Start()
    {
        // ���� ��ư Ŭ�� �̺�Ʈ ����
        attackButton.onClick.AddListener(OnAttackButtonClick);

        // ��� ��ư Ŭ�� �̺�Ʈ ����
        defenseButton.onClick.AddListener(OnDefenseButtonClick);

        // �� �ѱ�� ��ư Ŭ�� �̺�Ʈ ����
        endTurnButton.onClick.AddListener(OnEndTurnButtonClick);

        // Turn_Battle_Manager ��ũ��Ʈ ���� ��������
        turnBattleManager = GameObject.FindObjectOfType<Turn_Battle_Manager>();
    }

    private void OnAttackButtonClick()
    {
        Debug.Log("���� ��ư�� Ŭ���Ǿ����ϴ�.");
        // ���⿡ ���� ��ư�� Ŭ���Ǿ��� �� ������ ������ �ۼ��ϼ���.
    }

    private void OnDefenseButtonClick()
    {
        Debug.Log("��� ��ư�� Ŭ���Ǿ����ϴ�.");
        // ���⿡ ��� ��ư�� Ŭ���Ǿ��� �� ������ ������ �ۼ��ϼ���.
    }

    private void OnEndTurnButtonClick()
    {
        Debug.Log("�� �ѱ�� ��ư�� Ŭ���Ǿ����ϴ�.");

        // �� ���� ��ư�� Ŭ���Ǹ� �÷��̾��� ���� ����
        turnBattleManager.EndPlayerTurn();
    }
}

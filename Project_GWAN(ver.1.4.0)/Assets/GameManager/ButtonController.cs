using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    // UI ��ư�� ���� ����
    public Button attackButton;
    public Button defenseButton;
    public Button endTurnButton;

    // �� ��� ���� ���� ��ũ��Ʈ�� ���� ����
    public Turn_Battle_Manager turnBattleManager;

    // ���� ���� ��ũ��Ʈ�� ���� ����
    public AttackScript attack;

    // �÷��̾� ĳ������ ���¿� ���� ����
    public Character_Status playerStatus;

    private void Start()
    {
        // �� ��ư�� ���� �̺�Ʈ �����ʸ� �����մϴ�.
        // ������ ��ư�� Ŭ���Ǹ� �ش��ϴ� �޼��尡 ȣ��˴ϴ�.
        attackButton.onClick.AddListener(OnAttackButtonClick);
        defenseButton.onClick.AddListener(OnDefenseButtonClick);
        endTurnButton.onClick.AddListener(OnEndTurnButtonClick);

        // Scene���� Turn_Battle_Manager ������Ʈ�� ã�� ������ �����մϴ�.
        turnBattleManager = GameObject.FindObjectOfType<Turn_Battle_Manager>();

        // Scene���� AttackScript ������Ʈ�� ã�� ������ �����մϴ�.
        attack = gameObject.GetComponent<AttackScript>();

        // "Player" �±װ� ���� ���� ������Ʈ���� Character_Status ������Ʈ�� ã�� ������ �����մϴ�.
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Status>();
    }

    // ���� ��ư�� Ŭ���Ǹ� ȣ��Ǵ� �޼���
    private void OnAttackButtonClick()
    {
        Debug.Log("���� ��ư�� Ŭ���Ǿ����ϴ�.");

        GameObject enemy = turnBattleManager.GetEnemyCharacter();

        if (enemy == null)
        {
            Debug.LogError("�� ���� ������Ʈ�� ã�� ���߽��ϴ�.");
            return;
        }
        Debug.Log("��ȯ�� �� ���� ������Ʈ");
        Debug.Log(enemy);
        attack.Attack(enemy);


        // ��� ���� ��Ȱ��
        playerStatus.StopDefending();

        // ������ ������ �÷��̾��� ���� �����մϴ�.
        turnBattleManager.EndPlayerTurn();
    }


    // ��� ��ư�� Ŭ���Ǹ� ȣ��Ǵ� �޼���
    private void OnDefenseButtonClick()
    {
        Debug.Log("��� ��ư�� Ŭ���Ǿ����ϴ�.");

        //������ Ȱ��
        playerStatus.StartDefending();

        // �� ���۵Ǹ� �÷��̾��� ���� �����մϴ�.
        turnBattleManager.EndPlayerTurn();
    }

    // �� �ѱ�� ��ư�� Ŭ���Ǹ� ȣ��Ǵ� �޼���
    private void OnEndTurnButtonClick()
    {
        Debug.Log("�� �ѱ�� ��ư�� Ŭ���Ǿ����ϴ�.");

        //������ ��Ȱ��
        playerStatus.StopDefending();

        // �÷��̾��� ���� �����մϴ�.
        turnBattleManager.EndPlayerTurn();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Battle_Manager : MonoBehaviour
{

    private bool isPlayerTurn = true;  // �÷��̾� �� ���θ� ��Ÿ���� ����
    private int turnCount = 0;        // �� ���� ī��Ʈ�ϴ� ����
    public GameObject playerGameObject;
    public GameObject enemyGameObject;

    private Character_Status playerCharacter;
    private Character_Status enemyCharacter;

    private ButtonController buttonController;  // ButtonController ��ũ��Ʈ ���� ����

    private void Start()
    {
        playerCharacter = playerGameObject.GetComponent<Character_Status>();
        enemyCharacter = enemyGameObject.GetComponent<Character_Status>();

        buttonController = GetComponent<ButtonController>();  // ButtonController ��ũ��Ʈ ����

        StartPlayerTurn();
    }

    public GameObject GetEnemyCharacter()
    {
        // ����� �� ���� ������Ʈ�� ��ȯ�մϴ�.
        return enemyGameObject;
    }


    private void StartPlayerTurn()
    {
        Debug.Log("=== �� ���� ===");
        Debug.Log("�÷��̾��� ���Դϴ�.");

        // �÷��̾� ĳ������ �������ͽ��� �����ͼ� ���
        Debug.Log("�÷��̾� �̸�: " + playerCharacter.Name);
        Debug.Log("�÷��̾� ü��: " + playerCharacter.currentHP);

        buttonController.attackButton.interactable = true;
        buttonController.defenseButton.interactable = true;
        buttonController.endTurnButton.interactable = true;
    }

    // �÷��̾��� �� ����
    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        Debug.Log("�÷��̾��� ���� ����Ǿ����ϴ�.");

        buttonController.attackButton.interactable = false;
        buttonController.defenseButton.interactable = false;
        buttonController.endTurnButton.interactable = false;
        // ��� NPC �Ǵ� ���� ������ ��ȯ�ϴ� �ڵ� �ۼ�
        StartEnemyTurn();
    }

    // ��� NPC �Ǵ� ���� �� ����
    private void StartEnemyTurn()
    {
        Debug.Log("����� ���Դϴ�.");
        Debug.Log("��� �̸�: " + enemyCharacter.Name);
        Debug.Log("��� ü��: " + enemyCharacter.currentHP);
        EndEnemyTurn();
        // ��� NPC �Ǵ� ���� �Ͽ� �ʿ��� ���� ����
        // ��: ��� NPC�� AI ������ �����ϰų� �̸� ���ǵ� ������ �����Ѵ�.
        // ������ ȣ��� �޼���: EndEnemyTurn();
    }

    // ��� NPC �Ǵ� ���� �� ����
    private void EndEnemyTurn()
    {
        Debug.Log("����� ���� ����Ǿ����ϴ�.");

        // �ٽ� �÷��̾��� ������ ��ȯ�ϴ� �ڵ� �ۼ�
        StartPlayerTurn();
    }

    // �� ��ȯ ��ư�� Ŭ���� �� ȣ��Ǵ� �޼���
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

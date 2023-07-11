using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Battle_Manager : MonoBehaviour
{
    private bool isPlayerTurn = true;  // �÷��̾� �� ���θ� ��Ÿ���� ����
    private int turnCount = 0;        // �� ���� ī��Ʈ�ϴ� ����
    private Character_Status playerCharacter;  // �÷��̾� ĳ������ �������ͽ�
    private Character_Status enemyCharacter;   // �� ĳ������ �������ͽ�

    private void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<Character_Status>();
        // "PlayerCharacter"�� �÷��̾� ĳ������ ���� ������Ʈ �̸��� �°� �����ؾ���

        enemyCharacter = GameObject.Find("EnemyCharacter").GetComponent<Character_Status>();
        // "EnemyCharacter"�� �� ĳ������ ���� ������Ʈ �̸��� �°� �����ؾ���

        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        Debug.Log("=== �� ���� ===");
        Debug.Log("�÷��̾��� ���Դϴ�.");

        // �÷��̾� ĳ������ �������ͽ��� �����ͼ� ���
        Debug.Log("�÷��̾� �̸�: " + playerCharacter.Name);
        Debug.Log("�÷��̾� ü��: " + playerCharacter.currentHP);

        EndPlayerTurn();
    }

    // �÷��̾��� �� ����
    private void EndPlayerTurn()
    {
        isPlayerTurn = false;
        Debug.Log("�÷��̾��� ���� ����Ǿ����ϴ�.");

        // ��� NPC �Ǵ� ���� ������ ��ȯ�ϴ� �ڵ� �ۼ�
        // ��: StartEnemyTurn();
    }

    // ��� NPC �Ǵ� ���� �� ����
    private void StartEnemyTurn()
    {
        Debug.Log("����� ���Դϴ�.");
        // ��� NPC �Ǵ� ���� �Ͽ� �ʿ��� ���� ����
        // ��: ��� NPC�� AI ������ �����ϰų� �̸� ���ǵ� ������ �����Ѵ�.
        // ������ ȣ��� �޼���: EndEnemyTurn();
    }

    // ��� NPC �Ǵ� ���� �� ����
    private void EndEnemyTurn()
    {
        Debug.Log("����� ���� ����Ǿ����ϴ�.");

        // �ٽ� �÷��̾��� ������ ��ȯ�ϴ� �ڵ� �ۼ�
        // ��: StartPlayerTurn();
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

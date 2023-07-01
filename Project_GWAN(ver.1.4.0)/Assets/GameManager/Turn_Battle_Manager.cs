using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Battle_Manager : MonoBehaviour
{
    private bool isPlayerTurn = true;  // �÷��̾� �� ���θ� ��Ÿ���� ����
    private int turnCount = 0;        // �� ���� ī��Ʈ�ϴ� ����

    // ���� ���� �� ȣ��Ǵ� �޼���
    private void Start()
    {
        // ������ �����ϰ� �÷��̾��� ù ��° ������ ����
        StartPlayerTurn();
    }

    // �÷��̾��� �� ����
    private void StartPlayerTurn()
    {
        isPlayerTurn = true;
        turnCount++;
        Debug.Log("=== �� " + turnCount + " ===");
        Debug.Log("�÷��̾��� ���Դϴ�.");
        // �÷��̾��� �Ͽ� �ʿ��� ���� ����
        // ��: �÷��̾� �Է��� �޾� ������ �����ϰų� �ٸ� �ൿ�� �����Ѵ�.
        // ������ ȣ��� �޼���: EndPlayerTurn();
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

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
        // ���� ��ư Ŭ�� �̺�Ʈ ����
        attackButton.onClick.AddListener(OnAttackButtonClick);

        // ��� ��ư Ŭ�� �̺�Ʈ ����
        defenseButton.onClick.AddListener(OnDefenseButtonClick);

        // �� �ѱ�� ��ư Ŭ�� �̺�Ʈ ����
        endTurnButton.onClick.AddListener(OnEndTurnButtonClick);
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
        // ���⿡ �� �ѱ�� ��ư�� Ŭ���Ǿ��� �� ������ ������ �ۼ��ϼ���.
    }
}

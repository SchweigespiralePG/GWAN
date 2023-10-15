using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCard : MonoBehaviour
{
    public GameObject book;

    private bool selectionModeActive = false;

    private void Update()
    {
        if (selectionModeActive)
        {
            if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        GameObject target = hit.collider.gameObject;
                        // ��(Ÿ��)�� ������ �� ���ϴ� ���� ����
                        Debug.Log("���� �����߽��ϴ�: " + target.name);

                        // ���⼭ ������ ��(Ÿ��)�� ���� �߰� �۾��� ����
                    }
                }
            }
        }
    }
    public void cardon(int buttonNumber)
    {
        Debug.Log("ī���ư �۵�");
        book.SetActive(false);
        atk();
        switch (PlayerCardManager.instance.cards[buttonNumber].ID)
        {
            case 51:
                break;
            case 52:
                break;
            case 53:
                break;
            case 54:
                break;
            case 55:
                break;
            case 56:
                break;
            case 57:
                break;
            case 58:
                break;
            case 59:
                break;
            case 60:
                break;
            default: break;
        }
    }

    public void atk()
    {

        selectionModeActive = !selectionModeActive;
        TurnManager.instance.PlayerTutnEnd();
    }


}

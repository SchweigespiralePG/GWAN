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
            if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        GameObject target = hit.collider.gameObject;
                        // 적(타겟)을 선택한 후 원하는 동작 수행
                        Debug.Log("적을 선택했습니다: " + target.name);

                        // 여기서 선택한 적(타겟)에 대한 추가 작업을 수행
                    }
                }
            }
        }
    }
    public void cardon(int buttonNumber)
    {
        Debug.Log("카드버튼 작동");
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

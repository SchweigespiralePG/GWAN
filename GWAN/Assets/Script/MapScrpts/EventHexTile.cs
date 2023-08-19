using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHexTile : MonoBehaviour
{
    void Update()
    {
        // ���콺 Ŭ�� �Ǵ� ��ġ �Է� Ȯ��
        if (Input.GetMouseButtonDown(0))
        {
            // ī�޶󿡼� ���콺 ��ġ�� ���� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���̰� ��ü�� ��Ҵ��� Ȯ��
            if (Physics.Raycast(ray, out hit))
            {
                // ���� ��ü�� HexTile ������Ʈ�� ������ �ִ��� Ȯ��
                HexTile hexTile = hit.transform.GetComponent<HexTile>();
                if (hexTile != null)
                {
                    // ���� HexTile���� HexType ��������
                    HexType type = hexTile.hexType;
                    Debug.Log($"���� HexTile�� HexType: {type}");
                }
            }
        }
    }
}

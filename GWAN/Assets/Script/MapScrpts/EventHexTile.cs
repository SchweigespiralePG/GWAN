using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHexTile : MonoBehaviour
{
    void Update()
    {
        // 마우스 클릭 또는 터치 입력 확인
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라에서 마우스 위치로 레이 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 레이가 객체에 닿았는지 확인
            if (Physics.Raycast(ray, out hit))
            {
                // 닿은 객체가 HexTile 컴포넌트를 가지고 있는지 확인
                HexTile hexTile = hit.transform.GetComponent<HexTile>();
                if (hexTile != null)
                {
                    // 닿은 HexTile에서 HexType 가져오기
                    HexType type = hexTile.hexType;
                    Debug.Log($"닿은 HexTile의 HexType: {type}");
                }
            }
        }
    }
}

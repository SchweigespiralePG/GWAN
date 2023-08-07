using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f; //좌표계 수식

    [SerializeField]
    private float speed = 5f; // 플레이어의 이동 속도

    private Vector3 targetPosition; // 플레이어가 이동할 대상 위치
    private bool isMoving = false; // 플레이어가 현재 이동 중인지 여부
    private float rayLength = 100f; // Ray의 길이

    private float lastClickTime; // 마지막 클릭 시간을 저장할 변수
    private float clickDelay = 0.25f; //딜레이 0.25초

    private PlayerHexTile playerHexTile; // PlayerHexTile 참조

    private void Start()
    {
        // PlayerHexTile 컴포넌트 가져오기
        playerHexTile = GetComponent<PlayerHexTile>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= clickDelay)
        {
            lastClickTime = Time.time; // 클릭 시간 업데이트

            // 마우스 포인터의 위치에서 Ray를 발사
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray와 충돌한 오브젝트의 정보를 저장할 변수
            if (Physics.Raycast(ray, out hit, rayLength))
            {

                playerHexTile.CalculateCoordinates(); // 좌표 계산
                int x = playerHexTile.x;
                int y = playerHexTile.y;
                int z = playerHexTile.z;

                // 충돌한 오브젝트의 Transform 위치 값을 가져옴
                targetPosition = hit.transform.position;

                int NextX = Mathf.CeilToInt(targetPosition.x / xOffset);
                int NextY = Mathf.RoundToInt(targetPosition.y / yOffset);
                int NextZ = Mathf.RoundToInt(targetPosition.z / zOffset);

                if (Mathf.Abs(x - NextX) <= 1 && Mathf.Abs(y - NextY) <= 1 && Mathf.Abs(z - NextZ) <= 1)
                {
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
                
            }
        }

        // 플레이어가 이동 중이라면
        if (isMoving)
        {
            // 대상 위치로 플레이어를 부드럽게 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // 대상 위치에 도달했다면 이동을 멈춤
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

}

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 좌표 오프셋 값
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f;

    // 플레이어의 이동 속도
    [SerializeField]
    private float speed = 5f;

    // 플레이어가 이동할 대상 위치
    private Vector3 targetPosition;

    // 플레이어의 이동 상태 (true: 이동 중, false: 정지)
    private bool isMoving = false;

    // Ray의 최대 길이
    private float rayLength = 100f;

    // 마지막으로 클릭한 시간 (더블 클릭 방지용)
    private float lastClickTime;

    // 연속 클릭을 감지하기 위한 딜레이 값
    private float clickDelay = 0.25f;

    // PlayerHexTile 스크립트의 참조
    private PlayerHexTile playerHexTile;

    private void Start()
    {
        // 시작 시 PlayerHexTile 컴포넌트를 가져옴
        playerHexTile = GetComponent<PlayerHexTile>();
    }

    void Update()
    {
        // 마우스 클릭 감지와 딜레이 체크
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= clickDelay)
        {
            lastClickTime = Time.time;
            PerformRaycast();
        }

        // 플레이어 이동 처리
        MovePlayer();
    }

    // 마우스 클릭 위치에 Ray를 발사하여 타겟 위치를 감지하는 메서드
    private void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // 좌표 계산
            playerHexTile.CalculateCoordinates();
            int x = playerHexTile.x;
            int y = playerHexTile.y;
            int z = playerHexTile.z;
            targetPosition = hit.transform.position;
            int NextX = Mathf.CeilToInt(targetPosition.x / xOffset);
            int NextY = Mathf.RoundToInt(targetPosition.y / yOffset);
            int NextZ = Mathf.RoundToInt(targetPosition.z / zOffset);

            // 이동할 타겟 위치가 현재 위치와 인접한지 체크
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

    // 플레이어를 타겟 위치로 이동시키는 메서드
    private void MovePlayer()
    {
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

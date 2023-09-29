using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // 좌표 오프셋 값
    public static float xOffset = 1.7f, yOffset = 1.0f, zOffset = 1.5f;

    // 플레이어의 이동 속도
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float rotationSpeed = 5f;

    // 플레이어가 이동할 대상 위치
    private Vector3 targetPosition;

    // 플레이어의 이동 상태 (true: 이동 중, false: 정지)
    private bool isMoving = false;

    // 플레이어의 이벤트 상태 (true: 이벤트 중, false: 종료)
    private bool isEvent = false;

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

    private void Update()
    {
        // 마우스 클릭 감지와 딜레이 체크
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= clickDelay)
        {
            lastClickTime = Time.time;
            PerformRaycast();
            EventHexTile();
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
            int z = playerHexTile.z;

            Debug.Log(hit);
            targetPosition = hit.transform.position;
            Vector2Int targetGridPos = HexGridUtility.CalculateGridPosition(hit.transform.position);
            int NextX = targetGridPos.x;
            int NextZ = targetGridPos.y;

            // 이동할 타겟 위치가 현재 위치와 인접한지 체크
            Debug.Log(x+","+z);
            Debug.Log(NextX + "," + NextZ);

            HexTile hexTile = hit.transform.GetComponent<HexTile>();
            HexType type = hexTile.hexType;
            if (type != HexType.None && Mathf.Abs(x - NextX) <= 1 && Mathf.Abs(z - NextZ) <= 1)
            {
                if (z % 2 == 0)
                {
                    Debug.Log((x - NextX) + "," + (z - NextZ));
                    if ((x - NextX == -1 && z - NextZ == 0) || (x - NextX != -1 && z - NextZ != -1) || (x - NextX != -1 && z - NextZ != 1))
                    {
                        Debug.Log((x - NextX) + "," + (z - NextZ));
                        isMoving = true;
                        isEvent = true;
                    }
                    else
                    {
                        isMoving = false;
                        isEvent = false;
                    }
                }
                else
                {
                    if ((x - NextX == 1 && z - NextZ == 0) || (x - NextX != 1 && z - NextZ != -1) || (x - NextX != 1 && z - NextZ != 1))
                    {
                        Debug.Log((x - NextX) + "," + (z - NextZ));
                        isMoving = true;
                        isEvent = true;
                    }
                    else
                    {
                        isMoving = false;
                        isEvent = false;
                    }
                }
            }
            else
            {
                Debug.Log("이동불가타일");
            }
        }
    }

    // 플레이어를 타겟 위치로 이동시키는 메서드
    private void MovePlayer()
    {
        if (isMoving)
        {


            // 목표 위치로 플레이어 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // 플레이어가 이동하는 방향 계산
            Vector3 direction = (targetPosition - transform.position).normalized;

            // 플레이어가 실제로 이동하는 경우 (즉, 방향 벡터가 0이 아닌 경우)
            if (direction != Vector3.zero)
            {
                // 이동 방향을 기반으로 목표 회전 계산
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // 목표 회전으로 플레이어 부드럽게 회전
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            // 목표 위치에 도달하면 이동 중지
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }

    }

    //이벤트 타일 확인
    private void EventHexTile()
    {
        if (isEvent)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // 닿은 객체가 HexTile 컴포넌트를 가지고 있는지 확인
                HexTile hexTile = hit.transform.GetComponent<HexTile>();
                if (hexTile != null && hexTile.visited)
                {
                    // 닿은 HexTile에서 HexType 가져오기
                    HexType type = hexTile.hexType;
                    isEvent = false;
                    hexTile.visited = false;

                    switch (type)
                    {
                        case HexType.None:
                            break;
                        case HexType.Default:
                            break;
                        case HexType.DiscoveryEvent:
                            //IsDiscoveryEvent(hit);
                            break;
                        case HexType.Battle:
                            IsBattle(hit);
                            break;
                        case HexType.ConversationEvent:
                            IsConversationEvent(hit);
                            break;
                    }
                }
            }
        }
    }
    

    private void IsBattle(RaycastHit hit)
    {
        StartCoroutine(IsBattleWithDelay(hit));
    }
    private IEnumerator IsBattleWithDelay(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.2f); // 0.2초 딜레이

        BattleEvent battleEvent = hit.transform.GetComponent<BattleEvent>();
        battleEvent.CallBattle(); 
        gameObject.GetComponent<PlayerMove>().enabled = false;
    }

    /*private void IsDiscoveryEvent(RaycastHit hit)
    {
        StartCoroutine(IsDiscoveryEventWithDelay(hit));
    }
    private IEnumerator IsDiscoveryEventWithDelay(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.2f); // 0.2초 딜레이

        ConversationEvent conversationEvent = hit.transform.GetComponent<ConversationEvent>();
        conversationEvent.CallShowDialogue();
        gameObject.SetActive(false);
    }*/

    private void IsConversationEvent(RaycastHit hit)
    {
        StartCoroutine(ConversationEventWithDelay(hit));
    }
    private IEnumerator ConversationEventWithDelay(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.2f); // 0.2초 딜레이

        ConversationEvent conversationEvent = hit.transform.GetComponent<ConversationEvent>();
        conversationEvent.CallShowDialogue();
        gameObject.SetActive(false);
    }


}
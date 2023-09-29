using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // ��ǥ ������ ��
    public static float xOffset = 1.7f, yOffset = 1.0f, zOffset = 1.5f;

    // �÷��̾��� �̵� �ӵ�
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float rotationSpeed = 5f;

    // �÷��̾ �̵��� ��� ��ġ
    private Vector3 targetPosition;

    // �÷��̾��� �̵� ���� (true: �̵� ��, false: ����)
    private bool isMoving = false;

    // �÷��̾��� �̺�Ʈ ���� (true: �̺�Ʈ ��, false: ����)
    private bool isEvent = false;

    // Ray�� �ִ� ����
    private float rayLength = 100f;

    // ���������� Ŭ���� �ð� (���� Ŭ�� ������)
    private float lastClickTime;

    // ���� Ŭ���� �����ϱ� ���� ������ ��
    private float clickDelay = 0.25f;

    // PlayerHexTile ��ũ��Ʈ�� ����
    private PlayerHexTile playerHexTile;



    private void Start()
    {
        // ���� �� PlayerHexTile ������Ʈ�� ������
        playerHexTile = GetComponent<PlayerHexTile>();
    }

    private void Update()
    {
        // ���콺 Ŭ�� ������ ������ üũ
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= clickDelay)
        {
            lastClickTime = Time.time;
            PerformRaycast();
            EventHexTile();
        }

        // �÷��̾� �̵� ó��
        MovePlayer();
    }

    // ���콺 Ŭ�� ��ġ�� Ray�� �߻��Ͽ� Ÿ�� ��ġ�� �����ϴ� �޼���
    private void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // ��ǥ ���
            playerHexTile.CalculateCoordinates();
            int x = playerHexTile.x;
            int z = playerHexTile.z;

            Debug.Log(hit);
            targetPosition = hit.transform.position;
            Vector2Int targetGridPos = HexGridUtility.CalculateGridPosition(hit.transform.position);
            int NextX = targetGridPos.x;
            int NextZ = targetGridPos.y;

            // �̵��� Ÿ�� ��ġ�� ���� ��ġ�� �������� üũ
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
                Debug.Log("�̵��Ұ�Ÿ��");
            }
        }
    }

    // �÷��̾ Ÿ�� ��ġ�� �̵���Ű�� �޼���
    private void MovePlayer()
    {
        if (isMoving)
        {


            // ��ǥ ��ġ�� �÷��̾� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // �÷��̾ �̵��ϴ� ���� ���
            Vector3 direction = (targetPosition - transform.position).normalized;

            // �÷��̾ ������ �̵��ϴ� ��� (��, ���� ���Ͱ� 0�� �ƴ� ���)
            if (direction != Vector3.zero)
            {
                // �̵� ������ ������� ��ǥ ȸ�� ���
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // ��ǥ ȸ������ �÷��̾� �ε巴�� ȸ��
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            // ��ǥ ��ġ�� �����ϸ� �̵� ����
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }

    }

    //�̺�Ʈ Ÿ�� Ȯ��
    private void EventHexTile()
    {
        if (isEvent)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // ���� ��ü�� HexTile ������Ʈ�� ������ �ִ��� Ȯ��
                HexTile hexTile = hit.transform.GetComponent<HexTile>();
                if (hexTile != null && hexTile.visited)
                {
                    // ���� HexTile���� HexType ��������
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
        yield return new WaitForSeconds(0.2f); // 0.2�� ������

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
        yield return new WaitForSeconds(0.2f); // 0.2�� ������

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
        yield return new WaitForSeconds(0.2f); // 0.2�� ������

        ConversationEvent conversationEvent = hit.transform.GetComponent<ConversationEvent>();
        conversationEvent.CallShowDialogue();
        gameObject.SetActive(false);
    }


}
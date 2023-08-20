using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ��ǥ ������ ��
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f;

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

    void Update()
    {
        // ���콺 Ŭ�� ������ ������ üũ
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= clickDelay)
        {
            lastClickTime = Time.time;
            PerformRaycast();
        }

        // �÷��̾� �̵� ó��
        MovePlayer();
        EventHexTile();
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
            int y = playerHexTile.y;
            int z = playerHexTile.z;
            targetPosition = hit.transform.position;
            int NextX = Mathf.CeilToInt(targetPosition.x / xOffset);
            int NextY = Mathf.RoundToInt(targetPosition.y / yOffset);
            int NextZ = Mathf.RoundToInt(targetPosition.z / zOffset);

            // �̵��� Ÿ�� ��ġ�� ���� ��ġ�� �������� üũ
            if (Mathf.Abs(x - NextX) <= 1 && Mathf.Abs(y - NextY) <= 1 && Mathf.Abs(z - NextZ) <= 1)
            {
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
                if (hexTile != null)
                {
                    // ���� HexTile���� HexType ��������
                    HexType type = hexTile.hexType;
                    Debug.Log($"���� HexTile�� HexType: {type}");
                    isEvent = false;
                }
            }
        }
    }
}

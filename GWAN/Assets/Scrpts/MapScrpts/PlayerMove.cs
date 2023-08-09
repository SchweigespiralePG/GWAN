using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ��ǥ ������ ��
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f;

    // �÷��̾��� �̵� �ӵ�
    [SerializeField]
    private float speed = 5f;

    // �÷��̾ �̵��� ��� ��ġ
    private Vector3 targetPosition;

    // �÷��̾��� �̵� ���� (true: �̵� ��, false: ����)
    private bool isMoving = false;

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
            }
            else
            {
                isMoving = false;
            }
        }
    }

    // �÷��̾ Ÿ�� ��ġ�� �̵���Ű�� �޼���
    private void MovePlayer()
    {
        if (isMoving)
        {
            // ��� ��ġ�� �÷��̾ �ε巴�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // ��� ��ġ�� �����ߴٸ� �̵��� ����
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

}

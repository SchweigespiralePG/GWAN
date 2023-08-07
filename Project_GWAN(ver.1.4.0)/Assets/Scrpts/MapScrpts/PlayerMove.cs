using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f; //��ǥ�� ����

    [SerializeField]
    private float speed = 5f; // �÷��̾��� �̵� �ӵ�

    private Vector3 targetPosition; // �÷��̾ �̵��� ��� ��ġ
    private bool isMoving = false; // �÷��̾ ���� �̵� ������ ����
    private float rayLength = 100f; // Ray�� ����

    private float lastClickTime; // ������ Ŭ�� �ð��� ������ ����
    private float clickDelay = 0.25f; //������ 0.25��

    private PlayerHexTile playerHexTile; // PlayerHexTile ����

    private void Start()
    {
        // PlayerHexTile ������Ʈ ��������
        playerHexTile = GetComponent<PlayerHexTile>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= clickDelay)
        {
            lastClickTime = Time.time; // Ŭ�� �ð� ������Ʈ

            // ���콺 �������� ��ġ���� Ray�� �߻�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray�� �浹�� ������Ʈ�� ������ ������ ����
            if (Physics.Raycast(ray, out hit, rayLength))
            {

                playerHexTile.CalculateCoordinates(); // ��ǥ ���
                int x = playerHexTile.x;
                int y = playerHexTile.y;
                int z = playerHexTile.z;

                // �浹�� ������Ʈ�� Transform ��ġ ���� ������
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

        // �÷��̾ �̵� ���̶��
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

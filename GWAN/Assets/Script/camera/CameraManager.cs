using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 Positionoffset;

    private void FixedUpdate()
    {
        // ī�޶��� ��ġ�� Ÿ�� ��ġ�� �������� ����Ͽ� �����մϴ�.
        transform.position = target.position + Positionoffset;
        // Ÿ�� ������Ʈ�� ȸ�� ������ �������� ���Ͽ� ī�޶��� ȸ���� �����մϴ�.
        transform.LookAt(target);
    }
}

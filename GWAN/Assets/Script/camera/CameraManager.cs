using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 Positionoffset;

    private void FixedUpdate()
    {
        // 카메라의 위치를 타겟 위치와 오프셋을 사용하여 설정합니다.
        transform.position = target.position + Positionoffset;
        // 타겟 오브젝트의 회전 각도에 오프셋을 더하여 카메라의 회전을 설정합니다.
        transform.LookAt(target);
    }
}

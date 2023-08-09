using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHexTile : MonoBehaviour
{
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f;
    public int x, y, z;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
        CalculateCoordinates();
    }

    void LateUpdate()
    {
        if (transform.position != previousPosition)
        {
            CalculateCoordinates();
            previousPosition = transform.position;
        }
    }

    public void CalculateCoordinates()
    {
        x = Mathf.CeilToInt(transform.position.x / xOffset);
        y = Mathf.RoundToInt(transform.position.y / yOffset);
        z = Mathf.RoundToInt(transform.position.z / zOffset);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHexTile : MonoBehaviour
{
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f;
    public int x, y, z;

    void Start()
    {
        CalculateCoordinates();
    }

    public void CalculateCoordinates()
    {
        x = Mathf.CeilToInt(transform.position.x / xOffset);
        y = Mathf.RoundToInt(transform.position.y / yOffset);
        z = Mathf.RoundToInt(transform.position.z / zOffset);
    }
}

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
        Vector2Int gridPosition = HexGridUtility.CalculateGridPosition(transform.position);
        x = gridPosition.x;
        z = gridPosition.y;
    }
}

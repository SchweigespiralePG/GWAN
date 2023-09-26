using UnityEngine;

public static class HexGridUtility
{
    public static float xOffset = 1.7f;
    public static float zOffset = 1.5f;

    public static Vector2Int CalculateGridPosition(Vector3 worldPosition)
    {
        float xScale = worldPosition.x / xOffset;
        float zScale = worldPosition.z / zOffset;

        int x;
        if (zScale % 2 == 0)
            x = Mathf.RoundToInt(xScale);
        else
            x = Mathf.RoundToInt(xScale - 0.85f);

        int z = Mathf.RoundToInt(zScale);

        return new Vector2Int(x, z);
    }
}

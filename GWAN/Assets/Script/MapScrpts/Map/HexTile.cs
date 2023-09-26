using UnityEngine;

public class HexTile : MonoBehaviour
{
    public static float xOffset = 1.7f, zOffset = 1.5f;
    public int x, y, z;

    [SerializeField]
    public HexType hexType;

    public bool visited = true;

    public void Awake()
    {
        Vector2Int gridPosition = HexGridUtility.CalculateGridPosition(transform.position);
        x = gridPosition.x;
        z = gridPosition.y;
    }
}

//Ÿ�� ����
public enum HexType
{
    None,
    Default,
    Battle,
    DiscoveryEvent,
    ConversationEvent,
}

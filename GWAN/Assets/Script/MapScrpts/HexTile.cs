using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HexTile: MonoBehaviour
{
    public static float xOffset = 1, yOffset = 1, zOffset = 0.85f;

    [SerializeField]
    public HexType hexType;

    public int x,y,z;

    //이벤트 타일 방문 여부
    public bool visited = true;

    //타일 좌표
    private void Awake()
    {
        x = Mathf.CeilToInt(transform.position.x / xOffset);
        y = Mathf.RoundToInt(transform.position.y / yOffset);
        z = Mathf.RoundToInt(transform.position.z / zOffset);
    }

}

//타일 종류
public enum HexType{
    None,
    Default,
    Battle,
    DiscoveryEvent,
    MeetingEvent,

}
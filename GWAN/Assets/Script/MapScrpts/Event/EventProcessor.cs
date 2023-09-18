
using UnityEngine;
using System.Collections.Generic;

public class EventProcessor : MonoBehaviour
{
    private Dictionary<HexType, System.Action> tileEventActions;

    private void Awake()
    {
        // 타일 이벤트 액션을 초기화합니다.
        InitializeTileEventActions();
    }

    private void InitializeTileEventActions()
    {
        // 각 HexType에 따른 동작을 정의합니다.
        tileEventActions = new Dictionary<HexType, System.Action>
        {
            { HexType.None, HandleNone },
            { HexType.Default, HandleDefault },
            { HexType.Battle, StartBattle },
            { HexType.DiscoveryEvent, StartDiscoveryEvent },
            { HexType.MeetingEvent, StartMeetingEvent }
        };
    }

    public void ExecuteTileEvent(HexTile hexTile)
    {
        // 해당 HexTile의 hexType에 따라 적절한 이벤트를 실행합니다.
        if (hexTile != null && tileEventActions.TryGetValue(hexTile.hexType, out System.Action action))
        {
            action.Invoke();
        }
        else
        {
            Debug.LogWarning($"해당 타일 유형에 대한 동작이 정의되지 않았습니다: {hexTile.hexType}");
        }
    }

    private void HandleNone()
    {
        Debug.Log("None");
        // None 타일 유형에 대한 로직을 구현합니다.
    }

    private void HandleDefault()
    {
        Debug.Log("Default");
        // Default 타일 유형에 대한 로직을 구현합니다.
    }

    private void StartBattle()
    {
        Debug.Log("Battle");
        // Battle 타일 유형에 대한 로직을 구현합니다.
    }

    private void StartDiscoveryEvent()
    {
        Debug.Log("DiscoveryEvent");
        // DiscoveryEvent 타일 유형에 대한 로직을 구현합니다.
    }

    private void StartMeetingEvent()
    {
        Debug.Log("MeetingEvent");
        // MeetingEvent 타일 유형에 대한 로직을 구현합니다.
    }
}

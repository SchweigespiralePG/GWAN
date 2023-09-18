
using UnityEngine;
using System.Collections.Generic;

public class EventProcessor : MonoBehaviour
{
    private Dictionary<HexType, System.Action> tileEventActions;

    private void Awake()
    {
        // Ÿ�� �̺�Ʈ �׼��� �ʱ�ȭ�մϴ�.
        InitializeTileEventActions();
    }

    private void InitializeTileEventActions()
    {
        // �� HexType�� ���� ������ �����մϴ�.
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
        // �ش� HexTile�� hexType�� ���� ������ �̺�Ʈ�� �����մϴ�.
        if (hexTile != null && tileEventActions.TryGetValue(hexTile.hexType, out System.Action action))
        {
            action.Invoke();
        }
        else
        {
            Debug.LogWarning($"�ش� Ÿ�� ������ ���� ������ ���ǵ��� �ʾҽ��ϴ�: {hexTile.hexType}");
        }
    }

    private void HandleNone()
    {
        Debug.Log("None");
        // None Ÿ�� ������ ���� ������ �����մϴ�.
    }

    private void HandleDefault()
    {
        Debug.Log("Default");
        // Default Ÿ�� ������ ���� ������ �����մϴ�.
    }

    private void StartBattle()
    {
        Debug.Log("Battle");
        // Battle Ÿ�� ������ ���� ������ �����մϴ�.
    }

    private void StartDiscoveryEvent()
    {
        Debug.Log("DiscoveryEvent");
        // DiscoveryEvent Ÿ�� ������ ���� ������ �����մϴ�.
    }

    private void StartMeetingEvent()
    {
        Debug.Log("MeetingEvent");
        // MeetingEvent Ÿ�� ������ ���� ������ �����մϴ�.
    }
}

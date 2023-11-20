using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{

    public TurnManager Battle;
    public GameObject BattleUI;

    public void CallBattle()
    {

        if (Battle != null)
        {
            Battle.IsBattle();
            BattleUI.SetActive(true);
        }
        else
        {
            Debug.LogError("BattleManager component is not found on BattleManagerObject.");
        }
    }
}

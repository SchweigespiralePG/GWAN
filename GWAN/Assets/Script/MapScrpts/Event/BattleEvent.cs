using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{

    public GameObject BattleManager;
    public GameObject BattleUI;

    public void CallBattle()
    {
        BattleManager manager = BattleManager.GetComponent<BattleManager>();

        if (manager != null)
        {
            BattleManager.SetActive(true);
            BattleUI.SetActive(true);
        }
        else
        {
            Debug.LogError("BattleManager component is not found on BattleManagerObject.");
        }
    }
}

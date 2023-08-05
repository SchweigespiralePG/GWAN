using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterProfile : MonoBehaviour
{
    private int UID;
    public string characterName;
    public string species;
    public float str;
    public float con;
    public float siz;
    public float intl;
    public float dex;
    public float luk;
    public float edu;
    public float apd;
    public float hp;
    public float dp;
    public float atk;
    public float mDef;
    public float sight;
    public float spiritual;
    public string type;
    public string job;

    public int UniqueID // Public property for UID
    {
        get { return UID; }
        set { UID = value; }
    }

    // Method to set data from NPCData
    public void SetData(NPCData data)
    {
        UID = data.UID;
        characterName = data.characterName;
        species = data.species;
        str = data.str;
        con = data.con;
        siz = data.siz;
        intl = data.intl;
        dex = data.dex;
        luk = data.luk;
        edu = data.edu;
        apd = data.apd;
        hp = data.hp;
        dp = data.dp;
        atk = data.atk;
        mDef = data.mDef;
        sight = data.sight;
        spiritual = data.spiritual;
        type = data.type;
        job = data.job;
    }
}

using UnityEngine;

[System.Serializable]
public class NPCData
{
    public int UID; // Rename to 'UID' to match the JSON data key
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
}

[System.Serializable]
public class NPCDataCollection
{
    public NPCData[] NPC;
}

public class NPCDataLoader : MonoBehaviour
{
    public TextAsset npcDataJson;

    public NPCData[] LoadNPCData()
    {
        string jsonData = npcDataJson.text;
        Debug.Log("JSON data: " + jsonData); // Add this line to check the JSON data before parsing

        NPCDataCollection dataCollection = JsonUtility.FromJson<NPCDataCollection>(jsonData);

        if (dataCollection != null && dataCollection.NPC != null && dataCollection.NPC.Length > 0)
        {
            Debug.Log("Number of NPCs loaded: " + dataCollection.NPC.Length);
            return dataCollection.NPC;
        }
        else
        {
            Debug.LogError("Failed to load NPC data. Check if the JSON data is formatted correctly.");
            return new NPCData[0]; // Return an empty array to prevent null reference issues
        }
    }
}

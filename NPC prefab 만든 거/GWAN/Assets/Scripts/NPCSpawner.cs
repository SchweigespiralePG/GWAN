using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public NPCDataLoader npcDataLoader;

    void Start()
    {
        NPCData[] npcDataArray = npcDataLoader.LoadNPCData();

        if (npcDataArray != null)
        {
            Debug.Log("Number of NPCs loaded: " + npcDataArray.Length);

            foreach (NPCData data in npcDataArray)
            {
                GameObject newNPC = Instantiate(npcPrefab, transform.position, transform.rotation);
                CharacterProfile npcProfile = newNPC.GetComponent<CharacterProfile>();

                npcProfile.SetData(data);
                npcProfile.UniqueID = data.UID;
            }
        }
        else
        {
            Debug.LogError("NPC data is null. Check if the JSON data is loaded correctly.");
        }
    }
}

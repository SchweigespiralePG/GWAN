using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDataReader : MonoBehaviour
{
   
    public DataEntry[] dataEntries;
    private void Start()
    {
        LoadAndParseJSONFiles();
    }

    void LoadAndParseJSONFiles()
    {
        TextAsset[] jsonFiles = Resources.LoadAll<TextAsset>("JSONFiles");

        dataEntries = new DataEntry[jsonFiles.Length];
        for (int i = 0; i < jsonFiles.Length; i++)
        {
            dataEntries[i] = JsonUtility.FromJson<DataEntry>(jsonFiles[i].text);
        }
        Debug.Log("JsonFiles loaded complete. Total: " + jsonFiles.Length);
        Debug.Log("Data Entries Count: " + dataEntries.Length);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1 
using System.IO;
public class DataManager : MonoBehaviour
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    private string _dataPath;

    private void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data.";

        Debug.Log(_dataPath);
    }

    // Start is called before the first frame update
    void Start()
    {
        //ItemText.text += _itemsCollected;
        //HealthText.text += _playerHP;

        Initialize();
    }

    public void Initialize()
    {
        _state = "Data Manager initialized..";
        Debug.Log(_state);

        FilesystemInfo();
        //NewDirectory();
        DeleteDirectory();
    }

    public void FilesystemInfo()
    {
        Debug.LogFormat("Path separator character: {0}", Path.PathSeparator);

        Debug.LogFormat("Directory separator character: {0}", Path.DirectorySeparatorChar);

        Debug.LogFormat("Current directory: {0}", Directory.GetCurrentDirectory());

        Debug.LogFormat("Temporary path: {0}", Path.GetTempPath());
    }

    public void NewDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log("Directory already exists...");
            return;
        }

        Directory.CreateDirectory(_dataPath);
        Debug.Log("New directory created!");
    }

    public void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Debug.Log("Directory doesn't exist or has already been deleted...");
            return;
        }

        Directory.Delete(_dataPath, true);
        Debug.Log("Directory sucessfully deleted!");
    }
}

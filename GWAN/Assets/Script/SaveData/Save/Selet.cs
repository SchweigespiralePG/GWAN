using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Selet : MonoBehaviour
{

    public GameObject creat;
    public Text[] slotText;
    public Text Name;

    bool[] savefile =new bool[4];

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {

            if (File.Exists(DataManager.instance.Route + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.SaveDataNumber = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.NowPlayerData.DataName;
            }
            else
            {
                savefile[i] = false;
                slotText[i].text = "비어있음";
            }
        }

        DataManager.instance.DataClear();
    }


    public void Slot(int number)
    {
        DataManager.instance.SaveDataNumber = number;

        if (savefile[number])
        {
            DataManager.instance.LoadData();
            //GoGame();
        }
        else
        {
            Debug.Log("None Data");
            //Create();
        }

    }

    public  void Create()
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        if (!savefile[DataManager.instance.SaveDataNumber])
        {
            DataManager.instance.NowPlayerData.DataName = Name.text;
        }
        //SceneManager.LoadScene();
    }
}

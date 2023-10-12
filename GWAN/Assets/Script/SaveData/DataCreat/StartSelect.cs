using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    int act;
    int level;
    bool seletOnOff = false;

    public GameObject selectView;
    public GameObject selectconsole;

    [SerializeField]
    public Text fustlain;

    private void Update()
    {
        if (!seletOnOff) 
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Noselect();
        }
    }
    public void SeletAct(int index)
    {
        act = index;
    }
    public void SeletLevel(int index)
    {
        level = index;

    }

    public void Selt()
    {
        selectconsole.SetActive(true);
        selectView.SetActive(false);
        seletOnOff = true;
        SeletView();
    }

    public void SeletView()
    {
        string LevelName="";
        switch (level)
        {
            case 0:
                LevelName = "����";
                break;
            case 1:
                LevelName = "�Ϲ�";
                break;
        }

        fustlain.text = $"�����Ͻ� �ɼ��� �����Ű��� ACT : {act} LEVEL : {LevelName}";
    }

    public void ReallySelt()
    {
        DataManager.instance.NowPlayerData.Act = act;
        DataManager.instance.NowPlayerData.Level= level;
        DataManager.instance.SaveData();
        Debug.Log("����Ϸ� act : " + act + " level : " + level + " Name : " + DataManager.instance.NowPlayerData.DataName);
        Debug.Log("������ : " + DataManager.instance.Route);
        //SceneManager.LoadScene(sceneName);
    }

    public void Noselect()
    {
        seletOnOff = false;
        selectconsole.SetActive(false);
        selectView.SetActive(true);
    }
}

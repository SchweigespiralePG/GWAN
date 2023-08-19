using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject[] Article;
    [SerializeField] private int num;

    public void MenuSet()
    {
        for(int i=0; i<Article.Length; i++)
        {
            Article[i].SetActive(false);
        }
        Article[num].SetActive(true);
    }
}

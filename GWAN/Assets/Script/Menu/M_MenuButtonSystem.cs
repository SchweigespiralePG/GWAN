using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MenuButtonSystem : MonoBehaviour
{
    public string SceneName;
    [SerializeField] private LevelLoader levelLoader;

    public void GameStart()
    {
        levelLoader.LoadNextLevel(SceneName);
    }

    public void GameLoad()
    {
        levelLoader.LoadNextLevel(SceneName);
    }

    public void GameSettings()
    {
        levelLoader.LoadNextLevel(SceneName);
    }

    public void GameOmake()
    {
        levelLoader.LoadNextLevel(SceneName);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}

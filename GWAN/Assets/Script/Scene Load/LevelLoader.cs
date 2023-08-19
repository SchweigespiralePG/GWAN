//LevelLoader.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public float transtion_Time = 1f;
    public string SceneName;
    [SerializeField] private bool isAnykey;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (isAnykey)
            {
                LoadNextLevel(SceneName);
            }
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string scenename)
    {
        // Play animation
        Transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transtion_Time);

        // Load Scene
        SceneManager.LoadScene(scenename);
    }
}

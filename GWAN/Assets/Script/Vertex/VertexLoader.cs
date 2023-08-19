using UnityEngine;
using UnityEngine.SceneManagement;

public class VertexLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("VERTEX", LoadSceneMode.Additive);
    }
}
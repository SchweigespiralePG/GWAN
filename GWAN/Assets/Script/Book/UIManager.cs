using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject bookUI; // Reference to the UI that displays the book

    public void ShowBookUI()
    {
        bookUI.SetActive(true);
    }
}



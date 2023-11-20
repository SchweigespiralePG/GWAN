using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBook : MonoBehaviour
{
    public GameObject Book;

    public bool BookSwitch =false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (BookSwitch)
            {
                Book.SetActive(false);
                BookSwitch = false;
            }
            else
            {
                Book.SetActive(true);
                BookSwitch = true;
            }
        }
        return;
    }
}

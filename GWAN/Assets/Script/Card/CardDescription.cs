using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDescription : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    
    public void DescriptionOff()
    {
        gameObject.SetActive(false);
    }
}

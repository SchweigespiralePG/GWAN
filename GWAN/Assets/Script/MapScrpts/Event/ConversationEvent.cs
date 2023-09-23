using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ConversationEvent : MonoBehaviour
{
    public GameObject ConversationObject;

    public void CallShowDialogue()
    {
        ConversationManager manager = ConversationObject.GetComponent<ConversationManager>();

        if (manager != null)
        {
            ConversationObject.SetActive(true);
            manager.ShowDialogue();
        }
        else
        {
            Debug.LogError("ConversationManager component is not found on ConversationObject.");
        }
    }
}

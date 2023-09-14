using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

[System.Serializable]

public class Dialogue
{
    [TextArea]
    public string dialogue;
    public string Title;
    public Sprite cg;
    public bool Select;

}

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text text_Dialogue;
    [SerializeField] private Text text_Title;
    [SerializeField] private GameObject Select_Button;

    private int Count = 0;

    [SerializeField] private Dialogue[] dialogue;
    
    public void ShowDialogue()
    {
        OnOff(true);
        Count = 0;

        NextDialogue();
    }
    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        text_Dialogue.gameObject.SetActive(_flag);
        text_Title.gameObject.SetActive(_flag);
    }

    private void HideDialogus()
    {
        OnOff(false);
    }

    private void NextDialogue()
    {
        text_Dialogue.text = dialogue[Count].dialogue;
        text_Title.text = dialogue[Count].Title;
        sprite_StandingCG.sprite = dialogue[Count].cg;
        if (dialogue[Count].Select)
        {
            HideDialogus();
            Select_Button.gameObject.SetActive(true);
        }
        else {
            ShowDialogue();
            Select_Button.gameObject.SetActive(false);
        }
        Count += 1;
        
    }

        private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Count < dialogue.Length)
            {
                NextDialogue();
            }
            else
            {
                HideDialogus();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
// Dialogue Ŭ������ ��ȭ�� ����, ����, �̹��� �� ���� ��ư Ȱ��ȭ ���θ� �����մϴ�.
public class Dialogue
{
    [TextArea]
    public string dialogue; // ��ȭ ����
    public string Title;    // ��ȭ ����
    public Sprite cg;       // ��ȭ���� ���Ǵ� ��������Ʈ �̹���
    public bool Select;     // ���� ��ư�� Ȱ��ȭ ����
}

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;   // ��ȭ �߿� ǥ�õǴ� ĳ���� �̹���
    [SerializeField] private SpriteRenderer sprite_DialogueBox; // ��ȭ ����
    [SerializeField] private Text text_Dialogue;                 // ��ȭ ���� �ؽ�Ʈ
    [SerializeField] private Text text_Title;                    // ��ȭ ���� �ؽ�Ʈ
    [SerializeField] private GameObject Select_Button;           // ���� ��ư

    private int Count = 0;  // ���� ��ȭ�� �ε���

    [SerializeField] private Dialogue[] dialogue; // ��ȭ �迭

    // ��ȭ�� Ȱ��ȭ�ϰ� ù ��° ��ȭ�� �����մϴ�.
    public void ShowDialogue()
    {
        OnOff(true);
        Count = 0;
        NextDialogue();
    }

    // ��ȭ�� ���õ� UI ����� Ȱ��ȭ ���¸� �����մϴ�.
    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        text_Dialogue.gameObject.SetActive(_flag);
        text_Title.gameObject.SetActive(_flag);
    }

    // ��ȭ â�� ����ϴ�.
    public void offChatWindow()
    {
        gameObject.SetActive(false);
    }

    // ��ȭ â�� �����ݴϴ�.
    public void onChatWindow()
    {
        gameObject.SetActive(true);
    }

    // ���� ��ư�� ����ϴ�.
    public void offSelectButton()
    {
        Select_Button.gameObject.SetActive(false);
    }

    // ��� ��ȭ UI ��Ҹ� ����ϴ�.
    private void HideDialogus()
    {
        OnOff(false);
    }

    // ���� ��ȭ�� ǥ���մϴ�.
    private void NextDialogue()
    {
        // �迭�� ���̸� �ʰ��ϸ� ��ȭ�� ����ϴ�.
        if (Count >= dialogue.Length)
        {
            HideDialogus();
            return;
            Count = 0;
        }

        text_Dialogue.text = dialogue[Count].dialogue;
        text_Title.text = dialogue[Count].Title;
        sprite_StandingCG.sprite = dialogue[Count].cg;
        if (dialogue[Count].Select)
        {
            Select_Button.gameObject.SetActive(true);
            HideDialogus();
        }
        Count += 1;
        
    }

    // ������� ���콺 �Է��� �����Ͽ� ���� ��ȭ�� ǥ���ϰų� ��ȭ�� �����մϴ�.
    private void Update()
    {
        // ��ȭ�� ���� �������� NextDialogue �Լ��� ȣ���մϴ�.
        if (Input.GetMouseButtonDown(0) && Count <= dialogue.Length)
        {
            NextDialogue();
        }
    }
}

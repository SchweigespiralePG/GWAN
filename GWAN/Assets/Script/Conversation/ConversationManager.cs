using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
// Dialogue 클래스는 대화의 내용, 제목, 이미지 및 선택 버튼 활성화 여부를 정의합니다.
public class Dialogue
{
    [TextArea]
    public string dialogue; // 대화 내용
    public string Title;    // 대화 제목
    public Sprite cg;       // 대화에서 사용되는 스프라이트 이미지
    public bool Select;     // 선택 버튼의 활성화 여부
}

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;   // 대화 중에 표시되는 캐릭터 이미지
    [SerializeField] private SpriteRenderer sprite_DialogueBox; // 대화 상자
    [SerializeField] private Text text_Dialogue;                 // 대화 내용 텍스트
    [SerializeField] private Text text_Title;                    // 대화 제목 텍스트
    [SerializeField] private GameObject Select_Button;           // 선택 버튼

    private int Count = 0;  // 현재 대화의 인덱스

    [SerializeField] private Dialogue[] dialogue; // 대화 배열

    // 대화를 활성화하고 첫 번째 대화를 시작합니다.
    public void ShowDialogue()
    {
        OnOff(true);
        Count = 0;
        NextDialogue();
    }

    // 대화와 관련된 UI 요소의 활성화 상태를 설정합니다.
    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        text_Dialogue.gameObject.SetActive(_flag);
        text_Title.gameObject.SetActive(_flag);
    }

    // 대화 창을 숨깁니다.
    public void offChatWindow()
    {
        gameObject.SetActive(false);
    }

    // 대화 창을 보여줍니다.
    public void onChatWindow()
    {
        gameObject.SetActive(true);
    }

    // 선택 버튼을 숨깁니다.
    public void offSelectButton()
    {
        Select_Button.gameObject.SetActive(false);
    }

    // 모든 대화 UI 요소를 숨깁니다.
    private void HideDialogus()
    {
        OnOff(false);
    }

    // 다음 대화를 표시합니다.
    private void NextDialogue()
    {
        // 배열의 길이를 초과하면 대화를 숨깁니다.
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

    // 사용자의 마우스 입력을 감지하여 다음 대화를 표시하거나 대화를 종료합니다.
    private void Update()
    {
        // 대화의 길이 내에서만 NextDialogue 함수를 호출합니다.
        if (Input.GetMouseButtonDown(0) && Count <= dialogue.Length)
        {
            NextDialogue();
        }
    }
}

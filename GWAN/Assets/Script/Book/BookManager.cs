//using UnityEngine;

//public class BookManager : MonoBehaviour
//{
//    public CardDB cardDatabase; // CardDatabase 스크립트 참조 필요
//    public GameObject cardPrefab; // 카드 프리팹
//    public Transform cardGridParent; // 카드 배열을 담을 부모 오브젝트
//    //public CardUI cardUI;
//    private Card[,] cardGrid = new Card[3, 3];
    

//    void Start()
//    {
//        PopulateCardGrid();
//    }

//    void PopulateCardGrid()
//    {
//        for (int row = 0; row < 3; row++)
//        {
//            for (int col = 0; col < 3; col++)
//            {
//                Card card = cardDatabase.GetRandomCard();
//                cardGrid[row, col] = card;

//                Vector3 cardPosition = new Vector3(col * 2, 0, row * 2); // 예시 위치 조정
//                GameObject cardObject = Instantiate(cardPrefab, cardPosition, Quaternion.identity, cardGridParent);

//                //CardUI cardUI = cardObject.GetComponent<CardUI>();
//                //cardUI.Setup(card);
//            }
//        }
//    }
//}

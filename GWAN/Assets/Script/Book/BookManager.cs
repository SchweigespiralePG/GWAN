//using UnityEngine;

//public class BookManager : MonoBehaviour
//{
//    public CardDB cardDatabase; // CardDatabase ��ũ��Ʈ ���� �ʿ�
//    public GameObject cardPrefab; // ī�� ������
//    public Transform cardGridParent; // ī�� �迭�� ���� �θ� ������Ʈ
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

//                Vector3 cardPosition = new Vector3(col * 2, 0, row * 2); // ���� ��ġ ����
//                GameObject cardObject = Instantiate(cardPrefab, cardPosition, Quaternion.identity, cardGridParent);

//                //CardUI cardUI = cardObject.GetComponent<CardUI>();
//                //cardUI.Setup(card);
//            }
//        }
//    }
//}

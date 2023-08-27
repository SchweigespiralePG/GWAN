using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Card Data")]
public class Card : ScriptableObject
{
    public int cardNum;
    public int cardRate;
    public string cardName;
    public Sprite cardImage;
    public string cardRole;
    public bool FrontOrReverse;
    public bool have;
}


using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card Database", menuName = "Card Database")]
public class CardDB : ScriptableObject
{
    public List<Card> cards = new List<Card>();
}

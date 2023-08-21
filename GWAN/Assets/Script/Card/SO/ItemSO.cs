using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name; //이름
    public Sprite sprite; // 스프라이트
    public float percent; //카드에서 뽑힐 환률
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objext/ItemSO")] 
public class ItemSO : ScriptableObject
{
    public Item[] items;
}

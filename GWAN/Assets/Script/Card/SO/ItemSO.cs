using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name; //�̸�
    public Sprite sprite; // ��������Ʈ
    public float percent; //ī�忡�� ���� ȯ��
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objext/ItemSO")] 
public class ItemSO : ScriptableObject
{
    public Item[] items;
}

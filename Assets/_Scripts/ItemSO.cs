using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public GameObject inventoryGameobject;

    public override String ToString()
    {
        return Enum.GetName(typeof(ItemType), itemType);
    }
}

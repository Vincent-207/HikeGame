using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemConsumerPickupable : ItemConsumer
{
    [SerializeField] ItemSO itemToAdd;
    override internal void Start()
    {
        base.Start();
        itemGiven.AddListener(AddItemToInventory);
    }
    public void AddItemToInventory()
    {
        if(Inventory.instance == null) Debug.LogError("Inventory null!");
        Inventory.instance.AddItem(itemToAdd);
    }
}


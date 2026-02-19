using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemConsumerPickupable : TextHoverable, IItemConsumer
{
    [SerializeField] ItemType requiredItem;
    [SerializeField] ItemSO itemToAdd;
    [SerializeField] GameObject linkedObject; // physical gameobject in scene;
    [SerializeField] String StateParam;
    public UnityEvent consumed;
    void Start()
    {
        bool pickedUp = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(pickedUp)
        {
            if(linkedObject != null) Destroy(linkedObject);
            Destroy(gameObject);
        }
    }
    public void AddItem(ItemType itemType)
    {
        if(ItemMatches(itemType))
        {
            if(Inventory.instance == null) Debug.LogError("Inventory null!");
            Inventory.instance.AddItem(itemToAdd);
            PlayerPrefs.SetInt(StateParam, boolToInt(true));
            PlayerPrefs.Save();
            if(linkedObject != null) Destroy(linkedObject);
            Destroy(gameObject);
            consumed.Invoke();
        }
    }

    public bool ItemMatches(ItemType itemType)
    {
        return itemType == requiredItem;
    }

    bool intToBool(int val)
    {
        if(val != 0) return true;
        else return false;
    }

    int boolToInt(bool val)
    {
        if(val) return 1;
        else return 0;
    }
}


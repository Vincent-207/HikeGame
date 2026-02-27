using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemConsumer : TextHoverable, IItemConsumer
{
    public ItemType requiredItem;
    public UnityEvent itemGiven, updateRelevantStates;
    [SerializeField] GameObject linkedObject; // physical gameobject in scene;
    public String StateParam;
    public bool AffectCursor = true;
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
    virtual internal void Start()
    {
        bool pickedUp = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        updateRelevantStates.Invoke();
        if(pickedUp)
        {
            if(linkedObject != null) Destroy(linkedObject);
            Destroy(gameObject);
            
        }
    }
    public void AddItem(ItemType itemType)
    {
        PlayerPrefs.SetInt(StateParam, boolToInt(true));
        PlayerPrefs.Save();
        if(linkedObject != null) Destroy(linkedObject);
        Destroy(gameObject);
        itemGiven.Invoke();
        updateRelevantStates.Invoke();
        OnPointerEnter(null);
    }

    public bool ItemMatches(ItemType itemType)
    {
        return requiredItem == itemType;
    }



    public override void OnPointerEnter(PointerEventData eventData)
    {
        if(AffectCursor) 
        {
            base.OnPointerEnter(eventData);
            MouseControl.instance.Locked();
        }
    }
}

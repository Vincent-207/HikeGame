using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickupable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    ItemSO itemToAdd;
    [SerializeField] String StateParam;
    [SerializeField] GameObject linkedObj;
    void Start()
    {
        bool hasBeenPickedUp = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(hasBeenPickedUp)
        {
            Destroy(gameObject);
            if(linkedObj != null) Destroy(linkedObj);
            
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("Adding!");
        if(Inventory.instance == null) Debug.LogWarning("Inventory null!");
        Inventory.instance.AddItem(itemToAdd);
        PlayerPrefs.SetInt(StateParam, boolToInt(true));
        PlayerPrefs.Save();
        if(linkedObj != null) Destroy(linkedObj);
        Destroy(gameObject);
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

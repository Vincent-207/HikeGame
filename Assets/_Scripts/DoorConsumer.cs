using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DoorConsumer : TextHoverable, IItemConsumer, IPointerClickHandler
{
    [SerializeField] ItemType requiredItem;
    [SerializeField] String SceneToLoad, StateParam, lockedText, unlockedText;
    [SerializeField]
    bool unlocked = false;
    [SerializeField] 
    Transform doorHinge;
    [SerializeField]
    Vector3 closedHinge, openHinge;
    public UnityEvent unlockedEvent, itemUnlocked;
    void Awake()
    {
        unlocked = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(unlocked) unlockedEvent.Invoke();
        // SetupLockState(unlocked);
        hoverText = unlocked ? unlockedText : lockedText;
    }

    public void UpdateState()
    {
        unlocked = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        Debug.Log("Updating state! " + unlocked);
        hoverText = unlocked ? unlockedText : lockedText;
        if(unlocked) unlockedEvent.Invoke();

    }

    public void Unlock()
    {
        unlockedEvent.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if(unlocked) MouseControl.instance.Unlocked();
        else MouseControl.instance.Locked();
    }
    public void AddItem(ItemType itemType)
    {
        if(ItemMatches(itemType))
        {
            unlocked = true;
            hoverText = unlocked ? unlockedText : lockedText;   
            PlayerPrefs.SetInt(StateParam, boolToInt(unlocked));
            PlayerPrefs.Save();
            unlockedEvent.Invoke();
            itemUnlocked.Invoke();
            OnPointerEnter(null);
        }
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

    public bool ItemMatches(ItemType itemType)
    {
        return requiredItem == itemType;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(unlocked)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

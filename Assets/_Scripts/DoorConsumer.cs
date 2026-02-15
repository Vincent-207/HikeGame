using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DoorConsumer : TextHoverable, IItemConsumer, IPointerClickHandler
{
    [SerializeField] ItemType requiredItem;
    [SerializeField] String SceneToLoad, StateParam, lockedText, unlockedText;
    [SerializeField]
    bool unlocked = false;
    void Awake()
    {
        unlocked = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        hoverText = unlocked ? unlockedText : lockedText;
    }
    public void AddItem(ItemType itemType)
    {
        if(ItemMatches(itemType))
        {
            unlocked = true;
            hoverText = unlocked ? unlockedText : lockedText;   
            PlayerPrefs.SetInt(StateParam, boolToInt(unlocked));
            PlayerPrefs.Save();
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

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DoorConsumer : MonoBehaviour, IItemConsumer, IPointerClickHandler
{
    [SerializeField] ItemType requiredItem;
    [SerializeField] String SceneToLoad;
    bool unlocked = false;
    public void AddItem(ItemType itemType)
    {
        if(ItemMatches(itemType))
        {
            unlocked = true;
        }
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

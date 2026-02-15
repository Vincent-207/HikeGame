using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelInteractable : TextHoverable, IPointerClickHandler
{
    
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Level interactable: " + gameObject.name);
        // throw new System.NotImplementedException();
    }
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LevelInteractable : TextHoverable, IPointerClickHandler
{

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Level interactable: " + gameObject.name);
        // throw new System.NotImplementedException();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        MouseControl.instance.Clickable();
    }
}

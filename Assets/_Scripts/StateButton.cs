using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateButton : StateInteractable, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float unpressed,pressed;
    [SerializeField] Transform objectTransform;
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 pos = objectTransform.localPosition;
        pos.z = pressed;
        objectTransform.localPosition = pos;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 pos = objectTransform.localPosition;
        pos.z = unpressed;
        objectTransform.localPosition = pos;
    }

}

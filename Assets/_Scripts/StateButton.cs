using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StateButton : StateInteractable, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float unpressed,pressed;
    [SerializeField] Transform objectTransform;
    public UnityEvent onButtonDown, onButtonUp;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On pointer down!");
        Vector3 pos = objectTransform.localPosition;
        pos.z = pressed;
        objectTransform.localPosition = pos;
        onButtonDown.Invoke();

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 pos = objectTransform.localPosition;
        pos.z = unpressed;
        objectTransform.localPosition = pos;
        onButtonUp.Invoke();
    }

}

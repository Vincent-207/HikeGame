using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StateButton : StateInteractable, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Vector3 unpressed,pressed;
    [SerializeField] Transform objectTransform;
    public UnityEvent onButtonDown, onButtonUp;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On pointer down!");
        objectTransform.localPosition = pressed;
        onButtonDown.Invoke();

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        objectTransform.localPosition = unpressed;
        onButtonUp.Invoke();
    }

}

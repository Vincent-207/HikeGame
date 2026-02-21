using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : TextHoverable, IPointerClickHandler
{
    public UnityEvent interaction;
    public void OnPointerClick(PointerEventData eventData)
    {
        interaction.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        MouseControl.instance.Clickable();
    }
    
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIInteractable : TextHoverable, IPointerClickHandler
{
    [SerializeField] UnityEvent onClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick.Invoke();
    }

    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
        base.OnPointerEnter(null);
        MouseControl.instance.Clickable();
    }
}

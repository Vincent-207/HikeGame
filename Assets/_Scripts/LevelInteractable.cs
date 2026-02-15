using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelInteractable : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] String hoverText;
    
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Level interactable: " + gameObject.name);
        // throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorText.instance.SetText(hoverText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorText.instance.FadeOut();
    }
}

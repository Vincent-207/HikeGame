using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class TextHoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] internal String hoverText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorText.instance.SetText(hoverText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorText.instance.gameObject.SetActive(true);
        CursorText.instance.FadeOut();
    }

    void OnDestroy()
    {
        CursorText.instance.gameObject.SetActive(true);
        CursorText.instance.FadeOut();
    }


    
}

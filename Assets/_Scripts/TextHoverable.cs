using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class TextHoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] internal String hoverText;
    void Start()
    {
        Debug.Log("Start!");
    }

    public virtual void OnPointerEnter()
    {
        OnPointerEnter(null);
    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("Pointer entered!");
        CursorText.instance.SetText(hoverText);
        MouseControl.instance.Hoverable();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        CursorText.instance.gameObject.SetActive(true);
        CursorText.instance.FadeOut();
        MouseControl.instance.Default();
    }

    void OnDestroy()
    {
        CursorText.instance.gameObject.SetActive(true);
        CursorText.instance.FadeOut();
    }


    public void SetText(String text)
    {
        hoverText = text;
    }

    
}

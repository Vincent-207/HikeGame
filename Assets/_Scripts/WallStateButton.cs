using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallStateButton : StateButton
{
    // public String StateParam;
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetInt(stateParam, 1);
        PlayerPrefs.Save();
        base.OnPointerDown(eventData);
        onChanged.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        PlayerPrefs.SetInt(stateParam, 0);
        PlayerPrefs.Save();
        base.OnPointerUp(eventData);
        onChanged.Invoke();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        
    }
}

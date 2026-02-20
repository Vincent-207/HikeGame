using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StateInteractable : TextHoverable, IPointerClickHandler
{
    [SerializeField] String stateParam;
    public UnityEvent StateUpdate;
    void Start()
    {
        bool state = intToBool(PlayerPrefs.GetInt(stateParam, 0));
        if(state)
        {
            StateUpdate.Invoke();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerPrefs.SetInt(stateParam, boolToInt(true));
        StateUpdate.Invoke();
    }

    int boolToInt(bool val)
    {
        if(val) return 1;
        else return 0;
    }

    bool intToBool(int val)
    {
        if(val != 0) return true;
        else return false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        MouseControl.instance.Clickable();
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StateInteractable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] String stateParam;
    public UnityEvent StateUpdate;
    
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
}

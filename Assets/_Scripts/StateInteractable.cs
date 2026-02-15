using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateInteractable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] String stateParam;
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerPrefs.SetInt(stateParam, boolToInt(true));
    }

    int boolToInt(bool val)
    {
        if(val) return 1;
        else return 0;
    }
}

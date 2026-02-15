using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LockSlot : MonoBehaviour
{
    public int currentValue = 0;
    [SerializeField] TMP_Text valueText;
    public UnityEvent ValueChanged;
    void Awake()
    {
        ValueChanged ??= new();
    }
    public void Increment()
    {
        currentValue++;
        if(currentValue > 9)
        {
            currentValue = 0;
        }
        ValueChanged.Invoke();
        DisplayValue();
        
    }


    public void Decrement()
    {
        currentValue --;
        if(currentValue < 0)
        {
            currentValue = 9;
        }
        ValueChanged.Invoke();
        DisplayValue();
    }

    void DisplayValue()
    {
        valueText.text = String.Format("{0}", currentValue);
    }
}

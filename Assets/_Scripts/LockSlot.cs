using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LockSlot : MonoBehaviour
{
    public int currentValue = 0;
    [SerializeField] TMP_Text valueText;
    public void Increment()
    {
        currentValue++;
        if(currentValue > 9)
        {
            currentValue = 0;
        }
        DisplayValue();
    }

    public void Decrement()
    {
        currentValue --;
        if(currentValue < 0)
        {
            currentValue = 9;
        }
        DisplayValue();
    }

    void DisplayValue()
    {
        valueText.text = String.Format("{0}", currentValue);
    }
}

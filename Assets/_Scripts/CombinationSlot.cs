using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CombinationSlot : MonoBehaviour
{
    [SerializeField] int currentValue, minValue, maxValue;
    [SerializeField] TMP_Text text;
    void UpdateText()
    {
        text.text = String.Format("{0:00}", currentValue);
    }
    void Start()
    {
        currentValue = minValue;
        UpdateText();
    }
    public void Increment()
    {
        currentValue++;
        if(currentValue > maxValue)
        {
            currentValue = minValue;
        }
        UpdateText();
    }

    public void Decrement()
    {
        currentValue--;
        if(currentValue < minValue)
        {
            currentValue = maxValue;
        }
        UpdateText();
    }

    public int GetValue()
    {
        return currentValue;
    }


}

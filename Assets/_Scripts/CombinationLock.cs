using System;
using UnityEngine;
using UnityEngine.Events;

public class CombinationLock : MonoBehaviour
{
    public CombinationSlot slot;
    [SerializeField] int keyValue;
    public UnityEvent onUnlock, onFailedTry;
    [SerializeField] String StateParam;
    public void Try()
    {
        int entered = slot.GetValue();
        if(entered == keyValue)
        {
            PlayerPrefs.SetInt(StateParam, 1);
            PlayerPrefs.Save();
            onUnlock.Invoke();
        }
        else
        {
            onFailedTry.Invoke();
        }
    }
}

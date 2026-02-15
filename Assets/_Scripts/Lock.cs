using System;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    [SerializeField] String correctValue;
    [SerializeField] LockSlot[] slots;
    public UnityEvent unlocked;
    public UnityEvent locked;
    void Awake()
    {
        unlocked ??= new();
        locked ??= new();
    }

    public void DoCheck()
    {
        bool matches = LockMatches();
        Debug.Log("Lock code is: " + matches);
        if(matches) DoUnlock();
        else locked.Invoke();
    }

    public void DoUnlock()
    {
        unlocked.Invoke();
    }

    bool LockMatches()
    {
        String slotValue = "";
        foreach(LockSlot slot in slots)
        {
            slotValue += slot.currentValue.ToString();
        }
        if(correctValue.Equals(slotValue))
        {
            return true;
        }
        return false;
    }
}

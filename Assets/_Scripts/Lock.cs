using System;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    [SerializeField] String correctValue;
    [SerializeField] LockSlot[] slots;
    public UnityEvent unlocked;
    void Awake()
    {
        unlocked ??= new();
        
    }

    public void DoCheck()
    {
        bool matches = LockMatches();
        Debug.Log("Lock code is: " + matches);
        if(matches) DoUnlock();
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

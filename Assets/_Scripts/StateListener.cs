using System;
using UnityEngine;
using UnityEngine.Events;

public class StateListener : MonoBehaviour
{
    [SerializeField] internal String StateParam;
    [SerializeField] internal bool runInAwake;
    public UnityEvent OnStateEvent, OnStateFalse;

    public virtual void StateUpdate()
    {
        bool state = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(state) OnStateEvent.Invoke();
        else OnStateFalse.Invoke();
        
    }
    internal void Start()
    {
        if(!runInAwake) StateUpdate();

    }

    virtual internal void Awake()
    {
        if(runInAwake) StateUpdate();
    }

    internal bool intToBool(int val)
    {
        if(val != 0) return true;
        return false;
    }


}

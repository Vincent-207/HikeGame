using System;
using UnityEngine;
using UnityEngine.Events;

public class StateListener : MonoBehaviour
{
    [SerializeField] String StateParam;
    [SerializeField] bool runInAwake;
    public UnityEvent OnStateEvent;

    public void StateUpdate()
    {
        bool state = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(state) OnStateEvent.Invoke();
        
    }
    void Start()
    {
        if(!runInAwake) StateUpdate();

    }

    void Awake()
    {
        if(runInAwake) StateUpdate();
    }

    bool intToBool(int val)
    {
        if(val != 0) return true;
        return false;
    }


}

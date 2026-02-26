using System;
using UnityEngine;
using UnityEngine.Events;

public class MultiStateListener : StateListener
{
    [SerializeField] string[] StateParams;
    public UnityEvent unlocked;
    public override void StateUpdate()
    {
        Debug.Log("Checking!");
        bool allStatesTrue = true;
        foreach(string StateParam in StateParams)
        {

            bool state = intToBool(PlayerPrefs.GetInt(StateParam, 0));
            if(state == false) allStatesTrue = false;
            Debug.Log("State: " + state);
        }


        if(allStatesTrue) 
        {
            if(intToBool(PlayerPrefs.GetInt(StateParam, 0)) == false)
            {
                unlocked.Invoke();
            }
            Debug.Log("All states true!");
            PlayerPrefs.SetInt(StateParam, 1);
            OnStateEvent.Invoke();
        }
    }
}

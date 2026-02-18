using System;
using UnityEngine;

public class DoorHinge : MonoBehaviour
{
    [SerializeField] bool unlocked;
    [SerializeField] String stateParam;
    [SerializeField] Vector3 closedEuler, openEuler;
    void Start()
    {
        UpdateState();
    }

    public void UpdateState()
    {
        unlocked = intToBool(PlayerPrefs.GetInt(stateParam, 0));
        transform.localEulerAngles = unlocked ? openEuler : closedEuler;
    }


    bool intToBool(int val)
    {
        if(val != 0) return true;
        else return false;
    }
}

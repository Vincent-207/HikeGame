using System;
using UnityEngine;

public class ObjectStateManager : MonoBehaviour
{
    [SerializeField] String StateParam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool pickedUp = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(pickedUp)
        {
            Destroy(gameObject);
        }
    }

    bool intToBool(int val)
    {
        if(val != 0) return true;
        else return false;
    }
}

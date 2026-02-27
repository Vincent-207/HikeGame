
using System;
using UnityEngine;
using UnityEngine.Events;

public class WallButtonHelper : MonoBehaviour
{
    [SerializeField] Vector3 pos;
    [SerializeField] Transform buttonTransform;
    [SerializeField] GameObject tapeObj;
    [SerializeField] String stateParam;
    public UnityEvent OnTapeApply;
    void Start()
    {
        bool hasBeenPlaced = PlayerPrefs.GetInt(stateParam) == 1;
        if(hasBeenPlaced)
        {
            tapeObj.SetActive(true);
            buttonTransform.localPosition = pos;
            
        }
    }
    public void ApplyTape()
    {
        tapeObj.SetActive(true);
        buttonTransform.localPosition = pos;
        // PlayerPrefs.SetInt(stateParam, 1);
        OnTapeApply.Invoke();
        MouseControl.instance.Default();
    }

}

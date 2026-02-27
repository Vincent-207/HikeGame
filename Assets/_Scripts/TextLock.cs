using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextLock : MonoBehaviour
{
    [SerializeField] String correctCode;
    public UnityEvent onUnlock, onFailedTry;
    [SerializeField] String StateParam;
    [SerializeField] TMP_InputField input;
    public void Try()
    {
        String entered = input.text;
        Debug.Log("Entered: " + entered);
        if(entered == correctCode)
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

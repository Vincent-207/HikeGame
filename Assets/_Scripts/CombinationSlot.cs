using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CombinationSlot : MonoBehaviour
{
    [SerializeField] int currentValue, minValue, maxValue;
    [SerializeField] TMP_Text textBox;
    [SerializeField]
    AudioClip[] clinks;
    AudioSource audioSource;
    void UpdateText()
    {
        if(textBox == null) Debug.Log("Text is null!");
        textBox.text = String.Format("{0:00}", currentValue);

    }
    void Start()
    {
        currentValue = minValue;
        UpdateText();
        audioSource = GetComponent<AudioSource>();
    }
    public void Increment()
    {
        currentValue++;
        if(currentValue > maxValue)
        {
            currentValue = minValue;
        }
        UpdateText();
        PlayClink();
    }

    public void Decrement()
    {
        currentValue--;
        if(currentValue < minValue)
        {
            currentValue = maxValue;
        }
        UpdateText();
        PlayClink();
    }
    void PlayClink()
    {
        AudioClip clink = clinks[UnityEngine.Random.Range(0, clinks.Length)];
        audioSource.PlayOneShot(clink);
    }

    public int GetValue()
    {
        return currentValue;
    }


}

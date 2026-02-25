using System;
using Unity.VisualScripting;
using UnityEngine;

public class ScaryLadyHelper : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField] String StateParam;
    AudioSource audioSource;
    public void GiveMedicine()
    {
        TextHoverable textHoverable = gameObject.AddComponent<TextHoverable>();
        textHoverable.hoverText = "Thank you for the medicine bottle.\nI feel so much better after vomiting out that handle.";
        GameObject newLady = Instantiate(prefab, transform.parent);
        newLady.transform.SetPositionAndRotation(transform.position, transform.rotation);
        newLady.transform.localScale = transform.localScale;
        newLady.transform.SetSiblingIndex(1);
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        bool state = intToBool(PlayerPrefs.GetInt(StateParam, 0));
        if(state) GiveMedicine();
    }

    bool intToBool(int val)
    {
        if(val != 0) return true;
        else return false;
    }

    
}

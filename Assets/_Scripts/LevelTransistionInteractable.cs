using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelTransistionInteractable : LevelInteractable
{
    [SerializeField] internal String SceneToLoad;
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Transition!");
        SceneManager.LoadScene(SceneToLoad);
    }
}

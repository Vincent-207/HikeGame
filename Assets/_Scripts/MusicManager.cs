using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    internal String[] scenesToDestroyOn, scenesToPauseOn;
    internal AudioSource audioSource;
    [SerializeField] internal String StateParam;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    virtual internal void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        String loadedName = scene.name;
        Debug.Log("Loaded scene: " + loadedName);
        if(scenesToDestroyOn.Contains(loadedName))
        {
            
            Destroy(this.gameObject);
            return;
        }
        else if(scenesToPauseOn.Contains(loadedName))
        {
            audioSource.Pause();
        }
        else audioSource.UnPause();

    }
    void Awake()
    {
        // transform.SetParent(transform.parent.parent);
        bool isDontDestroy = (gameObject.scene.name == "DontDestroyOnLoad");
        if(!isDontDestroy) DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();


        bool shouldDestroy = PlayerPrefs.GetInt(StateParam, 0) == 1;
        if(shouldDestroy) Destroy(this.gameObject);
        else PlayerPrefs.SetInt(StateParam, 1);
    }
}

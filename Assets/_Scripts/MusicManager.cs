using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    String[] scenesToDestroyOn, scenesToPauseOn;
    AudioSource audioSource;
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        String loadedName = scene.name;
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
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
}

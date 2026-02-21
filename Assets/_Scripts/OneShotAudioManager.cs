using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OneShotAudioManager : MonoBehaviour
{
    public static OneShotAudioManager instance;
    AudioSource audioSource;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayClipOneShot(AudioClip audioClip)
    {
        
    }
}

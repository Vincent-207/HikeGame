using UnityEngine;

public class ItemAudio : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] clips;
    float basePitch;
    public float variance;
    internal virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        basePitch = audioSource.pitch;
    }

    public void PlayRandom()
    {
        AudioClip choice = clips[Random.Range(0, clips.Length)];
        audioSource.pitch = basePitch + Random.Range(-variance, variance);
        audioSource.PlayOneShot(choice);
    }
}

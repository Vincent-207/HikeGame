using System;
using UnityEngine;

public class ItemEventAudio : MonoBehaviour
{
    [SerializeField] internal AudioGroup[] audioGroups;
    AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayRandomInGroup(int groupIndex)
    {
        Debug.Log("Length: " +  audioGroups[groupIndex].audioClips.Length);
        int random = UnityEngine.Random.Range(0, audioGroups[groupIndex].audioClips.Length);
        AudioClip clipToPlay = audioGroups[groupIndex].audioClips[random];
        audioSource.PlayOneShot(clipToPlay);
    }
}
[Serializable]
internal class AudioGroup
{
    public String name;
    public AudioClip[] audioClips;
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleSound : MusicManager
{
    [SerializeField]
    float minWaitTime, maxWaitTime, currentDuration;
    Coroutine currentSound;
    internal override void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        base.OnLevelLoaded(scene, loadSceneMode);
        // if(currentSound != null) StopCoroutine(currentSound);
        // QueueNewSound();
    }
    void Start()
    {
        QueueNewSound();
    }

    IEnumerator queueSound(float duration)
    {
        float currentTime = duration;
        while(currentTime > 0)
        {
            currentDuration = currentTime;  
            currentTime -= Time.deltaTime;
            yield return null;
        }
        Debug.Log("playing sound!");
        audioSource.Play();
        QueueNewSound();
    }

    void QueueNewSound()
    {
        float waitTimeToPlay = Random.Range(minWaitTime, maxWaitTime);
        // StopCoroutine(currentSound);
        currentSound = StartCoroutine(queueSound(waitTimeToPlay));
    }
}

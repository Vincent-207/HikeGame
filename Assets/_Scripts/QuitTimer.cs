using System.Collections;
using UnityEngine;

public class QuitTimer : MonoBehaviour
{
    public float timeToQuit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DoQuit(timeToQuit));
    }
    IEnumerator DoQuit(float duration)
    {
        float currentTime = duration;
        while(currentTime > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }

        Application.Quit();
    }
}

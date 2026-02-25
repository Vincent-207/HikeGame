using UnityEngine;

public class WalkAudio : ItemAudio
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    internal override void Start()
    {
        base.Start();
        PlayRandom();
    }
}

using System;
using UnityEngine;

public class LockAudio : ItemEventAudio
{
    private enum LockAudioGroups
    {
        clink,
        locked,
        unlocked
    }

    protected override void Awake()
    {
        base.Awake();

        audioGroups ??= new AudioGroup[3];
        String[] names = Enum.GetNames(typeof(LockAudioGroups));
        for(int i = 0; i < names.Length; i++)
        {
            Debug.Log("Name: " + names[i]);
            audioGroups[i].name = names[i];
        }
    }
    private void Start()
    {
        LockSlot[] lockSlots = GetComponentsInChildren<LockSlot>();
        foreach(LockSlot lockSlot in lockSlots)
        {
            lockSlot.ValueChanged.AddListener(() => {PlayRandomInGroup((int) LockAudioGroups.clink );});
        }

        GetComponent<Lock>().locked.AddListener(() => {PlayRandomInGroup((int) LockAudioGroups.locked);});
        GetComponent<Lock>().unlocked.AddListener(() => {PlayRandomInGroup((int) LockAudioGroups.unlocked);});
    }
}

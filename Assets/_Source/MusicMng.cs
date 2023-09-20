using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class MusicMng : DestoyedEventObj
{
    private AudioSource _as;
    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    private void StopMusic()
    {
        _as.Stop();
    }
    protected override void SetEventActionData()
    {
        _eventAction = new List<EventActionData>();
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventCrush, StopMusic));
    }
}

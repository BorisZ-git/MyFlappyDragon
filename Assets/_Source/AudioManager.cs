using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : DestoyedEventObj
{
    [Header("Audio SFX Clips")]
    [SerializeField] private AudioClip _fly;
    [SerializeField] private AudioClip _crush;
    [SerializeField] private AudioClip _passObstacle;

    private AudioSource _as;
    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    protected override void SetEventActionData()
    {
        _eventAction = new List<EventActionData>();
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventCrush, PlayACCrush));
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventFly, PlayACFly));
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventPassObstacle, PlayACPassObstacle));
    }
    private void PlayACPassObstacle()
    {
        _as.PlayOneShot(_passObstacle);
    }
    private void PlayACFly()
    {
        _as.PlayOneShot(_fly);
    }
    private void PlayACCrush()
    {
        _as.PlayOneShot(_crush);
    }
}






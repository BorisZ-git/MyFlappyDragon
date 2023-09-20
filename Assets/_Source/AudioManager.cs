using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : DestoyedEventObj
{
    [SerializeField] private AudioMixer _aMixer;
    [SerializeField] private AudioMixerSnapshot _pauseSnapshot;
    [SerializeField] private AudioMixerSnapshot _unPauseSnapshot;
    [SerializeField] private float _timeToReachSnapshot = 0.001f;

    [Header("Audio SFX Clips")]
    [SerializeField] private AudioClip _fly;
    [SerializeField] private AudioClip _crush;
    [SerializeField] private AudioClip _passObstacle;

    private AudioSource _as;
    private bool _isPause;
    private float _currentVolume = 1f;
    private bool _mute;

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
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventGamePause, SetPauseSnapshot));
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventMuteSFX, MuteSFX));
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
    private void SetPauseSnapshot()
    {
        _isPause = !_isPause;
        if (_isPause)
            _pauseSnapshot.TransitionTo(_timeToReachSnapshot);
        else
            _unPauseSnapshot.TransitionTo(_timeToReachSnapshot);
    }
    private void MuteSFX()
    {
        _mute = !_mute;
        _as.volume = _as.volume == 0  ? _currentVolume : 0;
    }
    public void SetSFXVolume(float value)
    {
        _currentVolume = Mathf.Clamp(value, 0f, 1f);
        if (!_mute)
            _as.volume = _currentVolume;
    }
}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class MusicMng : DestoyedEventObj
{
    private AudioSource _as;
    private float _currentVolume = 1f;
    private bool _mute;
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
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventMuteSound, MuteMusic));
    }
    private void MuteMusic()
    {
        _mute = !_mute;
        _as.volume = _as.volume == 0 ? _currentVolume : 0;
    }
    public void SetMusicVolume(float value)
    {
        _currentVolume = Mathf.Clamp(value, 0f, 1f);
        if(!_mute)
            _as.volume = _currentVolume;
    }
}

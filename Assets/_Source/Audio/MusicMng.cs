using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class MusicMng : MonoBehaviour
{
    private AudioSource _as;
    private float _currentVolume = 1f;
    private bool _mute;

    private void StopMusic()
    {
        _as.Stop();
    }
    private void PlayMusic()
    {
        _as.Play();
    }
    public void Init()
    {
        _as = GetComponent<AudioSource>();
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(StopMusic);
        GameManager.Singltone.GameEvents.EventResetGame.Subscribe(PlayMusic);
        GameManager.Singltone.UIEvents.EventMuteMusic.Subscribe(MuteMusic);
        GameManager.Singltone.UIEvents.EventChangeMusicVolume.Subscribe(SetMusicVolume);
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

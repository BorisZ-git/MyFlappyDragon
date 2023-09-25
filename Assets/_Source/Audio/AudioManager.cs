using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [Header("Mixer Snapshots")]
    [SerializeField] private AudioMixerSnapshot _pauseSnapshot;
    [SerializeField] private AudioMixerSnapshot _unPauseSnapshot;
    [SerializeField] private float _timeToReachSnapshot = 0.001f;

    [Header("Audio SFX Clips")]
    [SerializeField] private AudioClip _fly;
    [SerializeField] private AudioClip _crush;
    [SerializeField] private AudioClip _passObstacle;

    private AudioSource _as;
    private MusicMng _musicMng;
    private bool _isPause;
    private float _currentVolume = 1f;
    private bool _mute;

    public void Init()
    {
        _as = GetComponent<AudioSource>();
        InitMusicMng();
        EventSubscribe();
        DontDestroyOnLoad(this);
    }
    private void EventSubscribe()
    {
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(PlayACCrush);
        GameManager.Singltone.GameEvents.EventFly.Subscribe(PlayACFly);
        GameManager.Singltone.GameEvents.EventPassObstacle.Subscribe(PlayACPassObstacle);
        GameManager.Singltone.GameEvents.EventGamePause.Subscribe(SetPauseSnapshot);
        GameManager.Singltone.UIEvents.EventMuteSFX.Subscribe(MuteSFX);
        GameManager.Singltone.UIEvents.EventChangeSFXVolume.Subscribe(SetSFXVolume);
    }
    private void InitMusicMng()
    {
        _musicMng = GetComponentInChildren<MusicMng>();
        if(_musicMng != null)
        {
            _musicMng.Init();
        }
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






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Sprite _soundON;
    [SerializeField] private Button _btnSound;
    [SerializeField] private Button _btnSFX;
    [SerializeField] private AudioMixer _aMixer;
    [SerializeField] private TMP_Dropdown _drDownDifficulty;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Singltone.SetGamePause(_panelMenu);
        }
    }
    private bool _isSoundOff, _isSFXoff;
    private void Start()
    {
        GameManager.Singltone.SetGamePause(_panelMenu);
    }
    public void Init()
    {

    }
    public void BtnPlayGame()
    {
        GameManager.Singltone.SetGamePause(_panelMenu);
    }
    public void BtnSoundTurn()
    {
        _isSoundOff = !_isSoundOff;
        if (_isSoundOff)
        {
            _btnSound.image.sprite = _soundOff;

            //AudioManager
            //_aMixer.TransitionToSnapshots()
            //AudioSource audioSource = new AudioSource();
            //audioSource.volume = 0;
        }
        else
        {
            _btnSound.image.sprite = _soundON;

            //AudioManager
            //_aMixer.TransitionToSnapshots()
            //AudioSource audioSource = new AudioSource();
            //audioSource.volume = private float _ currentVolume;
        }
    }
    public void BtnSFXTurn()
    {
        _isSFXoff = !_isSFXoff;
        if (_isSFXoff)
        {
            _btnSFX.image.color = Color.clear;
            //AudioManager
            //_aMixer.TransitionToSnapshots()
            //AudioSource audioSource = new AudioSource();
            //audioSource.volume = 0;
        }
        else
        {
            _btnSFX.image.color = Color.white;
            //AudioManager
            //_aMixer.TransitionToSnapshots()
            //AudioSource audioSource = new AudioSource();
            //audioSource.volume = private float _ currentVolume;
        }
    }
    public void ChangeDifficulty(int value)
    {
        print($"Easy: {value == (int)Difficulty.Easy}");
        print($"Hard: {value == (int)Difficulty.Hard}");
        print($"Normal: {value == (int)Difficulty.Normal}");
        //if(value == (int)Difficulty.Easy)
        //{
        //    GameManager.Singltone.ChangeSpeed(1.5f);
        //}
        //switch (value)
        //{
        //    case Difficulty.Easy:
        //        ChangeSpeed(1.5f);
        //        break;
        //    case Difficulty.Normal:
        //        ChangeSpeed(2.5f);
        //        break;
        //    case Difficulty.Hard:
        //        ChangeSpeed(3.5f);
        //        break;
        //    default:
        //        break;
        //}
    }
    public void BtnExit()
    {
        Application.Quit();
    }
}

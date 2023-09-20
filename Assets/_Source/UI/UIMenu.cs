using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIMenu : DestoyedEventObj
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Sprite _soundON;
    [SerializeField] private Button _btnSound;
    [SerializeField] private Button _btnSFX;
    [SerializeField] private AudioMixer _aMixer;
    [SerializeField] private TMP_Dropdown _drDownDifficulty;
    [SerializeField] private AudioManager _aMng;
    private ActionMap _uiControl;

    private bool _isSoundOff, _isSFXoff;

    public void Init()
    {
        _uiControl = new ActionMap();
        Bind();
        _drDownDifficulty.value = (int)GameManager.Singltone.CurrentDifficulty;
    }
    private void Bind()
    {
        _uiControl.UI.Enable();
        _uiControl.UI.Menu.started += CallMenuPause;
    }
    private void Untying()
    {
        _uiControl.Disable();
        _uiControl.UI.Menu.started -= CallMenuPause;
    }
    protected override void SetEventActionData()
    {
        _eventAction = new List<EventActionData>();
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventGamePause, SetActiveMenu));
    }
    protected override void OnDestroy()
    {
        Untying();
        base.OnDestroy();
    }
    protected override void Start()
    {
        Init();
        base.Start();
    }
    private void CallMenuPause(InputAction.CallbackContext obj)
    {
        MenuPause();
    }
    private void SetActiveMenu()
    {
        GameManager.Singltone.SetGamePause(_panelMenu);
    }
    private void MenuPause()
    {
        if(!Player.Singltone.IsCrush)
            GameManager.Singltone.GameEvents.EventGamePause.OnEvent();
    }
    public void BtnPlayGame() 
    {
        MenuPause();
    }
    public void BtnSoundTurn()
    {
        _isSoundOff = !_isSoundOff;
        if (_isSoundOff)
        {
            _btnSound.image.sprite = _soundOff;
        }
        else
        {
            _btnSound.image.sprite = _soundON;
        }
        GameManager.Singltone.GameEvents.EventMuteSound.OnEvent();
    }
    public void BtnSFXTurn()
    {
        _isSFXoff = !_isSFXoff;
        if (_isSFXoff)
        {
            _btnSFX.image.color = Color.clear;
        }
        else
        {
            _btnSFX.image.color = Color.white;
        }
        GameManager.Singltone.GameEvents.EventMuteSFX.OnEvent();
    }
    public void ChangeDifficulty(int value)
    {
        switch (value)
        {
            case (int)Difficulty.Easy:
                GameManager.Singltone.ChangeDifficulty(Difficulty.Easy);
                break;
            case (int)Difficulty.Normal:
                GameManager.Singltone.ChangeDifficulty(Difficulty.Normal);
                break;
            case (int)Difficulty.Hard:
                GameManager.Singltone.ChangeDifficulty(Difficulty.Hard);
                break;
            default:
                break;
        }
    }
    public void BtnExit()
    {
        Application.Quit();
    }
}

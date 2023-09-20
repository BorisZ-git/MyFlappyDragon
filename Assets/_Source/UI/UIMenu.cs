using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Sprite _soundON;
    [SerializeField] private Button _btnSound;
    [SerializeField] private Button _btnSFX;
    [SerializeField] private TMP_Dropdown _drDownDifficulty;
    private ActionMap _uiControl;

    private bool _isSoundOff, _isSFXoff;

    public void Init()
    {
        if (_uiControl == null)
        {
            _uiControl = new ActionMap();
            Bind();
        }
        _drDownDifficulty.value = (int)GameManager.Singltone.CurrentDifficulty;
    }
    private void Bind()
    {
        _uiControl.UI.Enable();
        _uiControl.UI.Menu.started += CallMenuPause;
        GameManager.Singltone.GameEvents.EventGamePause.Subscribe(SetActiveMenu);
    }
    private void CallMenuPause(InputAction.CallbackContext obj)
    {
        MenuPause();
    }
    private void MenuPause()
    {
        if (!GameManager.Singltone.LinksData.Player.IsCrush)
            GameManager.Singltone.GameEvents.EventGamePause.OnEvent();
    }
    private void SetActiveMenu()
    {
        GameManager.Singltone.SetGamePause(_panelMenu);
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

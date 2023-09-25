using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
[RequireComponent(typeof(UIManager))]
public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Sprite _soundON;
    [SerializeField] private Button _btnSound;
    [SerializeField] private Button _btnSFX;
    [SerializeField] private TMP_Dropdown _drDownDifficulty;

    private bool _isSoundOff, _isSFXoff;

    public void Init()
    {
        GameManager.Singltone.GameEvents.EventGamePause.Subscribe(SetActiveMenu);
        _drDownDifficulty.value = (int)GameManager.Singltone.DifficultySettings.CurrentDif;
    }
    private void SetActiveMenu()
    {
        GameManager.Singltone.SetGamePause(_panelMenu);
    }
    public void MusicTurn()
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
    }
    public void SFXTurn()
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
    }
}

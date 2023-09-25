using UnityEngine;

[RequireComponent(typeof(UIManager))]
public sealed class UIEvents : MonoBehaviour
{
    private UIManager _uiMng;
    public void Init(UIManager uiMng)
    {
        _uiMng = uiMng;
    }
    public void BtnPlayGame()
    {
        GameManager.Singltone.UIEvents.EventPressBtnPlay.OnEvent();
    }
    public void BtnMusicTurn()
    {
        _uiMng.UIMenu.MusicTurn();
        GameManager.Singltone.UIEvents.EventMuteMusic.OnEvent();
    }
    public void BtnSfxTurn()
    {
        _uiMng.UIMenu.SFXTurn();
        GameManager.Singltone.UIEvents.EventMuteSFX.OnEvent();
    }
    public void ChangeSFXVolume(float value)
    {
        GameManager.Singltone.UIEvents.EventChangeSFXVolume.OnEventValue(value);
    }
    public void ChangeMusicVolume(float value)
    {
        GameManager.Singltone.UIEvents.EventChangeMusicVolume.OnEventValue(value);
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
        GameManager.Singltone.UIEvents.EventExitGame.OnEvent();
        Application.Quit();
    }
}

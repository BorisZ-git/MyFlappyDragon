using UnityEngine.InputSystem;

public sealed class InputManager
{
    private ActionMap _inputActions;
    private bool _isPlayerBind;
    public InputManager()
    {
        _inputActions = new ActionMap();
        Init();
    }
    private void Init()
    {
        _inputActions.Enable();
        BindPlayer();
        BindUI();
        BindEventSubscribe();
    }
    private void BindEventSubscribe()
    {
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(UntyingPlayer);
        GameManager.Singltone.GameEvents.EventResetGame.Subscribe(BindPlayer);
        GameManager.Singltone.UIEvents.EventPressBtnPlay.Subscribe(MenuEvent);
    }
    private void BindPlayer()
    {
        _inputActions.Player.Fly.started += CallFlyUp;
        _isPlayerBind = true;
    }
    private void BindUI()
    {
        _inputActions.UI.Menu.started += CallMenuPause;
    }
    private void UntyingPlayer()
    {
        _inputActions.Player.Fly.started -= CallFlyUp;
        _isPlayerBind = false;
    }
    private void MenuEvent()
    {
        if (_isPlayerBind)
            UntyingPlayer();
        else
            BindPlayer();
        GameManager.Singltone.GameEvents.EventGamePause.OnEvent();
    }
    private void CallFlyUp(InputAction.CallbackContext context)
    {
        GameManager.Singltone.GameEvents.EventFly.OnEvent();
    }
    private void CallMenuPause(InputAction.CallbackContext context)
    {
        if(!GameManager.Singltone.LinksData.Player.IsCrush)
            MenuEvent();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl
{
    private ActionMap _actionMap;

    public PlayerControl()
    {
        _actionMap = new ActionMap();
        Bind();
    }
    public void Bind()
    {
        _actionMap.Player.Enable();
        _actionMap.Player.Fly.started += CallFlyUp;
    }
    public void Untying()
    {
        _actionMap.Player.Disable();
        _actionMap.Player.Fly.started -= CallFlyUp;
    }
    private void CallFlyUp(InputAction.CallbackContext context)
    {
        //Player.Singltone.PlayerMove.FlyUp();
        GameManager.Singltone.GameEvents.EventFly.OnEvent();
    }
}

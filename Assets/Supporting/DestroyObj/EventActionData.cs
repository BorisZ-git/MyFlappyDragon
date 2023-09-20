using UnityEngine;
using System;

public sealed class EventActionData
{
    private GeneralEvent _e;
    private Action _action;
    public EventActionData(GeneralEvent e, Action action)
    {
        _e = e;
        _action = action;
    }

    public GeneralEvent E { get => _e; }
    public Action Action { get => _action; }

}

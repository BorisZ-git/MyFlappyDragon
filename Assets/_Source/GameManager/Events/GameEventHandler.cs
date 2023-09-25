using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEventHandler : GeneralEventHandler
{
    private GeneralEvent _eventPassObstacle;
    private GeneralEvent _eventCrush;
    private GeneralEvent _eventFly;
    private GeneralEvent _eventGamePause;
    private GeneralEvent _eventResetGame;

    public GeneralEvent EventPassObstacle { get => _eventPassObstacle; }
    public GeneralEvent EventCrush { get => _eventCrush; }
    public GeneralEvent EventFly { get => _eventFly; }
    public GeneralEvent EventGamePause { get => _eventGamePause; }
    /// <summary>
    /// Event that run on Restart Lvl(After first run of game)
    /// </summary>
    public GeneralEvent EventResetGame { get => _eventResetGame; }

    protected override void GenerateEvents()
    {
        _eventPassObstacle = new GeneralEvent();
        _eventCrush = new GeneralEvent();
        _eventFly = new GeneralEvent();
        _eventGamePause = new GeneralEvent();
        _eventResetGame = new GeneralEvent();
    }
    protected override void SetEventsList()
    {
        base.SetEventsList();
        _events.Add(_eventPassObstacle);
        _events.Add(_eventCrush);
        _events.Add(_eventFly);
        _events.Add(_eventGamePause);
        _events.Add(_eventResetGame);
    }
}

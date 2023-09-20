using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEventHandler
{
    private PassObstacleEvent _eventPassObstacle;
    private CrushEvent _eventCrush;
    private GeneralEvent _eventFly;
    private GeneralEvent _eventGamePause;
    private List<GeneralEvent> _events;
    public PassObstacleEvent EventPassObstacle { get => _eventPassObstacle; }
    public CrushEvent EventCrush { get => _eventCrush; }
    public GeneralEvent EventFly { get => _eventFly; }
    public List<GeneralEvent> Events { get => _events; }

    public GameEventHandler()
    {
        _eventPassObstacle = new PassObstacleEvent();
        _eventCrush = new CrushEvent();
        _eventFly = new GeneralEvent();
        _eventGamePause = new GeneralEvent();
        SetEventsList();
    }
    private void SetEventsList()
    {
        if(_events == null) _events = new List<GeneralEvent>();
        else _events.Clear();

        _events.Add(_eventPassObstacle);
        _events.Add(_eventCrush);
        _events.Add(_eventFly);
        _events.Add(_eventGamePause);
    }
}

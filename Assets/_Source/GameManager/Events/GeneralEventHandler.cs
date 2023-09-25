using System.Collections.Generic;

public abstract class GeneralEventHandler
{
    protected List<GeneralEvent> _events;
    public List<GeneralEvent> Events { get => _events; }

    public GeneralEventHandler()
    {
        GenerateEvents();
        SetEventsList();
    }
    protected abstract void GenerateEvents();
    protected virtual void SetEventsList()
    {
        if (_events == null) _events = new List<GeneralEvent>();
        else _events.Clear();
    }
}

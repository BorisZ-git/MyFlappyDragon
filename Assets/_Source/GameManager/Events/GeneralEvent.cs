using System;

/// <summary>
/// Base event class in future it can be abstract
/// </summary>
public class GeneralEvent
{
    public event Action Event;
    public void Subscribe(Action subscriber)
    {
        Event += subscriber;
    }
    public void Discribe(Action subscriber)
    {
        Event -= subscriber;
    }
    public void OnEvent()
    {
        if (Event != null)
            Event();
    }
}

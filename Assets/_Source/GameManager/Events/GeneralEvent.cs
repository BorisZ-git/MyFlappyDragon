using System;

/// <summary>
/// Base event class in future it can be abstract or we can separeta logic for some events
/// </summary>
public sealed class GeneralEvent
{
    public event Action Event;
    public event Action<float> EventValue;
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
    public void Subscribe(Action<float> subscriber)
    {
        EventValue += subscriber;
    }
    public void Discribe(Action<float> subscriber)
    {
        EventValue -= subscriber;
    }
    public void OnEventValue(float value)
    {
        if (EventValue != null)
            EventValue(value);
    }
}

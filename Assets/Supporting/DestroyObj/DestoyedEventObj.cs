using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// For not save objects having actions that executes on event
/// </summary>
public abstract class DestoyedEventObj : MonoBehaviour
{
    protected List<EventActionData> _eventAction;
    protected virtual void Start()
    {
        SetEventActionData();
        BoundBehaviour(true);
    }
    protected virtual void OnDestroy()
    {
        BoundBehaviour(false);
    }
    /// <summary>
    /// Create List eventAction. Run first in Start
    /// </summary>
    protected abstract void SetEventActionData();

    /// <summary>
    /// ћетод который подписывает или отписывает, в заданном списке, действи€ на игровые событи€, автоматизиру€ прив€зку(Start)/отв€зку(OnDestroy).
    /// </summary>
    /// <param name="subscribe">true=подписывать или false=отписывать</param>
    private void BoundBehaviour(bool subscribe)
    {
        if (_eventAction == null || _eventAction.Count == 0) return;
        foreach (var e in GameManager.Singltone.GameEvents.Events)
        {
            SetLink(e, subscribe);
        }
    }
    private void SetLink(GeneralEvent e, bool subscribe)
    {
        foreach (var item in _eventAction)
        {
            if(item.E == e)
            {
                if (subscribe)
                    e.Subscribe(item.Action);
                else
                    e.Discribe(item.Action);
            }

        }
    }
}

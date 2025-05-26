using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionExecutor : MonoBehaviour
{
    private readonly Queue<(DigimonAction, ActContext)> _queue = new();

    public void Enqueue(DigimonAction action, ActContext context)
    {
        DebugActQueueUI.Instance.AddActionText(action.GetType().Name);
        _queue.Enqueue((action, context));
    }

    public bool TryExecuteNext()
    {
        if (_queue.Count == 0) return false;

        var (action, context) = _queue.Peek();
        return action.Act(context, () =>
        {
            DebugActQueueUI.Instance.RemoveLastActionText();
            _queue.Dequeue();
        });
    }

    public (DigimonAction, ActContext) PeekNext()
    {
        if (_queue.Count == 0) return (null, null);
        return _queue.Peek();
    }

    public int GetQueueCount()
    {
        return _queue.Count;
    }
}
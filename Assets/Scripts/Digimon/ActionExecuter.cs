using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionExecutor : MonoBehaviour
{
    private readonly Queue<(DigimonAction, ActContext)> _queue = new();

    public void Enqueue(DigimonAction action, ActContext context)
    {
        _queue.Enqueue((action, context));
    }

    public bool TryExecuteNext()
    {
        if (_queue.Count == 0) return false;

        var (action, context) = _queue.Dequeue();
        return action.Act(context);
    }
}
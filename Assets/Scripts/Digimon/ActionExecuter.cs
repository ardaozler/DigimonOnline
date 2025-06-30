using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionExecutor : MonoBehaviour
{
    public Queue<(DigimonAction, ActContext)> _queue = new();

    public void Enqueue(DigimonAction action, ActContext context)
    {
        if (PeekNext().Item1 == (action))
        {
            Debug.LogWarning("Action already in queue: " + action.GetType().Name + "" +
                             "\n Dequeue it first before adding again.");
            DequeueAction(action);
        }

        _queue.Enqueue((action, context));
    }

    public bool TryExecuteNext()
    {
        if (_queue.Count == 0) return false;

        var (action, context) = _queue.Peek();
        bool isActing = action.Act(context, () => { DequeueAction(action); });
        
        if (!isActing) DequeueAction(action);
        
        return isActing;
    }

    private void DequeueAction(DigimonAction action)
    {
        _queue.Dequeue();
        Debug.Log("dequeued action: " + action.GetType().Name);
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
using System;
using UnityEngine;

public abstract class DigimonAction
{
    public bool IsBlocking = true;

    public virtual bool Act(ActContext actContext, Action onActionCompleted)
    {
        Debug.Log(actContext + " acted");
        return true;
    }
}

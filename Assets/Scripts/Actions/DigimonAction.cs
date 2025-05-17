using UnityEngine;

public abstract class DigimonAction
{
    public bool IsBlocking = true;

    public virtual bool Act(ActContext actContext)
    {
        Debug.Log(actContext + " acted");
        return true;
    }
}
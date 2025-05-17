using UnityEngine;

public abstract class DigimonAction
{
    public virtual bool Act(GameObject actor)
    {
        Debug.Log(actor.name + "acted");
        return true;
    }
}
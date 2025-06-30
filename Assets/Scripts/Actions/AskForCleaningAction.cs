using System;
using UnityEngine;

//TODO: add it as an urge action
public class AskForCleaningAction : DigimonAction
{
    public override bool Act(ActContext actContext, Action onActionCompleted)
    {
        //sits and asks for cleaning, block the action queue, wait indefinitely for the player to clean
        
        if (actContext is not GameObjectContext context)
        {
            Debug.LogError("AskForCleaningAction requires a GameObjectContext.");
            return false;
        }
        var mover = context.Agent.GetComponent<DigimonMover>();
        if (mover == null)
        {
            Debug.LogError("AskForCleaningAction requires a DigimonMover component on the agent.");
            return false;
        }
        
        // Set the movement strategy to sit
        
        return base.Act(actContext, onActionCompleted);
    }
}
using System;
using UnityEngine;

//TODO: add it as an urge action
public class AskForCleaningAction : DigimonAction
{
    private int x = 100000;
    private float _cleaningRequestTimer = 3f;
    public override bool Act(ActContext actContext, Action onActionCompleted)
    {
        //sits and asks for cleaning, block the action queue, wait indefinitely for the player to clean

        //start the animation
        
        while (true)
        {
            x--;
            if(x == 0)
            {
                Debug.Log("Cleaning request timed out.");
                break;
            }
        }
        
        return base.Act(actContext, onActionCompleted);
    }
}
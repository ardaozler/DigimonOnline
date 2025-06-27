using System;

public class WaitForCleaningAction : DigimonAction
{
    public override bool Act(ActContext actContext, Action onActionCompleted)
    {
        //sits and waits for cleaning
        
        return base.Act(actContext, onActionCompleted);
    }
}
using UnityEngine;

class KickBall : DigimonAction
{
    public override bool Act(ActContext actContext)
    {
        if (actContext is not GameObjectContext context)
        {
            Debug.LogError("Invalid context for AskForPets action.");
            return false;
        }
        GameObject agent = context.Agent;
        
        

        return base.Act(context);
    }
}
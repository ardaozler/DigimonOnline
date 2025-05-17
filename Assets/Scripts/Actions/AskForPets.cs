using UnityEngine;

class AskForPets : DigimonAction
{
    public override bool Act(ActContext actContext)
    {
        if (actContext is not GameObjectContext context)
        {
            Debug.LogError("Invalid context for AskForPets action.");
            return false;
        }

        return base.Act(context);
    }
}
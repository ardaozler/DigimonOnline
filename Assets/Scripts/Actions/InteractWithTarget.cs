using UnityEngine;

public class InteractWithTarget : DigimonAction
{
    public override bool Act(ActContext actContext)
    {
        if (actContext is not GenericInteractContext context)
        {
            Debug.LogError("Invalid context for InteractWithTarget");
            return false;
        }

        return context.Target.Interact(context.Context);
    }
}
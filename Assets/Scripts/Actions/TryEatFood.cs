using UnityEngine;

public class TryEatFood : DigimonAction
{
    public override bool Act(ActContext actContext)
    {
        if (actContext is not TryEatContext context)
        {
            Debug.LogError("Invalid context for TryEatFood action.");
            return false;
        }

        GameObject agent = context.Agent;
        EdibleInteractable edibleInteractable = context.EdibleInteractable;

        if (edibleInteractable.IsBeingEaten)
        {
            Debug.Log("Already being eaten");
            return false;
        }

        edibleInteractable.Interact(new EdibleInteractContext(agent));
        //TODO: animate eating and animate edible being eaten
        return true;
    }
}
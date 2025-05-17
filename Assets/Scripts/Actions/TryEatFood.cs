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
        Edible edible = context.Edible;

        if (edible.isBeingEaten)
        {
            Debug.Log("Already being eaten");
            return false;
        }

        edible.Eat(agent.GetComponent<Digimon>());
        //TODO: animate eating and animate edible being eaten
        edible.gameObject.SetActive(false);

        return true;
    }
}
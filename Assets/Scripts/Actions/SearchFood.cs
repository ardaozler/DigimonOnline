using UnityEngine;

public class SearchFood : DigimonAction
{
    public override bool Act(ActContext actContext)
    {
        if (actContext is not GameObjectContext context)
        {
            Debug.LogError("Invalid context for SearchFood action.");
            return false;
        }

        GameObject agent = context.Agent;

        var mover = agent.GetComponent<DigimonMover>();
        if (mover == null) return false;

        GameObject[] foodItems = GameObject.FindGameObjectsWithTag("Food");
        if (foodItems.Length == 0) return false;

        // Find the closest one
        GameObject nearest = null;
        float minDistance = float.MaxValue;
        Vector3 agentPos = agent.transform.position;

        foreach (var item in foodItems)
        {
            float dist = Vector3.Distance(agentPos, item.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearest = item;
            }
        }

        if (nearest != null)
        {
            return mover.MoveTo(nearest.transform.position, () =>
            {
                var edible = nearest.GetComponent<Edible>();
                var executor = agent.GetComponent<ActionExecutor>();
                executor.Enqueue(new TryEatFood(), new TryEatContext(agent, edible));
            });
        }

        return false;
    }
}
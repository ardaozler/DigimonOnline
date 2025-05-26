using System;
using UnityEngine;

public class SearchAction : DigimonAction
{
    public override bool Act(ActContext actContext, Action onActionCompleted)
    {
        if (actContext is not SearchContext context)
        {
            Debug.LogError("Invalid context for SearchFood action.");
            return false;
        }

        GameObject agent = context.Agent;

        var mover = agent.GetComponent<DigimonMover>();
        if (mover == null) return false;

        GameObject[] foodItems = GameObject.FindGameObjectsWithTag(context.SearchTag);
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
                onActionCompleted?.Invoke();

                if (nearest == null)
                {
                    Debug.LogWarning("No valid interactable found. Maybe already destroyed.");
                    return;
                }


                var interactable = nearest.GetComponent<DigimonInteractable>();
                var interactContext = interactable.GetContext(agent);
                var executor = agent.GetComponent<ActionExecutor>();

                if (Vector3.Distance(agent.transform.position, nearest.transform.position) >
                    DigimonInteractable.INTERACTABLE_RADIUS)
                {
                    executor.Enqueue(new SearchAction(), new SearchContext(agent, context.SearchTag));
                    Debug.Log("moveto ended and search is queued");
                }
                else
                {
                    Debug.Log("moveto ended and interact is queued");
                    executor.Enqueue(new InteractWithTarget(),
                        new GenericInteractContext(interactable, interactContext));
                }
            });
        }


        return false;
    }
}
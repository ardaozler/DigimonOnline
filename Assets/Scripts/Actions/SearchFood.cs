using UnityEngine;

public class SearchFood : DigimonAction
{
    public override bool Act(GameObject agent)
    {
        var mover = agent.GetComponent<Mover>();
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
            return mover.MoveTo(nearest.transform.position);
        }

        return false;
    }
}
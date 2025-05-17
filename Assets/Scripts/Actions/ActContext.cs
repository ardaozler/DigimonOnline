using UnityEngine;

public abstract class ActContext
{
}

public class TryEatContext : ActContext
{
    public Edible Edible;

    public GameObject Agent;
    
    public TryEatContext(GameObject agent, Edible edible)
    {
        Agent = agent;
        Edible = edible;
    }
}

public class GameObjectContext : ActContext
{
    public GameObject Agent;
    
    public GameObjectContext(GameObject agent)
    {
        Agent = agent;
    }
}
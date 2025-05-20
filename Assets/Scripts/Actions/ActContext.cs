using UnityEngine;

public abstract class ActContext
{
}

public class SearchContext : ActContext
{
    public GameObject Agent;

    public string SearchTag;

    public SearchContext(GameObject agent, string searchTag)
    {
        SearchTag = searchTag;
        Agent = agent;
    }
}

public class TryEatContext : ActContext
{
    public EdibleInteractable EdibleInteractable;

    public GameObject Agent;

    public TryEatContext(GameObject agent, EdibleInteractable edibleInteractable)
    {
        Agent = agent;
        EdibleInteractable = edibleInteractable;
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

public class GenericInteractContext : ActContext
{
    public DigimonInteractable Target;
    public InteractContext Context;

    public GenericInteractContext(DigimonInteractable target, InteractContext context)
    {
        Target = target;
        Context = context;
    }
}
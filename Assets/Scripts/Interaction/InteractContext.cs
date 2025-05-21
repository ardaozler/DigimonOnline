using System;
using UnityEngine;

public abstract class InteractContext
{
}

public class BallInteractContext : InteractContext
{
    public GameObject Agent;
    public Ball Ball;

    public BallInteractContext(GameObject agent, Ball ball)
    {
        Agent = agent;
        Ball = ball;
    }
}

public class EdibleInteractContext : InteractContext
{
    public GameObject Agent;
    public readonly Action OnFinishEating;

    public EdibleInteractContext(GameObject agent, Action onFinishEating = null)
    {
        Agent = agent;
        this.OnFinishEating = onFinishEating;
    }
}
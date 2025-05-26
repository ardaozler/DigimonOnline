using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallInteractable : DigimonInteractable
{
    public override InteractContext GetContext(GameObject agent)
    {
        Ball ball = GetComponent<Ball>();
        if (ball == null)
        {
            Debug.LogError("No Ball component found on this GameObject.");
            return null;
        }

        return new BallInteractContext(agent, ball);
    }

    public override bool Interact(InteractContext interactContext, Action onInteractionCompleted)
    {
        if (interactContext is not BallInteractContext context)
        {
            Debug.LogError("Invalid context for Ball interaction.");
            return false;
        }

        GameObject agent = context.Agent;
        Ball ball = context.Ball;

        Debug.Log($"{agent.name} kicked the ball!");
        agent.GetComponent<DigimonStats>().UpdateUrge("Happiness", 50f);

        var direction = (ball.transform.position - agent.transform.position);
        direction.y = 0; // Keep the direction horizontal
        direction.Normalize();

        onInteractionCompleted?.Invoke();

        var ballDestination = ball.transform.position + direction * Random.Range(2f, 3f);
        return ball.MoveTo(ballDestination);
    }
}
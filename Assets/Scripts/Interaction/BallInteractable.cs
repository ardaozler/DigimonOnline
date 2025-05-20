using UnityEngine;

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
    
    public override bool Interact(InteractContext interactContext)
    {
        if (interactContext is not BallInteractContext context)
        {
            Debug.LogError("Invalid context for Ball interaction.");
            return false;
        }

        GameObject agent = context.Agent;
        Ball ball = context.Ball;

        Debug.Log($"{agent.name} kicked the ball!");


        var ballDestination = ball.transform.position + new Vector3(Random.insideUnitCircle.x, 0f,
            Random.insideUnitCircle.y * Random.Range(1f, 3f));
        return ball.MoveTo(ballDestination);
    }
}
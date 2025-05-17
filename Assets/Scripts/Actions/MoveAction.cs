using UnityEngine;

public class MoveAction : DigimonAction
{
    private float _minDecisionWait;
    private float _maxDecisionWait;
    private float _timer;
    private Mover _mover;

    public MoveAction(float minDecisionWait, float maxDecisionWait)
    {
        _minDecisionWait = minDecisionWait;
        _maxDecisionWait = maxDecisionWait;
        _timer = 0f;
    }

    public override bool Act(ActContext actContext)
    {
        if (actContext is not GameObjectContext context)
        {
            Debug.LogError("Invalid context for MoveAction.");
            return false;
        }

        var actor = context.Agent;

        _mover = actor.GetComponent<Mover>();

        if (Random.Range(0, 50) != 0) return false;
        var destination = actor.transform.position + new Vector3(Random.insideUnitCircle.x, 0f,
            Random.insideUnitCircle.y * Random.Range(1f, 3f));
        _mover.MoveTo(destination);
        _timer = 0;
        return true;
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Mover))]
public class Digimon : MonoBehaviour
{
    public float maxDecisionWait;
    public float minDecisionWait;
    private float _timer = 0f;

    private MoveAction _moveAction;

    private Urge _hunger = new Urge("Hunger", 0.5f, new SearchFood());
    private Urge _cleanliness = new Urge("Cleanliness", 0.1f);
    private Urge _happiness = new Urge("Happiness", 0.2f);
    private Urge _content = new Urge("Content", 0); // Doesn't want anything

    private Urge[] _urges = new Urge[3];
    private Urge _primaryUrge;

    private Mover _mover;

    [FormerlySerializedAs("_digimonAnimator")] 
    [SerializeField] private DigimonAnimator digimonAnimator;

    public Tilemap tilemap;

    public int Hunger; // to be deleted later
    public int Happiness;
    public int Cleanliness;

    private Queue<(DigimonAction action, ActContext context)> _actionQueue = new();

    private void Start()
    {
        // Movement
        _mover = GetComponent<Mover>();
        _mover.tilemap = tilemap;
        _mover.SetMovementStrategy(new TileWalkMovement());
        _mover.OnMovementStart += () => digimonAnimator.SetTrigger("IsMoving");

        _moveAction = new MoveAction(minDecisionWait, maxDecisionWait);

        // Urges
        _urges[0] = _hunger;
        _urges[1] = _cleanliness;
        _urges[2] = _happiness;
        _primaryUrge = _content;

        InvokeRepeating(nameof(HandleUrges), 0, 0.5f);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > minDecisionWait && _timer < maxDecisionWait)
        {
            if (TryPerformNextAction())
            {
                _timer = 0;
            }
        }
        else if (_timer >= maxDecisionWait)
        {
            _timer = 0;
        }
    }

    private bool TryPerformNextAction()
    {
        // Prioritize queued actions
        if (_actionQueue.Count > 0)
        {
            var (action, context) = _actionQueue.Dequeue();
            return action.Act(context);
        }

        // Otherwise try acting on the current urge
        var possibleAction = _primaryUrge.GetPossibleAction();
        if (possibleAction != null)
        {
            return RequestAction(possibleAction, new GameObjectContext(gameObject));
        }

        return false;
    }

    private void HandleUrges()
    {
        _primaryUrge = _content;

        foreach (var urge in _urges)
        {
            urge.Tick();
            if (urge < 50)
            {
                if (_primaryUrge == _content || _primaryUrge > urge)
                {
                    _primaryUrge = urge;
                }
            }
        }

        Hunger = _hunger.GetUrgePercentage();
        Cleanliness = _cleanliness.GetUrgePercentage();
        Happiness = _happiness.GetUrgePercentage();
    }

    public bool RequestAction(DigimonAction action, ActContext context)
    {
        return action.Act(context);
    }

    public void EnqueueAction(DigimonAction action, ActContext context)
    {
        _actionQueue.Enqueue((action, context));
    }
}

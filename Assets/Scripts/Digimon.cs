using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

/*
Yes. Maybe u can start with a small land with trees. And 1 agumon in it. He can move around on his own.

My job as the gamer is to feed him, clean him, play with him

For a start. If i click on him. I can see a simple bar showing

Hungry
Cleanliness
Happiness
 */

[RequireComponent(typeof(Mover))]
public class Digimon : MonoBehaviour
{
    public float maxDecisionWait;
    public float minDecisionWait;
    private float _timer = 0f;

    private MoveAction _moveAction;


    private Urge _hunger = new Urge("Hunger", 0.5f, new SearchFood()),
        _cleanliness = new Urge("Cleanliness", 0.1f),
        _happiness = new Urge("Happiness", 0.2f),
        _content = new Urge("Content", 0); //doesnt want anything;

    private Urge[] _urges = new Urge[3];
    private Urge _primaryUrge;

    private Mover _mover;

    [FormerlySerializedAs("_digimonAnimator")] [SerializeField]
    private DigimonAnimator digimonAnimator;

    public Tilemap tilemap; //TODO: change this to be set when the digimon is spawned

    public int Hunger; //to be deleted
    public int Happiness;
    public int Cleanliness;

    private void Start()
    {
        //movement
        _mover = GetComponent<Mover>();
        _mover.tilemap = tilemap;
        var movementStrategy = new TileWalkMovement(); // Injecting the strategy
        _mover.SetMovementStrategy(movementStrategy);
        _mover.OnMovementStart += () => { digimonAnimator.SetTrigger("IsMoving"); };

        _moveAction = new MoveAction(minDecisionWait, maxDecisionWait);

        //urges
        _urges[0] = _hunger;
        _urges[1] = _cleanliness;
        _urges[2] = _happiness;
        _primaryUrge = _content;
        InvokeRepeating(nameof(HandleUrges), 0, 0.5f);
    }

    private void Update()
    {
        
        _timer += Time.deltaTime;

        if (_timer > minDecisionWait)
        {
            if (_timer < maxDecisionWait)
            {
                if (_hunger.GetPossibleAction().Act(gameObject))
                {
                    _timer = 0;
                }
            }
            else
            {
                _timer = 0;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //HandleCompulsions();
    }

    /// <summary>
    /// compulsions are actions that the digimon will do 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void HandleCompulsions()
    {
        throw new System.NotImplementedException();
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
}
using UnityEngine;
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
    private Urge _hunger = new Urge("Hunger", 0.5f),
        _cleanliness = new Urge("Cleanliness", 0.1f),
        _happiness = new Urge("Happiness", 0.2f);

    private Urge[] _urges = new Urge[3];

    private Mover _mover;

    public float minDecisionWait;
    public float maxDecisionWait;

    private float _timer = 0f;

    public Tilemap tilemap; //change this to be set when the digimon is spawned

    private void Start()
    {
        //movement
        _mover = GetComponent<Mover>();
        _mover.tilemap = tilemap;
        _mover.SetMovementStrategy(new TileWalkMovement());

        //urges
        _urges[0] = _hunger;
        _urges[1] = _cleanliness;
        _urges[2] = _happiness;
        InvokeRepeating(nameof(HandleUrges), 10, 5);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > minDecisionWait)
        {
            if (_timer < maxDecisionWait)
            {
                //timer is bigger than min smaller than max time to make a decision maybe
                if (Random.Range(0, 50) == 0)
                {
                    //try to get a valid tile, if cant, retry next cycle(dont reset timer)
                    if (_mover.MoveTo(transform.position + new Vector3(Random.insideUnitCircle.x, 0f,
                            Random.insideUnitCircle.y * Random.Range(1f, 3f))))
                    {
                        _timer = 0;
                    }
                }
            }
            else
            {
                _timer = 0;
            }
        }
    }

    private void HandleUrges()
    {
        foreach (var urge in _urges)
        {
            urge.Tick();
        }
    }
}
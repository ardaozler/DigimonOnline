using System;
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
    private float _hunger, _cleanliness, _happiness; //0 to 1 will be scaled to 100
    private Mover _mover;

    public float minDecisionWait;
    public float maxDecisionWait;

    private float _timer = 0f;

    public Tilemap Tilemap; //change this to be set when the digimon is spawned

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _mover.tilemap = Tilemap;
        _mover.SetMovementStrategy(new TileWalkMovement());
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
}
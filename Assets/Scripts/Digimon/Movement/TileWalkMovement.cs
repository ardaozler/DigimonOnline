using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TileWalkMovement : IMovementStrategy
{
    public void Move(Transform transform, Vector3 destination, float speed)
    {
        //TODO: add collision detection and shite, not to this function, to another function that will use this, could be called navigate
        //maybe we can add navmesh instead of collision detection stuff, would also take care of movement.
        var currentPosition = transform.position;
        var direction = destination - currentPosition;
        currentPosition += direction.normalized * (speed * Time.deltaTime);
        currentPosition.y = transform.position.y;
        transform.position = currentPosition;
    }
}
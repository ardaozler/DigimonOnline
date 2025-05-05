using Unity.VisualScripting;
using UnityEngine;

public class TileWalkMovement : IMovementStrategy
{
    //gizmos stuff
    private Transform _transform;
    private Vector3 _destination;

    public void Move(Transform transform, Vector3 destination, float speed)
    {
        //find the middle of the nearest tile to destination, set it as destination.
        //TODO: add collision detection and shite, not to this function, to another function that will use this, could be called navigate
        //maybe we can add navmesh instead of collision detection stuff, would also take care of movement.
        var currentPosition = transform.position;
        var direction = destination - currentPosition;
        currentPosition += direction.normalized * (speed * Time.deltaTime);
        currentPosition.y = transform.position.y;
        transform.position = currentPosition;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(_transform.position, _destination);
    }
}
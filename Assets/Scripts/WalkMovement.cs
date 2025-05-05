using Unity.VisualScripting;
using UnityEngine;

public class WalkMovement : IMovementStrategy
{
    //gizmos stuff
    private Transform _transform;
    private Vector3 _destination;

    public void Move(Transform transform, Vector3 destination, float speed)
    {
        //TODO: add collision detection and shite, not to this function, to another function that will use this, could be called navigate
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
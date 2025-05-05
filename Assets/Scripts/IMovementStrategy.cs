using UnityEngine;

public interface IMovementStrategy
{
    public void Move(Transform transform, Vector3 destination, float speed);
}
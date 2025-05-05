using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;

    private IMovementStrategy _movementStrategy;

    private Vector3 _currentDestination;

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        _movementStrategy = strategy;
    }

    void Update()
    {
        if (_movementStrategy != null && Vector3.Distance(_currentDestination, transform.position) > 0.5f)
        {
            _movementStrategy.Move(transform, _currentDestination, moveSpeed);
        }
    }

    public void MoveTo(Vector3 position)
    {
        _currentDestination = position;
    }
}
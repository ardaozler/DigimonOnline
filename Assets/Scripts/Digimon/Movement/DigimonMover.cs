using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class DigimonMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private IMovementStrategy _movementStrategy;
    private Vector3 _currentDestination;
    public Tilemap tilemap;
    public event Action OnMovementStart;
    private Action _onMovementComplete;
    
    private bool _isMoving;


    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        _movementStrategy = strategy;
        _currentDestination = transform.position;
    }


    void Update()
    {
        if (_movementStrategy != null)
        {
            if (Vector3.Distance(_currentDestination, transform.position) > 0.1f)
            {
                _movementStrategy.Move(transform, _currentDestination, moveSpeed);
            }
            else
            {
                if (_isMoving)
                {
                    _isMoving = false;

                    _onMovementComplete?.Invoke();
                    _onMovementComplete = null;
                }
            }
        }
    }

    /// <summary>
    /// return true if the requested position is valid and start the movement
    /// </summary>
    /// <param name="position"></param>
    /// <param name="onComplete"></param>
    /// <returns></returns>
    public bool MoveTo(Vector3 position, Action onComplete = null)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        if (!tilemap.HasTile(cellPosition)) return false;

        _currentDestination = tilemap.GetCellCenterWorld(cellPosition);
        _currentDestination.y = transform.position.y;

        _onMovementComplete = onComplete;

        if (!_isMoving)
        {
            OnMovementStart?.Invoke();
            _isMoving = true;
        }

        return true;
    }

}
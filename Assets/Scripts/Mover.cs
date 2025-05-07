using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private IMovementStrategy _movementStrategy;
    private Vector3 _currentDestination;
    public Tilemap tilemap;

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        _movementStrategy = strategy;
        _currentDestination = transform.position;
    }


    void Update()
    {
        if (_movementStrategy != null && Vector3.Distance(_currentDestination, transform.position) > 0.1f)
        {
            _movementStrategy.Move(transform, _currentDestination, moveSpeed);
        }
    }

    public bool MoveTo(Vector3 position)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        if (!tilemap.HasTile(cellPosition)) return false;

        _currentDestination = tilemap.GetCellCenterWorld(cellPosition);
        _currentDestination.y = transform.position.y;
        return true;
    }
}
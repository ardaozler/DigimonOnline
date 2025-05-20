using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ball : BallInteractable
{
    public float Speed = 5f;
    private Vector3 _currentDestination;
    public Tilemap tilemap;

    private void Update()
    {
        if (Vector3.Distance(_currentDestination, transform.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, _currentDestination, Speed * Time.deltaTime);
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
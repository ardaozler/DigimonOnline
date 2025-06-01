using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ball : BallInteractable
{
    public float Speed = 5f;
    private Vector3 _currentDestination;
    public Tilemap tilemap;
    public bool isFalling = false;

    private void Start()
    {
        _currentDestination = transform.position;
    }

    private void Update()
    {
        HandleFalling();

        if (Vector3.Distance(_currentDestination, transform.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, _currentDestination, Speed * Time.deltaTime);
        }
    }

    private void HandleFalling()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        if (!tilemap.HasTile(cellPosition))
        {
            isFalling = true;
            _currentDestination.y = transform.position.y - 9.8f * Time.deltaTime;
            if (transform.position.y < -10f)
            {
                Destroy(this);
            }
        }
        else
        {
            isFalling = false;
        }
    }

    public bool MoveTo(Vector3 position)
    {
        if (isFalling) return false;
        Vector3Int cellPosition = tilemap.WorldToCell(position);

        _currentDestination = tilemap.GetCellCenterWorld(cellPosition);
        _currentDestination.y = transform.position.y;
        return true;
    }
}
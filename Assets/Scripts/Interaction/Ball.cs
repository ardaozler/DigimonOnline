using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ball : BallInteractable
{
    [Header("Movement Settings")] public float speed = 5f;

    [Header("Falling Settings")] public float gravity = 9.8f;
    public float maxFallSpeed = 20f;

    [Header("References")] public Tilemap tilemap;

    private bool _isFalling = false;
    private Vector3 _targetPosition;
    private float _verticalVelocity = 0f;

    private void Start()
    {
        _targetPosition = transform.position;

        var drag = GetComponent<DragAndDrop>();
        drag.OnDragEnd += () => { _targetPosition = transform.position; };
    }

    private void Update()
    {
        HandleFalling();

        if (Vector3.Distance(transform.position, _targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, speed * Time.deltaTime);
            if (_isFalling)
            {
                _targetPosition += Vector3.down * (_verticalVelocity * Time.deltaTime);
            }
        }
    }

    private void HandleFalling()
    {
        Vector3Int cellBelow = tilemap.WorldToCell(transform.position + Vector3.down * 0.1f);

        if (!tilemap.HasTile(cellBelow))
        {
            _isFalling = true;

            _verticalVelocity += gravity * Time.deltaTime;
            _verticalVelocity = Mathf.Clamp(_verticalVelocity, 0, maxFallSpeed);

            if (transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            _isFalling = false;
            _verticalVelocity = 0f;
        }
    }

    public bool MoveTo(Vector3 position)
    {
        if (_isFalling) return false;
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned.");
            return false;
        }

        Vector3Int targetCell = tilemap.WorldToCell(position);
        _targetPosition = tilemap.GetCellCenterWorld(targetCell);
        _targetPosition.y = transform.position.y;

        return true;
    }

    private void OnDrawGizmos()
    {
        if (tilemap != null)
        {
            Gizmos.color = Color.green;
            Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
            Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPosition);
            Gizmos.DrawWireCube(cellCenter, new Vector3(1, 1, 0));

            Gizmos.color = Color.red;
            Vector3Int targetCell = tilemap.WorldToCell(_targetPosition);
            Vector3 targetCellCenter = tilemap.GetCellCenterWorld(targetCell);
            Gizmos.DrawWireCube(targetCellCenter, new Vector3(1, 1, 0));
        }
    }
}
using System;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _offset;
    public static readonly float FixedY = 1.226f;
    private Vector3 _originalScale;
    private bool _forceDrag = false;
    public Action OnDragEnd;

    private void OnMouseDown()
    {
        StartDrag();
    }

    public void StartDragExternally()
    {
        _forceDrag = true;
        StartDrag();
    }

    private void StartDrag()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(transform.position).z)
        );
        _offset = transform.position - mouseWorldPoint;
        _originalScale = transform.localScale;
        transform.localScale = _originalScale * 1.2f;
    }

    private void OnMouseUp()
    {
        transform.localScale = _originalScale;
        _forceDrag = false;
        OnDragEnd?.Invoke();
    }

    private void OnMouseDrag()
    {
        if (_forceDrag || !Input.GetMouseButton(0))
            return;
        Move();
    }

    private void Update()
    {
        if (_forceDrag)
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                Move();
            }

            if (Input.touchCount == 0 && !Input.GetMouseButton(0))
            {
                //force on mouse up
                OnMouseUp();
                transform.localScale = _originalScale;
                _forceDrag = false;
            }
        }
    }


    private void Move()
    {
        Move(Input.mousePosition);
    }

    private void Move(Vector3 screenPosition)
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(screenPosition.x, screenPosition.y, Camera.main.WorldToScreenPoint(transform.position).z)
        );

        Vector3 targetPosition = mouseWorldPoint + _offset;
        targetPosition.y = FixedY;

        transform.position = targetPosition;
    }
}
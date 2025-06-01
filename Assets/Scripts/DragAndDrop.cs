using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _offset;
    private float _fixedY;
    private Vector3 _originalScale;

    private void OnMouseDown()
    {
        _fixedY = transform.position.y;

        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z)
        );

        _offset = transform.position - mouseWorldPoint;
        _originalScale = transform.localScale;
        transform.localScale = _originalScale * 1.2f;

    }

    
    private void OnMouseUp()
    {
        transform.localScale = _originalScale;
    }
    private void OnMouseDrag()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z)
        );

        Vector3 targetPosition = mouseWorldPoint + _offset;
        targetPosition.y = _fixedY;

        transform.position = targetPosition;
    }
}
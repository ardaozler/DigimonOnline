using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ButtonOnMouseDrag : MonoBehaviour,IBeginDragHandler
{
    [FormerlySerializedAs("OnMouseDragEvent")] public UnityEvent onMouseDragEvent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        onMouseDragEvent?.Invoke();
    }
}
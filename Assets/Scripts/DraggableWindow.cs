using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform window;   // The whole window to move

    private Vector2 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Calculate offset between mouse and window position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            window,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPointerPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            window.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPointerPosition))
        {
            window.localPosition = localPointerPosition - offset;
        }
    }
}
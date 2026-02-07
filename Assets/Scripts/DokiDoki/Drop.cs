
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject draggableItem = eventData.pointerDrag;
            Draggable draggable = draggableItem.GetComponent<Draggable>();
            draggable.parentAfterDrag = transform;  
        }
        else
        {
            GameObject draggableItem = eventData.pointerDrag;
            Draggable draggable = draggableItem.GetComponent<Draggable>();

            GameObject currentItem = transform.GetChild(0).gameObject;
            Draggable newDraggable = currentItem.GetComponent<Draggable>();

            newDraggable.transform.SetParent(draggable.parentAfterDrag);
            draggable.parentAfterDrag = transform;
        }

    }
}

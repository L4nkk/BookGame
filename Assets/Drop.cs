
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
            GameObject draggableItem = eventData.pointerDrag;
            Draggable draggable = draggableItem.GetComponent<Draggable>();
            draggable.parentAfterDrag = transform;  
    }
}

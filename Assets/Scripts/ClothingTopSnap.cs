using UnityEngine;
using UnityEngine.EventSystems;

public class ClothingTopSnap : MonoBehaviour, IDropHandler
{
    [Header("Slot Settings")]
    [SerializeField] private ClothingItem.Type acceptedType;
    [SerializeField] private Vector2 slotOffset = Vector2.zero;

    // The item in the slot
    private GameObject currentItem;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop on " + gameObject.name);

        if (eventData.pointerDrag == null)
            return;

        GameObject droppedObj = eventData.pointerDrag;
        DragAndDrop dragAndDrop = droppedObj.GetComponent<DragAndDrop>();

        if (dragAndDrop == null)
            return;

        if (dragAndDrop.ClothingData == null)
            return;

        // only accepts the right clothing type
        if (dragAndDrop.ClothingData.ClothingType != acceptedType)
        {
            Debug.Log("Wrong clothing type for this slot");
            return;
        }

        // sends back to inventory if another item is already in the slot
        if (currentItem != null && currentItem != droppedObj)
        {
            DragAndDrop oldItem = currentItem.GetComponent<DragAndDrop>();
            if (oldItem != null)
            {
                oldItem.ReturnToInventory();
            }
        }

        // make the dropped item a child of the slot
        droppedObj.transform.SetParent(transform);

        // snaps item to the center of the slot xD
        RectTransform droppedRect = droppedObj.GetComponent<RectTransform>();
        droppedRect.anchoredPosition = slotOffset;
        //droppedRect.anchoredPosition = Vector2.zero;

        CanvasGroup canvasGroup = droppedObj.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }

        // stores the item as the current slot 
        currentItem = droppedObj;

        // tells the dragged object that the drop was valid
        dragAndDrop.SetDropped(true);
        dragAndDrop.SetCurrentSlot(this);
    }

    // clears the item ref when it leaves the slot
    public void ClearSlot()
    {
        currentItem = null;
    }
}


using UnityEngine;
using UnityEngine.EventSystems;

public class SellBin : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        GameObject droppedObj = eventData.pointerDrag;
        DragAndDrop dragAndDrop = droppedObj.GetComponent<DragAndDrop>();

        if (dragAndDrop == null) return;

        // Refund the item price
        if (dragAndDrop.ClothingData != null)

        GameManager.instance.RemoveClothing(dragAndDrop.ClothingData.Price, dragAndDrop.ClothingData.stylePts);

        // Clear the snap slot so no clothing appears on it
       ClothingTopSnap snapSlot = droppedObj.GetComponentInParent<ClothingTopSnap>();
        snapSlot?.ClearSlot();

        dragAndDrop.ReturnToInventory();
    }
}

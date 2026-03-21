using UnityEngine;
using UnityEngine.EventSystems;

public class ClothingTopSnap : MonoBehaviour, IDropHandler
{
    // The item currently occupying this slot
    private GameObject currentItem;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
       if ( eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

    }

    //Clears the currentItem
    public void ClearSlot()
    {
        currentItem = null;
    }
}

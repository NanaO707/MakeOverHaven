using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private ScrollRect scrollRect;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Clothing Data")]
    public ClothingItem ClothingData;

    // keeps track of the location so that we can return if need be
    private Transform originalParent;
    private Vector2 originalAnchoredPosition;

    // tracks if the current drag ended on a proper target
    private bool wasDropped;

    //tracks which slot this item is currently in
    private ClothingTopSnap currentSlot;

    private void Awake()
    {
        // gets ui components
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        //adds a canvas group if none exist
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    private void Start()
    {
        //saves original inventory location to reset
        originalParent = transform.parent;
        originalAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        wasDropped = false;

        //clears the slot first if item was already in a slot
        if (currentSlot != null)
        {
            currentSlot.ClearSlot();
            currentSlot = null;
        }

        //stop the scroll view from fighting the drag
        if (scrollRect != null)
        {
            scrollRect.enabled = false;
        }

      
        //move item to canvas while dragging so it appears on top
        transform.SetParent(canvas.transform);
       
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        // make the item follow the mouse
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        //reset image and raycasts
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        //scrollview on after dragging is done
        if (scrollRect != null)
        {
            scrollRect.enabled = true;
        }
        GameManager.instance.AddClothing(ClothingData.Price, ClothingData.stylePts);
        // it'll return to inventory if not dropped on a proper area 
        if (!wasDropped)
        {
            ReturnToInventory();
            GameManager.instance.RemoveClothing(ClothingData.Price, ClothingData.stylePts);
        }
    }

    public void ReturnToInventory()
    {
        //sends item back to inventory parent 
        transform.SetParent(originalParent);
        rectTransform.anchoredPosition = originalAnchoredPosition; //back to inventory original pos
        currentSlot = null;

        //raycasts back on so items can be dragged after once again
        canvasGroup.blocksRaycasts = true;

    }

    //remove style points and cost from game instance 
    public static void RefundDrop(DragAndDrop script)
    {
        GameManager.instance.RemoveClothing(script.ClothingData.Price, script.ClothingData.stylePts);

    }
    public void SetDropped(bool value)
    {
        wasDropped = value; //confirms drop works
    }

    public void SetCurrentSlot(ClothingTopSnap slot)
    {
        currentSlot = slot; //store item slot 
    }
}


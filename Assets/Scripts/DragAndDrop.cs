using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Clothing Data")]
    public ClothingItem ClothingData;

    //Keeps track of its location so that we can return it if needed
    private Transform originalParent;
    private Vector2 originalAnchoredPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
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
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //drag event 
        Debug.Log("OnDrag");
        //calculates movement and takes into account rect transform scale of canvas so it follows the mouse properly
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If not dropped on a valid target it will snap back to inventory
        if (eventData.pointerEnter == null ||
            (eventData.pointerEnter.GetComponent<ClothingTopSnap>() == null &&
             eventData.pointerEnter.GetComponent<SellBin>() == null))
        {
            ReturnToInventory();
        }
    }

    public void ReturnToInventory()
    {
        transform.SetParent(originalParent);
        rectTransform.anchoredPosition = originalAnchoredPosition;
    }
    public void OnDrop(PointerEventData eventData)
    {
        
    }
}

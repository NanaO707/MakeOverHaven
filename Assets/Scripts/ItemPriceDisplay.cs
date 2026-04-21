using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // ref to the Clothing data
    [SerializeField] private DragAndDrop dragAndDrop;

    // ref to the price text 
    [SerializeField] private TextMeshProUGUI priceText;

    // Start is called when the object is first created
    void Start()
    {
       // updates price 
        UpdatePrice();
    }

    // runs in the editor and price update without pressing play
    void OnValidate()
    {
        UpdatePrice();
    }

    // sets the correct price text
    private void UpdatePrice()
    {
        // makes sure references exist
        // if something is missing it stops to avoid errors
        if (dragAndDrop == null || priceText == null)
            return;

        // make sure the clothing data is actually assigned
        if (dragAndDrop.ClothingData == null)
            return;

        // gets the price from the Clothing scriptable object
        priceText.text = "$" + dragAndDrop.ClothingData.Price.ToString();
    }

}

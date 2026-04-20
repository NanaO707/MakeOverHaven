using TMPro;
using UnityEngine;

public class BudgetText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CurrencySystem.Instance != null)
        {
            CurrencySystem.Instance.SetText(GetComponent<TextMeshProUGUI>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

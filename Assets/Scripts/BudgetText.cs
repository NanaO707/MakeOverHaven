using TMPro;
using UnityEngine;

public class BudgetText : MonoBehaviour
{
    // To reupdate the budget upon changing levels since the budget text becomes null otherwise
    void Start()
    {
        if (CurrencySystem.Instance != null)
        {
            CurrencySystem.Instance.SetText(GetComponent<TextMeshProUGUI>());
        }

    }
}

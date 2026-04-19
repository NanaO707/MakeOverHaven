using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem Instance {  get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI budgetText;
    [SerializeField] private Image budgetBackground;

    [Header("Colors")]
    [SerializeField] private Color positiveColor = new Color(0.18f, 0.72f, 0.28f);
    [SerializeField] private Color negativeColor = new Color(0.85f, 0.18f, 0.18f);

    //Current budget for the level -- This can be updated from the Players Data
    private int currentBudget;
    public int CurrentBudget => currentBudget;

    private void Awake()
    {
        if(Instance == null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void HandleStatsChanged(int cost, int stylePoints)
    {
        RefreshUI();
    }

    void Start()
    {
        currentBudget = PlayerData.Instance != null ? PlayerData.Instance.Budget : 0;
        GameManager.instance.OnStatsChanged += HandleStatsChanged;

        RefreshUI();
    }

    //Refunds item cost if needed
    public void Spend(int amount)
    {
        currentBudget -= amount;
        PlayerData.Instance?.SetBudget(currentBudget);
        RefreshUI();
    }
    public void Refund(int amount)
    {
        currentBudget += amount;
        PlayerData.Instance?.SetBudget(currentBudget);
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (budgetText != null)
            budgetText.text = "$" + currentBudget.ToString();

        bool isPositive = currentBudget >= 0;

        if (budgetText != null)
            budgetText.color = isPositive ? positiveColor : negativeColor;
    }

}

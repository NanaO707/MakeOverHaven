using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] AudioClip clothingWoosh;
    [SerializeField] AudioClip spendMoney;
    AudioSource audioSource;

    public static GameManager instance; //to access anywhere

    public int CurrentCost { get; private set; }
    public int CurrentStylePoints{ get; private set; }

    public System.Action<int, int> OnStatsChanged; //action delegate for observer pattern

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsOverBudget()
    {
        return CurrencySystem.Instance.CurrentBudget < 0; //we dont continue past the level otherwise
    }
    void Notify()
    {
        OnStatsChanged?.Invoke(CurrentCost, CurrentStylePoints);
    }
    public void AddClothing(int cost, int stylePoints)
    {
        CurrentCost += cost;
        CurrentStylePoints += stylePoints;

        CurrencySystem.Instance.Spend(cost);
        Notify();
        audioSource.PlayOneShot(clothingWoosh);
    }
    public void RemoveClothing(int cost, int stylePoints)
    {
        CurrentCost -= cost;
        CurrentStylePoints -= stylePoints;

        CurrencySystem.Instance.Refund(cost);
        Notify();
        audioSource.PlayOneShot(spendMoney);

    }
}

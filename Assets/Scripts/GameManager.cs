using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Client client;
    [SerializeField] public Client client2;
    [SerializeField] public Client client3;
    [SerializeField] AudioClip clothingWoosh;
    [SerializeField] AudioClip spendMoney;
    AudioSource audioSource;

    public static GameManager instance; //to access anywhere

    public int CurrentCost { get; private set; }
    public int CurrentStylePoints{ get; private set; }

    public System.Action<int, int> OnStatsChanged; //action delegate for observer pattern

    private void Awake()
    {
        //make sure that we dont have copies of this we can only have one game manager at once
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerData.Instance.ResetAll();
        PlayerData.Instance.InitializeBudget(client.Budget);
    }
    public void NewLevel(int level)
    {
        //reset values 
        CurrentCost = 0;
        CurrentStylePoints = 0;
        //change client
        if (level == 2)
        {
            client = client2;
        }
        else if (level == 3)
        {
            client = client3;
        }
        //update the budget
        PlayerData.Instance.SetBudget(client.Budget);
        CurrencySystem.Instance.SetBudget(client.Budget);
    }

    public bool IsOverBudget()
    {
        return CurrencySystem.Instance.CurrentBudget < 0; //we dont continue past the level otherwise
    }
    void Notify()
    {
        //detects when the cost and style points have changed (action delegate) and calls the listeners attached to cost and style
        OnStatsChanged?.Invoke(CurrentCost, CurrentStylePoints);
    }
    public void AddClothing(int cost, int stylePoints)
    {
        //increase the cost and style accordingly
        CurrentCost += cost;
        CurrentStylePoints += stylePoints;

        //spend from your budget
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
    
    public void DestroyGameManager() //how to destroy this object for a clean slate
        //it usually doesnt get destroyed cause its attached to the player data
    {
        PlayerData.Instance.ResetAll();
        Destroy(gameObject);
    }
}

using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance {  get; private set; }

    //Total budget left after purchases
    public int Budget {  get; private set; }

    //for the review at the end of the level
    public float TotalScore { get; private set; }

    //list of reviews to display.
    public System.Collections.Generic.List<string> Reviews { get; private set; }
       = new System.Collections.Generic.List<string>();
    
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
       // DontDestroyOnLoad(gameObject);
    }

    //Public Setters
    public void InitializeBudget(int startBudget) { Budget = startBudget; }

    public void SetBudget(int newBudget) { Budget = newBudget; }

    public void AddScore(float stars) {  TotalScore += stars; }

    public void AddReview(string review) { Reviews.Add(review); }

    public void ResetAll()
    {
        Budget = 0;
        TotalScore = 0f;
        Reviews.Clear();
    }
}

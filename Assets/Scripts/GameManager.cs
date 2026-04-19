using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //to access anywhere

    public int CurrentCost { get; private set; }
    public int CurrentStylePoints{ get; private set; }

    public System.Action<int, int> OnStatsChanged; //action delegate for observer pattern

    private void Awake()
    {
        instance = this; //check later 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

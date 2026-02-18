using UnityEngine;

[CreateAssetMenu]
public class Client : ScriptableObject
{
    public string[] StylePreference;

    //cool is alt
    //public enum Style { Cute, Cool, Athletic, Goth, Academia, Elegant };
    
    public int StylePointsGoal;

    public int Budget;

    public Sprite Icon;

    public string BadReview = "...";
    public string GoodReview = "...";
}

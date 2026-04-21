using UnityEngine;

[CreateAssetMenu]
public class ClothingItem : ScriptableObject
{
    public string ClothingName;
    public enum Type { Top, Bottom, Headwear, Footwear };
    
    public Type ClothingType;

    public int stylePts;

    public int Price;

    public Sprite Icon;

}

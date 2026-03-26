using UnityEngine;

[CreateAssetMenu]
public class ClothingItem : ScriptableObject
{
    public string ClothingName;

    //cool is alt
    //public enum Style { Cute, Cool, Athletic, Goth, Academia, Elegant};
    public enum Type { Top, Bottom, Headwear, Footwear };
    public enum Style { Sweater, Shirt, Blouse, Skirt, Pants, Dress};
    public enum Color { Pink, Brown, Blue, Black, White, Purple};

    public int stylePts;

    public int Price;

    public Sprite Icon;

}

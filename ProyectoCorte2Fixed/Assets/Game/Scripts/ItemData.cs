using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{

    public string itemName;
    public ItemType itemType;
    public int itemValue;

}

public enum ItemType
{
    Apple,
    Orange,
    kiwi,
    Bananas,
    Coin,
    Weapon,
    Armor
}
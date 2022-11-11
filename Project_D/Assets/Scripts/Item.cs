using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType{
        HealthPotion,
        ManaPotion,
        Sword
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite(){
        switch (itemType)
        {
            
            default:
            case ItemType.HealthPotion: return ItemAsset.Instance.healthPotionSprite;
            case ItemType.ManaPotion:   return ItemAsset.Instance.manaPotionSprite;
        }
    }
}

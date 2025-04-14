using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite=null;

    public Item(string itemName, string itemDescription, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemSprite = itemSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public static BagController instance;
    public List<BagItem> Items = new List<BagItem>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 保留在场景切换之后
        }
        else
        {
            Destroy(gameObject); // 防止重复
        }
    }

    public void AddItem(Item newitem)
    {
        BagItem newBagItem = new BagItem();
        newBagItem.item = newitem;
        Items.Add(newBagItem);
        Debug.Log("AddItem: " + newBagItem.item.itemName);
    }
}

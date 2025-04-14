using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractableWindow : MonoBehaviour,IInteractable
{
    public GameObject UItext;
    public bool canGo = true;
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public int itemWeight;
    public void Interact()
    {
        Debug.Log(PlayerController.Instance.HP1);
        Item item = new Item(itemName, itemDescription, itemSprite);
        BagController.instance.AddItem(item);
        PlayerController.Instance.Weight += itemWeight;
        Debug.Log("WindowInteract");
        BuffPerFloor.instance.actions?.Invoke(0f,0f);
        UItext.SetActive(true);
    }

    public void UIShowInteract()
    {
        Debug.Log("Window出现了");
    }

    public void UIHideInteract()
    {
        Debug.Log("Window消失了");
    }

    public bool CanGo()
    {
        return canGo;
    }
}

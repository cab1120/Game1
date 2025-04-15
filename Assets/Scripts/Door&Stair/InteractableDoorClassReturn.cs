using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorClassReturn : MonoBehaviour,IInteractable
{
    public static InteractableDoorClassReturn instance;
    [SerializeField] GameObject Player;
    private bool canGo = true;

    public void Awake()
    {
        instance = this;
    }

    public void Interact()
    {
        Player.transform.position = new Vector3(11.4f, 2.87f, 0f);
        PlayerController.Instance.CanUp = true;
        CameraController.instance.number = 0;
    }

    public void UIShowInteract()
    {
        Debug.Log("Door出现了");
    }

    public void UIHideInteract()
    {
        Debug.Log("Door消失了");
    }

    public bool CanGo()
    {
        return canGo;
    }
}

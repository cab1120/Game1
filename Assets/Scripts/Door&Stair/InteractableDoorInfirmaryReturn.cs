using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorInfirmaryReturn : MonoBehaviour,IInteractable
{
    public static InteractableDoorInfirmaryReturn instance;
    [SerializeField] GameObject Player;
    public bool canGo = true;

    public void Awake()
    {
        instance = this;
    }

    public void Interact()
    {
        Player.transform.position = new Vector3(46.85f, 2.13f, 0f);
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

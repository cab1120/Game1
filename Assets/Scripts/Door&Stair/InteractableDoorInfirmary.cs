using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorInfirmary : MonoBehaviour,IInteractable
{
    public static InteractableDoorInfirmary instance;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    public bool canGo = true;

    public void Awake()
    {
        instance = this;
    }

    public void Interact()
    {
        Player.transform.position = new Vector3(8.73f, -17.24f, 0f);
        CameraController.instance.number = 1;
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

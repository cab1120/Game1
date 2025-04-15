using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorInfirmary : MonoBehaviour,IInteractable
{
    public static InteractableDoorInfirmary instance;
    [SerializeField] GameObject Player;
    public bool canGo = true;
    public Sprite DoorSprite;
    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        if (canGo == false)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = DoorSprite;
        }
    }
    public void Interact()
    {
        if (canGo)
        {
            Player.transform.position = new Vector3(8.73f, -32.24f, 0f);
            PlayerController.Instance.CanUp = false;
            CameraController.instance.number = 2;
        }
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
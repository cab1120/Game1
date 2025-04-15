using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorClass : MonoBehaviour,IInteractable
{
    public static InteractableDoorClass instance;
    [SerializeField] GameObject Player;
    public Sprite DoorSprite;
    public bool canGo = true;

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
            Player.transform.position = new Vector3(8.73f, -16.64f, 0f);
            PlayerController.Instance.CanUp = false;
            CameraController.instance.number = 1;
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

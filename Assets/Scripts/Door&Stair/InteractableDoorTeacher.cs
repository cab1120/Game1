using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorTeacher : MonoBehaviour,IInteractable
{
    public static InteractableDoorTeacher instance;
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
            Player.transform.position = new Vector3(8.73f, -17.24f, 0f);
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
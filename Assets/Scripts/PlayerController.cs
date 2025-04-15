using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float movespeed=10f;
    public Vector2 movement;
    [SerializeField] Animator animator;
    [SerializeField] float checkRadius = 0.5f;//检测半径 
    [SerializeField] LayerMask interactableLayer;//检测层级
    private IInteractable _currentInteractable;
    public static float hp1 = 100;
    public static float hp2 = 100;
    public int Weight = 0;
    public bool CanUp = true;
    public float HP1
    {
        get => hp1;
        set
        {
            hp1 = value;
            if (hp1 <= 0)
            {
                Dead();
            }
        }
    }

    public float HP2
    {
        get => hp2;
        set
        {
            hp2 = value;
            if (hp2 <= 0)
            {
                Dead();
            }
        }
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保留在场景切换之后
        }
        else
        {
            Destroy(gameObject); // 防止重复
        }
    }

    public void Update()
    {
        Move();
        DetectClosestInteractable();
        if (_currentInteractable != null && Input.GetKeyDown(KeyCode.F) && _currentInteractable.CanGo())
        {
            _currentInteractable.Interact();
        }
    }

    public void DetectClosestInteractable() 
    {
        Collider2D[] delectiedObjects = Physics2D.OverlapCircleAll(transform.position, checkRadius, interactableLayer);
        
        float minDistance = float.MaxValue;
        IInteractable closestInteractable = null;
        
        foreach(Collider2D obj in delectiedObjects)
        {
            IInteractable interactable = obj.GetComponent<IInteractable>();
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestInteractable = interactable;
            }
        }

        if (_currentInteractable != closestInteractable)
        {
            if (_currentInteractable != null)
                _currentInteractable.UIHideInteract();
            
            _currentInteractable = closestInteractable;
            
            if (_currentInteractable != null)
                _currentInteractable.UIShowInteract();
        }
    }
    void OnDrawGizmosSelected()//显示检测范围
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (CanUp)
        {
            movement = new Vector2(horizontal, vertical);
        }
        else
        {
            movement = new Vector2(horizontal, 0);
        }
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Walk", true);
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            }
            //移动
            transform.Translate(movement * (movespeed * Time.deltaTime));
        }
        
    }

    public void Dead()
    {
        Debug.Log("Dead");
    }
}
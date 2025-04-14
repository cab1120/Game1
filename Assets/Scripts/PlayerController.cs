using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] Rigidbody2D rigidBody;
    public float movespeed=10f;
    [SerializeField] Animator animator;
    [SerializeField] float followspeed;
    [SerializeField] float checkRadius = 0.5f;//检测半径 
    [SerializeField] LayerMask interactableLayer;//检测层级
    private IInteractable _currentInteractable;
    public static float hp1 = 100;
    public static float hp2 = 100;
    public int Weight = 0;

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
        Vector2 movement = new Vector2(horizontal, vertical);
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Walk", true);
            if (movement.x > 0)
            {
                transform.localEulerAngles = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                transform.localEulerAngles = new Vector3(-1, 1, 1);
            }
            //移动
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,movement*movespeed,followspeed);
        }
        
    }

    public void Dead()
    {
        Debug.Log("Dead");
    }
}
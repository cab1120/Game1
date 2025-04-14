using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField] private Transform target;
    [SerializeField] float speed;
    [SerializeField] public int number=0;
    public Vector3[] minvec = new Vector3[4];
    
    
    public Vector3[] maxvec = new Vector3[4];
    
    private void Start()
    {
        instance = this;
        minvec[0] = new Vector3(16.34f, 3.42f, -10f);
        maxvec[0]= new Vector3(91.18f,0.667f, -10f);
        minvec[1] = new Vector3(7.644f,-19.855f, -10f);
        maxvec[1]= new Vector3(26.16f,-10.15f, -10f);
    }

    private void LateUpdate()
    {
        float clampedX = Mathf.Clamp(target.position.x, minvec[number].x, maxvec[number].x);
        float clampedY = Mathf.Clamp(target.position.y, minvec[number].y, maxvec[number].y);
        transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX,clampedY,-10), speed);
    }
}

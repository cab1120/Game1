using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class BuffPerFloor : MonoBehaviour
{
    public static BuffPerFloor instance;
    public Action<float,float> actions;
    Random random = new Random();
    public Sprite[] sprites = new Sprite[10];
    public string[] names = new string[10];
    public string[] descriptions = new string[10];
    public GameObject Buffintroduction;
    public new GameObject camera;

    private void Awake()
    {
        instance = this;
        int Rand2 = random.Next(1, 3);
        Rand2 = 3;
        Debug.Log(Rand2);
        switch (Rand2)
        {
            case 1:
                InteractableDoorClass.instance.canGo = false;
                break;
            case 2:
                InteractableDoorInfirmary.instance.canGo = false;
                break;
            case 3:
                InteractableDoorTeacher.instance.canGo = false;
                break;
        }
    }

    void Start()
    {
        int Rand = random.Next(0, 9);
        Debug.Log(Rand);
        Rand = 4;
        //ui显示
        Buffintroduction.SetActive(true);
        switch (Rand)
        {
            case 0: 
                break;
            case 1:
                actions += (a, b) => Hurt(10f, 0f); 
                break;
            case 2:
                Camerachange(camera.GetComponent<Camera>());
                break;
            case 3: 
                Speed(5f);
                break;
            case 4: 
                actions += (a, b) => Hurt(-10f, 0f);
                break;
            case 5: 
                break;
            case 6: 
                actions += (a, b) => Hurt(0f, 10f);
                break;
            case 7: 
                actions += (a, b) => Hurt(0f, -10f);
                break;
            case 8: 
                Speed(-5f);
                break;
            case 9: 
                break;
        }
    }

    public void Hurt(float damage1, float damage2)
    {
        PlayerController.Instance.HP1  += damage1;
        PlayerController.Instance.HP2  += damage2;
    }

    public void Speed(float upSpeed)
    {
        PlayerController.Instance.movespeed += upSpeed;
    }

    public void Camerachange(Camera camera)
    {
        float changevec = camera.orthographicSize * 0.2f;
        for (int i = 0; i <= 2; i++)
        {
            CameraController.instance.maxvec[i] = new Vector3(CameraController.instance.maxvec[i].x + changevec * 16f/9f, CameraController.instance.maxvec[i].y + changevec*2, CameraController.instance.maxvec[i].z);
            CameraController.instance.minvec[i] = new Vector3(CameraController.instance.minvec[i].x - changevec * 16f/9f, CameraController.instance.minvec[i].y - changevec, CameraController.instance.minvec[i].z);
        }
        
        camera.orthographicSize *= 0.8f;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IIteractableDownstair : MonoBehaviour,IInteractable
{
    private int sceneIndex;
    public bool canGo = true;
    public void Interact()
    {
        Debug.Log("Down");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex-1);
    }

    public void UIShowInteract()
    {
        Debug.Log("Ready to changeDown");
    }

    public void UIHideInteract()
    {
        Debug.Log("Not Ready to changeDown");
    }

    public bool CanGo()
    {
        return canGo;
    }
}

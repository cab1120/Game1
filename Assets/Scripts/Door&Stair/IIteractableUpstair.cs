using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IIteractableUpstair : MonoBehaviour,IInteractable
{
    private int sceneIndex;
    public bool canGo = true;
    public void Interact()
    {
        Debug.Log("UP");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex+1);
    }

    public void UIShowInteract()
    {
        Debug.Log("Ready to changeUP");
    }

    public void UIHideInteract()
    {
        Debug.Log("Not Ready to changeUP");
    }
    public bool CanGo()
    {
        return canGo;
    }
}

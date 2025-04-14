using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject button;

    public void CloseButton()
    {
        button.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInteractable
{
    bool CanGo();
    void Interact();
    void UIShowInteract();
    void UIHideInteract();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void ShowOutline();
    void HideOutline();
    void CheckInteract();
    void Interact();
}

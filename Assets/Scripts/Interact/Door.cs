using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    private Animator AnimComp;

    public override void OnEnter()
    {
        base.OnEnter();
        AnimComp = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        AnimComp.SetTrigger("Open");
    }

    public override void ShowError()
    {
        base.ShowError();
    }
}

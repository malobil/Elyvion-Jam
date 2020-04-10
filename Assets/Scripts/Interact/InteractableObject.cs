using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void Interact()
    {
        
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    public List<Outline> ObjectToOutline;
    public AudioSource AudioComp;
    public AudioClip InteractSound;
    private bool IsOutline = false;

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

    public void CheckInteract()
    {
        if(!GetComponent<ExampleError>())
        {
            Interact();
            //Do something
        }
        else if(GetComponent<ExampleError>() && GetComponent<ExampleError>().CheckErrors())
        {
            Interact();
            // Do something
        }
        else if(GetComponent<ExampleError>() && !GetComponent<ExampleError>().CheckErrors())
        {
            ShowError();
            //Error message
        }
    }

    public virtual void Interact()
    {
        if(AudioComp != null)
        AudioComp.PlayOneShot(InteractSound);
    }

    public virtual void ShowError()
    {
        UIManager.Singleton.ShowErrorText(GetComponent<ExampleError>().LastError);
    }

    public virtual void ShowOutline()
    {
        if(!IsOutline)
        {
            foreach(Outline obj in ObjectToOutline)
            {
                IsOutline = true;
                obj.enabled = true ;
            }
        }
    }

    public virtual void HideOutline()
    {
        if (IsOutline)
        {
            foreach (Outline obj in ObjectToOutline)
            {
                obj.enabled = false;
                IsOutline = false;
            }
        }
    }

    public virtual void OnEnter()
    {
        AudioComp = GetComponent<AudioSource>();
    }

    public virtual void OnUpdate()
    {

    }

}

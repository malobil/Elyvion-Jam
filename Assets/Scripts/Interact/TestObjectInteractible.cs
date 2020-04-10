using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectInteractible : MonoBehaviour, IInteractable
{
    enum MyDirection {Front,Back,Left,Right}
    
    public void Interact()
    {
        MyDirection PlayerDir = MyDirection.Front ;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 Direction = Player.transform.position - transform.position;
        float DotForward = Vector3.Dot(transform.forward,Direction);
        float DotRight = Vector3.Dot(transform.right,Direction);

        if(Mathf.Abs(DotForward) >= Mathf.Abs(DotRight))
        {
            if (DotForward > 0)
            {
                PlayerDir = MyDirection.Front;
                Debug.Log("In front");
            }
            else if (DotForward < 0)
            {
                PlayerDir = MyDirection.Back;
                Debug.Log("In Back");
            }
        }
        else
        {
            if (DotRight > 0)
            {
                PlayerDir = MyDirection.Right;
                Debug.Log("In right");
            }
            else if (DotRight < 0)
            {
                PlayerDir = MyDirection.Left;
                Debug.Log("In left");
            }
        }  
        
        switch(PlayerDir)
        {
            case MyDirection.Front:
                transform.position = Vector3.MoveTowards(transform.position, transform.position -transform.forward,1f);
                break;
            case MyDirection.Back:
                transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 1f);
                break;
            case MyDirection.Right:
                transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.right, 1f);
                break;
            case MyDirection.Left:
                transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, 1f);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectInteractible : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 PlayerPosition = Player.transform.position;
        float Dot = Vector3.Angle(transform.position, PlayerPosition);
        Debug.Log(Dot);
        
        
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

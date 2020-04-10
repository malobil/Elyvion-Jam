using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectInteractible : MonoBehaviour, IInteractable
{
    [SerializeField] private float m_MovingRange = 2f;
    enum MyDirection {Front,Back,Left,Right}
    Rigidbody RBComp;

    bool IsPush = false;
    Vector3 PushDirection;
    Vector3 BasePushPosition;
    
    public void Interact()
    {
        if(!IsPush)
        {
            switch (GetPushDirection())
            {
                case MyDirection.Front:
                    PushDirection = -transform.forward;
                    break;
                case MyDirection.Back:
                    PushDirection = transform.forward;
                    break;
                case MyDirection.Right:
                    PushDirection = -transform.right;
                    break;
                case MyDirection.Left:
                    PushDirection = transform.right;
                    break;
            }
        }

        if(CheckIfCanPush())
        {
            BasePushPosition = transform.position;
            IsPush = true;
        }
    }

    bool CheckIfCanPush()
    {
        RaycastHit hit;

        if (!Physics.Raycast(transform.position, PushDirection, out hit, m_MovingRange))
        {
            return true;
        }

        return false;
    }


    MyDirection GetPushDirection()
    {
        MyDirection PlayerDir = MyDirection.Front;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 Direction = Player.transform.position - transform.position;

        float DotForward = Vector3.Dot(transform.forward, Direction);
        float DotRight = Vector3.Dot(transform.right, Direction);

        if (Mathf.Abs(DotForward) >= Mathf.Abs(DotRight))
        {
            if (DotForward > 0)
            {
                PlayerDir = MyDirection.Front;
            }
            else if (DotForward < 0)
            {
                PlayerDir = MyDirection.Back;
            }
        }
        else
        {
            if (DotRight > 0)
            {
                PlayerDir = MyDirection.Right;
            }
            else if (DotRight < 0)
            {
                PlayerDir = MyDirection.Left;
            }
        }

        return PlayerDir;
    }

    void Push(Vector3 PushDirection)
    {
        transform.position = Vector3.MoveTowards(transform.position, (BasePushPosition + (PushDirection* m_MovingRange)),1f *Time.deltaTime);

        if(transform.position == BasePushPosition + (PushDirection * m_MovingRange))
        {
            IsPush = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RBComp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPush)
        {
            Push(PushDirection);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : InteractableObject
{
    [SerializeField] private float m_MovingRange = 2f;
    [SerializeField] private float m_MovingSpeed = 2f;
    enum MyDirection { Front, Back, Left, Right }
    Rigidbody RBComp;

    bool IsPush = false;
    Vector3 PushDirection;
    Vector3 BasePushPosition;

    public override void Interact()
    {
        if (!IsPush)
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

        if (CheckIfCanPush())
        {
            BasePushPosition = transform.position;
            IsPush = true;
        }
    }

    bool CheckIfCanPush()
    {
        RaycastHit hit;
        Vector3 colliderSize = GetComponentInChildren<Collider>().bounds.size/2 ;
        Vector3 colliderCenter = GetComponentInChildren<Collider>().bounds.center + (Vector3.up*0.5f);
        bool m_HitDetect = Physics.BoxCast(colliderCenter, colliderSize, PushDirection, out hit, Quaternion.identity, m_MovingRange);
        
        if(m_HitDetect)
        {
            Debug.Log(hit.collider.gameObject);
        }
      
        return !m_HitDetect;
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
        transform.position = Vector3.MoveTowards(transform.position, (BasePushPosition + (PushDirection * m_MovingRange)), m_MovingSpeed * Time.deltaTime);

        if (transform.position == BasePushPosition + (PushDirection * m_MovingRange))
        {
            IsPush = false;
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
        RBComp = GetComponent<Rigidbody>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (IsPush)
        {
            Push(PushDirection);
        }
    }
}

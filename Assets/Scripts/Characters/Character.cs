using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Movements stats")]
    [SerializeField] private float MoveSpeed = 5f;

    [Header("Interaction stats")]
    [SerializeField] private float InteractRange = 10f;

    [Header("Camera")]
    [SerializeField] private Transform CharacterCamera;
    [SerializeField] private float CameraSensitivity = 0.5f;
    private float xCameraRotation;

    //Controls
    private CharacterControls ActionControls;
    private Vector2 MovementInputs;

    //Components
    private Rigidbody RbComponent;

    //Interaction
    private IInteractable LastInteractivedObjectTarget;

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

    public virtual void OnEnter()
    {
        ActionControls = new CharacterControls();
        ActionControls.Classic_Control.Interact.performed += ctx => Interact();
        ActionControls.Enable();
        RbComponent = GetComponent<Rigidbody>();
        UIManager.Singleton.HideCursor();
    }

    public virtual void OnUpdate()
    {
        Move();
        CameraControl();
        CheckInteract();
    }

    public virtual void Move()
    {
        MovementInputs = ActionControls.Classic_Control.Movement.ReadValue<Vector2>();
        Vector3 Movement = (transform.forward.normalized * MovementInputs.y * MoveSpeed) + (transform.right * MovementInputs.x * MoveSpeed);
        Movement.y = RbComponent.velocity.y;
        RbComponent.velocity = Movement;
    }

    public virtual void CameraControl()
    {
        float mouseX = ActionControls.Classic_Control.MousePosition.ReadValue<Vector2>().x * CameraSensitivity * Time.deltaTime;
        float mouseY = ActionControls.Classic_Control.MousePosition.ReadValue<Vector2>().y * CameraSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        xCameraRotation -= mouseY;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        CharacterCamera.localRotation = Quaternion.Euler(xCameraRotation, CharacterCamera.localRotation.y, CharacterCamera.localRotation.z);
    }

    public virtual void CheckInteract()
    {
        RaycastHit hit ;
        bool Ray = Physics.Raycast(CharacterCamera.transform.position, CharacterCamera.transform.forward, out hit, InteractRange);

        if (Ray)
        {
            if (hit.collider.gameObject.GetComponentInParent<IInteractable>() != null)
            {
                LastInteractivedObjectTarget = hit.collider.gameObject.GetComponentInParent<IInteractable>();
                LastInteractivedObjectTarget.ShowOutline();
            }
            else
            {
                if(LastInteractivedObjectTarget != null)
                {
                    LastInteractivedObjectTarget.HideOutline();
                    LastInteractivedObjectTarget = null;
                }
            }
        }
        else if(!Ray && LastInteractivedObjectTarget != null)
        {
            LastInteractivedObjectTarget.HideOutline();
            LastInteractivedObjectTarget = null;
        }
    }


    public virtual void Interact()
    {
        if(LastInteractivedObjectTarget != null)
        {
            LastInteractivedObjectTarget.CheckInteract();
        }
    }
}
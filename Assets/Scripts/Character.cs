using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Movements stats")]
    [SerializeField] private float MoveSpeed = 5f;

    [Header("Camera")]
    [SerializeField] private Transform CharacterCamera;
    [SerializeField] private float CameraSensitivity = 0.5f;
    private float xCameraRotation;

    //Controls
    private CharacterControls ActionControls;
    private Vector2 MovementInputs;

    //Components
    private Rigidbody RbComponent;

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
        ActionControls.Enable();
        RbComponent = GetComponent<Rigidbody>();
    }

    public virtual void OnUpdate()
    {
        Move();
        CameraControl();
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
}

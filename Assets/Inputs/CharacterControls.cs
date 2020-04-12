// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/CharacterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControls"",
    ""maps"": [
        {
            ""name"": ""Classic_Control"",
            ""id"": ""a063b431-610a-407c-9ce3-f143d90897b8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f12df8f1-1d41-444e-bed4-e204cc71bd27"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""de62562a-d1ac-424b-a846-300317530df9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e2108934-d331-4746-ab3a-47f43f1cd2e2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""45570015-36aa-412d-b6ad-ec06bb6e78d9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ba51a1c7-583e-4d03-a109-108c838979f3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9f59398b-70d4-43d4-8ccc-7103869ceed6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eddb7c0a-18f3-466c-9ebf-3dbfa462129f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e30d50cf-14a1-4712-8f27-ca4c98d16834"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2e86fd89-ee14-4b02-89f5-d691a06f944c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b49dbed9-4c2b-4886-b158-43cc3d2aa04c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0bee98b-759a-4524-81a2-fbf2fd06e5f5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""004f76ed-9cf0-409a-a4f5-fc22d65a5bbd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Classic_Control
        m_Classic_Control = asset.FindActionMap("Classic_Control", throwIfNotFound: true);
        m_Classic_Control_Movement = m_Classic_Control.FindAction("Movement", throwIfNotFound: true);
        m_Classic_Control_MousePosition = m_Classic_Control.FindAction("MousePosition", throwIfNotFound: true);
        m_Classic_Control_Interact = m_Classic_Control.FindAction("Interact", throwIfNotFound: true);
        m_Classic_Control_Pause = m_Classic_Control.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Classic_Control
    private readonly InputActionMap m_Classic_Control;
    private IClassic_ControlActions m_Classic_ControlActionsCallbackInterface;
    private readonly InputAction m_Classic_Control_Movement;
    private readonly InputAction m_Classic_Control_MousePosition;
    private readonly InputAction m_Classic_Control_Interact;
    private readonly InputAction m_Classic_Control_Pause;
    public struct Classic_ControlActions
    {
        private @CharacterControls m_Wrapper;
        public Classic_ControlActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Classic_Control_Movement;
        public InputAction @MousePosition => m_Wrapper.m_Classic_Control_MousePosition;
        public InputAction @Interact => m_Wrapper.m_Classic_Control_Interact;
        public InputAction @Pause => m_Wrapper.m_Classic_Control_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Classic_Control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Classic_ControlActions set) { return set.Get(); }
        public void SetCallbacks(IClassic_ControlActions instance)
        {
            if (m_Wrapper.m_Classic_ControlActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnMovement;
                @MousePosition.started -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnMousePosition;
                @Interact.started -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_Classic_ControlActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_Classic_ControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public Classic_ControlActions @Classic_Control => new Classic_ControlActions(this);
    public interface IClassic_ControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}

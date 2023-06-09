//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PROJECT/Script/ActionMap/GameInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""CharacterSelection"",
            ""id"": ""7b1de464-319f-4558-9d9a-e0185970a6d6"",
            ""actions"": [
                {
                    ""name"": ""IncreaseCurrentCam"",
                    ""type"": ""Button"",
                    ""id"": ""45064ea3-c5e5-42ee-8ed6-b5c25450ccdd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DecreaseCurrentCam"",
                    ""type"": ""Button"",
                    ""id"": ""c47ae3f7-2619-4d17-abef-e7187730abf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChooseCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""bbf08758-f7fd-4531-8ea8-5e40f8ce66f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1878080a-316f-4e41-9eab-dd5599d55f20"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseCurrentCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3efa055f-9689-4bd5-bf36-6520c6deb2b9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseCurrentCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cb8d361-f88f-4656-b37a-c6f8c108dd47"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActions"",
            ""id"": ""b1127acf-6680-4893-9d59-1c573b09bedc"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""77f8fc6d-736c-42d9-8433-7d02f7cd73d0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Running"",
                    ""type"": ""Button"",
                    ""id"": ""330ed63a-b689-469f-954f-8104ca0924c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f6a2f693-7c38-4d63-b26c-48bb59bb995f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Bark"",
                    ""type"": ""Button"",
                    ""id"": ""075773a4-bff5-42d7-a4c3-fd37dca0d4d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dig"",
                    ""type"": ""Button"",
                    ""id"": ""97252f37-2e9f-4335-a7f6-c48a15a90839"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4953c413-6f1e-44ff-9b08-63f1f0015b73"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82475b02-0ad5-4f80-bef4-aa58464fc66b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cee089cb-dad9-4acc-ae45-0b3c98b2e174"",
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
                    ""id"": ""160a3115-1e4b-4231-9459-fbd6b8416390"",
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
                    ""id"": ""37738024-1572-4eee-8df4-d2659b78fc2f"",
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
                    ""id"": ""832a4d07-9cbd-4c0d-89c2-699d2a1dc4c8"",
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
                    ""id"": ""a81facf3-391c-42c4-bafe-513dddb066ca"",
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
                    ""id"": ""a90aa1c6-38fc-4f67-986a-1f60db44f509"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""297e3334-f02e-4f71-b3f7-37463ce9b624"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterSelection
        m_CharacterSelection = asset.FindActionMap("CharacterSelection", throwIfNotFound: true);
        m_CharacterSelection_IncreaseCurrentCam = m_CharacterSelection.FindAction("IncreaseCurrentCam", throwIfNotFound: true);
        m_CharacterSelection_DecreaseCurrentCam = m_CharacterSelection.FindAction("DecreaseCurrentCam", throwIfNotFound: true);
        m_CharacterSelection_ChooseCharacter = m_CharacterSelection.FindAction("ChooseCharacter", throwIfNotFound: true);
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Movement = m_PlayerActions.FindAction("Movement", throwIfNotFound: true);
        m_PlayerActions_Running = m_PlayerActions.FindAction("Running", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_Bark = m_PlayerActions.FindAction("Bark", throwIfNotFound: true);
        m_PlayerActions_Dig = m_PlayerActions.FindAction("Dig", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CharacterSelection
    private readonly InputActionMap m_CharacterSelection;
    private ICharacterSelectionActions m_CharacterSelectionActionsCallbackInterface;
    private readonly InputAction m_CharacterSelection_IncreaseCurrentCam;
    private readonly InputAction m_CharacterSelection_DecreaseCurrentCam;
    private readonly InputAction m_CharacterSelection_ChooseCharacter;
    public struct CharacterSelectionActions
    {
        private @GameInputActions m_Wrapper;
        public CharacterSelectionActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @IncreaseCurrentCam => m_Wrapper.m_CharacterSelection_IncreaseCurrentCam;
        public InputAction @DecreaseCurrentCam => m_Wrapper.m_CharacterSelection_DecreaseCurrentCam;
        public InputAction @ChooseCharacter => m_Wrapper.m_CharacterSelection_ChooseCharacter;
        public InputActionMap Get() { return m_Wrapper.m_CharacterSelection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterSelectionActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterSelectionActions instance)
        {
            if (m_Wrapper.m_CharacterSelectionActionsCallbackInterface != null)
            {
                @IncreaseCurrentCam.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnIncreaseCurrentCam;
                @IncreaseCurrentCam.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnIncreaseCurrentCam;
                @IncreaseCurrentCam.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnIncreaseCurrentCam;
                @DecreaseCurrentCam.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDecreaseCurrentCam;
                @DecreaseCurrentCam.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDecreaseCurrentCam;
                @DecreaseCurrentCam.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDecreaseCurrentCam;
                @ChooseCharacter.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnChooseCharacter;
                @ChooseCharacter.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnChooseCharacter;
                @ChooseCharacter.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnChooseCharacter;
            }
            m_Wrapper.m_CharacterSelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @IncreaseCurrentCam.started += instance.OnIncreaseCurrentCam;
                @IncreaseCurrentCam.performed += instance.OnIncreaseCurrentCam;
                @IncreaseCurrentCam.canceled += instance.OnIncreaseCurrentCam;
                @DecreaseCurrentCam.started += instance.OnDecreaseCurrentCam;
                @DecreaseCurrentCam.performed += instance.OnDecreaseCurrentCam;
                @DecreaseCurrentCam.canceled += instance.OnDecreaseCurrentCam;
                @ChooseCharacter.started += instance.OnChooseCharacter;
                @ChooseCharacter.performed += instance.OnChooseCharacter;
                @ChooseCharacter.canceled += instance.OnChooseCharacter;
            }
        }
    }
    public CharacterSelectionActions @CharacterSelection => new CharacterSelectionActions(this);

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Movement;
    private readonly InputAction m_PlayerActions_Running;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_Bark;
    private readonly InputAction m_PlayerActions_Dig;
    public struct PlayerActionsActions
    {
        private @GameInputActions m_Wrapper;
        public PlayerActionsActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerActions_Movement;
        public InputAction @Running => m_Wrapper.m_PlayerActions_Running;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @Bark => m_Wrapper.m_PlayerActions_Bark;
        public InputAction @Dig => m_Wrapper.m_PlayerActions_Dig;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMovement;
                @Running.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRunning;
                @Running.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRunning;
                @Running.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRunning;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Bark.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBark;
                @Bark.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBark;
                @Bark.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBark;
                @Dig.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDig;
                @Dig.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDig;
                @Dig.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDig;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Running.started += instance.OnRunning;
                @Running.performed += instance.OnRunning;
                @Running.canceled += instance.OnRunning;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Bark.started += instance.OnBark;
                @Bark.performed += instance.OnBark;
                @Bark.canceled += instance.OnBark;
                @Dig.started += instance.OnDig;
                @Dig.performed += instance.OnDig;
                @Dig.canceled += instance.OnDig;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface ICharacterSelectionActions
    {
        void OnIncreaseCurrentCam(InputAction.CallbackContext context);
        void OnDecreaseCurrentCam(InputAction.CallbackContext context);
        void OnChooseCharacter(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBark(InputAction.CallbackContext context);
        void OnDig(InputAction.CallbackContext context);
    }
}

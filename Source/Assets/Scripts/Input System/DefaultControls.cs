// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input System/DefaultControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefaultControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultControls"",
    ""maps"": [
        {
            ""name"": ""Defaults"",
            ""id"": ""4b1003c9-3fca-433f-9ff2-5dba8c41e91b"",
            ""actions"": [
                {
                    ""name"": ""Mouse Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""a572701a-816b-4b83-9b41-4f4f716eebb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Position"",
                    ""type"": ""Value"",
                    ""id"": ""5cff0851-e421-4c88-b0f2-020fd0ad6184"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Delta"",
                    ""type"": ""Value"",
                    ""id"": ""0a53f749-17bc-49bc-afe0-fa760c9bcb47"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Right Click"",
                    ""type"": ""Button"",
                    ""id"": ""cd7c37fd-e75f-4c96-b163-f445bb63344c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchRight"",
                    ""type"": ""Button"",
                    ""id"": ""c15ce03b-01e4-4e0a-b7bd-e2190831c42b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""Multi"",
                    ""type"": ""Button"",
                    ""id"": ""e0c71166-b7bd-4ed2-b87f-52d556062d27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""TouchRightDelta"",
                    ""type"": ""Value"",
                    ""id"": ""b68f0659-2590-4ca3-985f-a8d58bbfad93"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchRightPos"",
                    ""type"": ""Value"",
                    ""id"": ""3f204224-f6fc-4d2b-bfae-47a36ea06dda"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""120e8d03-59bf-4971-a92d-17c846165938"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pc"",
                    ""action"": ""Mouse Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39a51df3-4312-4774-8202-c0ee832e45f7"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Mouse Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""564b19c9-18be-4890-ab02-4ffdcfea2e49"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pc"",
                    ""action"": ""Mouse Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""640fcd59-3910-4a2f-8e01-7673336fa983"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Mouse Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11e71e1d-fc1c-411a-a9d8-ba3ee1d185b7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pc"",
                    ""action"": ""Mouse Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8120ec59-bc25-48ae-8eb9-069f094e2f9f"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Mouse Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad1eb253-ecb9-400a-81a6-dee42d1a9bfd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pc"",
                    ""action"": ""Mouse Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75f97fd8-0d26-4b6e-a4a4-4cb25bc21538"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Mouse Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53fefbf3-4650-490c-839b-28fc8b9319a5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Multi"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""130f6ed5-cfaa-487a-92d6-99abf59c7c35"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchRightDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9616caa-1bb0-4461-a960-de61ae6378e5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pc"",
                    ""action"": ""TouchRightDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67d68dd8-1f32-46ef-b9a1-4a44e223e425"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchRightPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Pc"",
            ""bindingGroup"": ""Pc"",
            ""devices"": []
        }
    ]
}");
        // Defaults
        m_Defaults = asset.FindActionMap("Defaults", throwIfNotFound: true);
        m_Defaults_MouseLeftClick = m_Defaults.FindAction("Mouse Left Click", throwIfNotFound: true);
        m_Defaults_MousePosition = m_Defaults.FindAction("Mouse Position", throwIfNotFound: true);
        m_Defaults_MouseDelta = m_Defaults.FindAction("Mouse Delta", throwIfNotFound: true);
        m_Defaults_MouseRightClick = m_Defaults.FindAction("Mouse Right Click", throwIfNotFound: true);
        m_Defaults_TouchRight = m_Defaults.FindAction("TouchRight", throwIfNotFound: true);
        m_Defaults_Multi = m_Defaults.FindAction("Multi", throwIfNotFound: true);
        m_Defaults_TouchRightDelta = m_Defaults.FindAction("TouchRightDelta", throwIfNotFound: true);
        m_Defaults_TouchRightPos = m_Defaults.FindAction("TouchRightPos", throwIfNotFound: true);
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

    // Defaults
    private readonly InputActionMap m_Defaults;
    private IDefaultsActions m_DefaultsActionsCallbackInterface;
    private readonly InputAction m_Defaults_MouseLeftClick;
    private readonly InputAction m_Defaults_MousePosition;
    private readonly InputAction m_Defaults_MouseDelta;
    private readonly InputAction m_Defaults_MouseRightClick;
    private readonly InputAction m_Defaults_TouchRight;
    private readonly InputAction m_Defaults_Multi;
    private readonly InputAction m_Defaults_TouchRightDelta;
    private readonly InputAction m_Defaults_TouchRightPos;
    public struct DefaultsActions
    {
        private @DefaultControls m_Wrapper;
        public DefaultsActions(@DefaultControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLeftClick => m_Wrapper.m_Defaults_MouseLeftClick;
        public InputAction @MousePosition => m_Wrapper.m_Defaults_MousePosition;
        public InputAction @MouseDelta => m_Wrapper.m_Defaults_MouseDelta;
        public InputAction @MouseRightClick => m_Wrapper.m_Defaults_MouseRightClick;
        public InputAction @TouchRight => m_Wrapper.m_Defaults_TouchRight;
        public InputAction @Multi => m_Wrapper.m_Defaults_Multi;
        public InputAction @TouchRightDelta => m_Wrapper.m_Defaults_TouchRightDelta;
        public InputAction @TouchRightPos => m_Wrapper.m_Defaults_TouchRightPos;
        public InputActionMap Get() { return m_Wrapper.m_Defaults; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultsActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultsActions instance)
        {
            if (m_Wrapper.m_DefaultsActionsCallbackInterface != null)
            {
                @MouseLeftClick.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseLeftClick;
                @MousePosition.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMousePosition;
                @MouseDelta.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseDelta;
                @MouseRightClick.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMouseRightClick;
                @TouchRight.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRight;
                @TouchRight.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRight;
                @TouchRight.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRight;
                @Multi.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMulti;
                @Multi.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMulti;
                @Multi.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnMulti;
                @TouchRightDelta.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRightDelta;
                @TouchRightDelta.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRightDelta;
                @TouchRightDelta.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRightDelta;
                @TouchRightPos.started -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRightPos;
                @TouchRightPos.performed -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRightPos;
                @TouchRightPos.canceled -= m_Wrapper.m_DefaultsActionsCallbackInterface.OnTouchRightPos;
            }
            m_Wrapper.m_DefaultsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @MouseRightClick.started += instance.OnMouseRightClick;
                @MouseRightClick.performed += instance.OnMouseRightClick;
                @MouseRightClick.canceled += instance.OnMouseRightClick;
                @TouchRight.started += instance.OnTouchRight;
                @TouchRight.performed += instance.OnTouchRight;
                @TouchRight.canceled += instance.OnTouchRight;
                @Multi.started += instance.OnMulti;
                @Multi.performed += instance.OnMulti;
                @Multi.canceled += instance.OnMulti;
                @TouchRightDelta.started += instance.OnTouchRightDelta;
                @TouchRightDelta.performed += instance.OnTouchRightDelta;
                @TouchRightDelta.canceled += instance.OnTouchRightDelta;
                @TouchRightPos.started += instance.OnTouchRightPos;
                @TouchRightPos.performed += instance.OnTouchRightPos;
                @TouchRightPos.canceled += instance.OnTouchRightPos;
            }
        }
    }
    public DefaultsActions @Defaults => new DefaultsActions(this);
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    private int m_PcSchemeIndex = -1;
    public InputControlScheme PcScheme
    {
        get
        {
            if (m_PcSchemeIndex == -1) m_PcSchemeIndex = asset.FindControlSchemeIndex("Pc");
            return asset.controlSchemes[m_PcSchemeIndex];
        }
    }
    public interface IDefaultsActions
    {
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnTouchRight(InputAction.CallbackContext context);
        void OnMulti(InputAction.CallbackContext context);
        void OnTouchRightDelta(InputAction.CallbackContext context);
        void OnTouchRightPos(InputAction.CallbackContext context);
    }
}

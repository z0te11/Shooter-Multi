using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : MonoBehaviour
{
    private InputAction _usePauseAction;
    private InputAction _moveAction;
    private InputAction _mainAbilityAction;
    private InputAction _mainAssistAbilityAction;
    private InputAction _secondAbilityAction;
    private InputAction _firstMessage;
    private InputAction _secondMessage;
    private InputAction _thirdMessage;
    private InputAction _fourthMessage;
    public static Vector2 moveInput;
    public static float mainAbilityInput;
    public static float mainAssistAbilityInput;
    public static float secondAbilityInput;
    public static bool usePauseInput;

    private void OnEnable()
    {
        SetJostickAction();
        SetMainAbilityAction();
        SetSecondAbilityAction();
        SetMainAssistAbilityAction();
        SetPauseButton();
        SetChatButtons();
    }

    private void OnDisable()
    {
        _firstMessage.Disable();
        _secondMessage.Disable();
        _thirdMessage.Disable();
        _fourthMessage.Disable();
        _moveAction.Disable();
        _mainAbilityAction.Disable();
        _secondAbilityAction.Disable();
        _mainAssistAbilityAction.Disable();
        _usePauseAction.Disable();
    }

    private void SetJostickAction()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
        .With("Up", "<Keyboard>/w")
        .With("Down", "<Keyboard>/s")
        .With("Left", "<Keyboard>/a")
        .With("Right", "<Keyboard>/d");

        _moveAction.performed += context => { moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();
    }

    private void SetMainAbilityAction()
    {
        _mainAbilityAction = new InputAction("mainAbility", binding: "<Mouse>/leftButton");

        _mainAbilityAction.performed += context => { mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.started += context => { mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.canceled += context => { mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.Enable();
    }

    private void SetMainAssistAbilityAction()
    {
        _mainAssistAbilityAction = new InputAction("mainAssistAbility", binding: "<Mouse>/rightButton");

        _mainAssistAbilityAction.performed += context => { mainAssistAbilityInput = context.ReadValue<float>(); };
        _mainAssistAbilityAction.started += context => { mainAssistAbilityInput = context.ReadValue<float>(); };
        _mainAssistAbilityAction.canceled += context => { mainAssistAbilityInput = context.ReadValue<float>(); };
        _mainAssistAbilityAction.Enable();
    }

    private void SetSecondAbilityAction()
    {
        _secondAbilityAction = new InputAction("secondAbility", binding: "<Keyboard>/leftShift");

        _secondAbilityAction.performed += context => { secondAbilityInput = context.ReadValue<float>(); };
        _secondAbilityAction.started += context => { secondAbilityInput = context.ReadValue<float>(); };
        _secondAbilityAction.canceled += context => { secondAbilityInput = context.ReadValue<float>(); };
        _secondAbilityAction.Enable();
    }

    private void SetPauseButton()
    {
        _usePauseAction = new InputAction("pauseButton", binding: "<Keyboard>/Escape");
        _usePauseAction.Enable();
    }

    private void SetChatButtons()
    {
        _firstMessage = new InputAction("firstMessage", binding: "<Keyboard>/1");
        _firstMessage.Enable();

        _secondMessage = new InputAction("firstMessage", binding: "<Keyboard>/2");
        _secondMessage.Enable();

        _thirdMessage = new InputAction("firstMessage", binding: "<Keyboard>/3");
        _thirdMessage.Enable();

        _fourthMessage = new InputAction("firstMessage", binding: "<Keyboard>/4");
        _fourthMessage.Enable();
    }

}

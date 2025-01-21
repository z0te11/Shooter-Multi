using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : MonoBehaviour
{
    private InputAction _moveAction;
    private InputAction _mainAbilityAction;
    private InputAction _secondAbilityAction;
    public static Vector2 moveInput;
    public static float mainAbilityInput;
    public static float secondAbilityInput;

    private void OnEnable()
    {
        SetJostickAction();
        SetMainAbilityAction();
        SetSecondAbilityAction();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _mainAbilityAction.Disable();
        _secondAbilityAction.Disable();
    }

    private void SetJostickAction()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
        .With ("Up", "<Keyboard>/w")
        .With ("Down", "<Keyboard>/s")
        .With ("Left", "<Keyboard>/a")
        .With ("Right", "<Keyboard>/d");

        _moveAction.performed += context => {moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => {moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => {moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();
    }

    private void SetMainAbilityAction()
    {
        _mainAbilityAction = new InputAction("mainAbility", binding: "<Keyboard>/Space");

        _mainAbilityAction.performed += context => {mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.started += context => {mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.canceled += context => {mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.Enable();
    }

    private void SetSecondAbilityAction()
    {
        _secondAbilityAction = new InputAction("secondAbility", binding: "<Keyboard>/leftShift");

        _secondAbilityAction.performed += context => {secondAbilityInput = context.ReadValue<float>(); };
        _secondAbilityAction.started += context => {secondAbilityInput = context.ReadValue<float>(); };
        _secondAbilityAction.canceled += context => {secondAbilityInput = context.ReadValue<float>(); };
        _secondAbilityAction.Enable();
    }

}

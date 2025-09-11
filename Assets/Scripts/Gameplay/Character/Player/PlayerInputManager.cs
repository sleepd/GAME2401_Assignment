using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager
{
    private InputSystem_Actions inputActions;

    public event Action OnFireEvent;
    public event Action OnFireCanceledEvent;
    PlayerController character;

    public PlayerInputManager(PlayerController player)
    {
        character = player;
        inputActions = new();
        inputActions.Player.Enable();
        inputActions.Player.Attack.performed += OnFirePressed;
        inputActions.Player.Attack.canceled += OnFireCanceled;

    }

    public Vector2 GetMoveInput()
    {
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        return moveInput;
    }

    void OnFirePressed(InputAction.CallbackContext context)
    {
        OnFireEvent?.Invoke();
    }

    void OnFireCanceled(InputAction.CallbackContext ctx)
    {
        OnFireCanceledEvent?.Invoke();
    }

    public void Clear()
    {
        inputActions.Player.Attack.performed -= OnFirePressed;
        inputActions.Player.Attack.canceled -= OnFireCanceled;
        inputActions.Player.Disable();
        OnFireEvent = null;
        OnFireCanceledEvent = null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FpsControllerInput : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction changeMoveTypeAction;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        changeMoveTypeAction = playerInput.actions["ChangeMoveType"];
    }

    public Vector2 MoveAxis() => moveAction.ReadValue<Vector2>().normalized;
    
    public Vector2 MouseAxis() => lookAction.ReadValue<Vector2>();

    public bool ChangeMovementType() => changeMoveTypeAction.triggered;
}

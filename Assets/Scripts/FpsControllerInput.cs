using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class FpsControllerInput : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction interactAction;
    private InputAction changeMoveTypeAction;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Movement"];
        lookAction = playerInput.actions["Look"];
        interactAction = playerInput.actions["Interact"];
        changeMoveTypeAction = playerInput.actions["ChangeMovementType"];
    }
    
    public Vector2 MoveAxis() => moveAction.ReadValue<Vector2>().normalized;
    
    public Vector2 MouseAxis() => lookAction.ReadValue<Vector2>();

    public bool ChangeMovementType() => changeMoveTypeAction.triggered;

    public bool PlayerInteract() => interactAction.triggered;
}

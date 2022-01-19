using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the input of controls
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class FpsControllerInput : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction interactAction;
    private InputAction changeMoveTypeAction;
    private InputAction selectItem1;
    private InputAction selectItem2;
    private InputAction selectItem3;
    private InputAction selectItem4;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Movement"];
        lookAction = playerInput.actions["Look"];
        interactAction = playerInput.actions["Interact"];
        changeMoveTypeAction = playerInput.actions["ChangeMovementType"];
        selectItem1 = playerInput.actions["SelectItem1"];
        selectItem2 = playerInput.actions["SelectItem2"];
        selectItem3 = playerInput.actions["SelectItem3"];
        selectItem4 = playerInput.actions["SelectItem4"];
    }
    
    public Vector2 MoveAxis() => moveAction.ReadValue<Vector2>().normalized;
    
    public Vector2 MouseAxis() => lookAction.ReadValue<Vector2>();

    public bool ChangeMovementType() => changeMoveTypeAction.triggered;

    public bool PlayerInteract() => interactAction.triggered;

    public bool SelectItem1() => selectItem1.triggered;

    public bool SelectItem2() => selectItem2.triggered;

    public bool SelectItem3() => selectItem3.triggered;

    public bool SelectItem4() => selectItem4.triggered;

    public bool SelectItem() => 
        selectItem1.triggered || selectItem2.triggered || selectItem3.triggered || selectItem4.triggered;
}

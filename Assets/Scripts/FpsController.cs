using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [Header("Camera References")]
    [SerializeField] private Transform headPosition;
    [SerializeField] private Transform cam;

    [Header("Player Move Speed")]
    [SerializeField] private float walkSpeed = 1.5f;
    [SerializeField] private float crawlSpeed = 1f;

    [Header("Mouse settings")]
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private bool invertXAxis = false;

    [Header("Camera Rotation")]
    [SerializeField] private float clampRotation = 80f;

    private FpsAnimationController fpsAnimationController;
    private FpsControllerInput fpsControllerInput;
    private Rigidbody rBody;

    private float mouseX;
    private float currentSpeed;
    private MovementType moveState;

    private void Start()
    {
        fpsAnimationController = GetComponent<FpsAnimationController>();
        fpsControllerInput = GetComponent<FpsControllerInput>();
        rBody = GetComponent<Rigidbody>();

        // Set the initial movement type
        moveState = MovementType.Walk;
    }

    private void Update()
    {
        if (fpsControllerInput.ChangeMovementType())
        {
            moveState = moveState == MovementType.Walk ? 
                MovementType.Crawl : MovementType.Walk;

            fpsAnimationController.UpdateMovementType(moveState);
        }

        // Update the speed based on the current movement type
        currentSpeed = moveState == MovementType.Walk ? walkSpeed : crawlSpeed;

        LookArround();
    }

    private void FixedUpdate()
    {
        if (fpsControllerInput.MoveAxis().magnitude > 0)
        {
            rBody.velocity = ((transform.forward * fpsControllerInput.MoveAxis().y) + 
                (transform.right * fpsControllerInput.MoveAxis().x) * currentSpeed) + 
                (transform.up * rBody.velocity.y);
        }
        else if (rBody.velocity.z != 0 || rBody.velocity.x != 0)
        {
            rBody.velocity = Vector3.up * rBody.velocity.y;
        }

        fpsAnimationController.UpdateMoveAnimation(fpsControllerInput.MoveAxis());
    }

    private void LookArround()
    {
        cam.position = headPosition.position;

        if (invertXAxis)
        {
            mouseX += fpsControllerInput.MouseAxis().y;
            print(mouseX);
        }
        else
        {
            mouseX -= fpsControllerInput.MouseAxis().y;
            print(mouseX);
        }

        cam.localRotation = Quaternion.Euler(
            Mathf.Clamp(mouseX * mouseSensitivity, -clampRotation, clampRotation), 
            0, 
            0);

        transform.Rotate(transform.up, fpsControllerInput.MouseAxis().x * mouseSensitivity);
    }
}

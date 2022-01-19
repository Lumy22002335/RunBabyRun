using UnityEngine;

/// <summary>
/// Responsible for controlling the player movement
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(FpsControllerInput))]
[RequireComponent(typeof(FpsAnimationController))]
public class FpsController : MonoBehaviour
{
    [Header("Camera References")]
    [SerializeField] private Transform headPosition;
    [SerializeField] private Transform cam;

    [Header("Player Climb end point")]
    [SerializeField] private Transform climbTP;

    [Header("Player Move Speed")]
    [SerializeField] private float walkSpeed = 1.5f;
    [SerializeField] private float crawlSpeed = 1f;

    [Header("Mouse settings")]
    [SerializeField] private int clampAngle = 85;
    [SerializeField] private bool lockCursor;
    [SerializeField] private bool invertYAxis = false;

    [SerializeField] private Vector2 sensitivity = new Vector2(2, 2);
    [SerializeField] private Vector2 smoothing = new Vector2(1, 1);
    [SerializeField] private Vector2 targetDirection;
    [SerializeField] private Vector2 targetCharacterDirection;

    [Header("Crawl Collider")]
    [SerializeField] private GameObject crawlCollider;

    private FpsAnimationController fpsAnimationController;
    private FpsControllerInput fpsControllerInput;
    private Rigidbody rBody;

    private float mouseX;
    private float currentSpeed;
    private MovementType moveState;
    public MovementType MoveState => moveState;

    private Vector2 mouseAbsolute;
    private Vector2 smoothMouse;

    /// <summary>
    /// Runs at the start
    /// </summary>
    private void Start()
    {
        fpsAnimationController = GetComponent<FpsAnimationController>();
        fpsControllerInput = GetComponent<FpsControllerInput>();
        rBody = GetComponent<Rigidbody>();

        // Set target direction to the camera's initial orientation.
        targetDirection = cam.transform.localRotation.eulerAngles;
        targetCharacterDirection = transform.localRotation.eulerAngles;

        // Set the initial movement type
        moveState = MovementType.Walk;
    }

    /// <summary>
    /// Runs once per frame
    /// </summary>
    private void Update()
    {
        if (fpsControllerInput.ChangeMovementType())
        {
            moveState = moveState == MovementType.Walk ? 
                MovementType.Crawl : MovementType.Walk;

            crawlCollider.SetActive(moveState == MovementType.Crawl);
            GetComponent<Collider>().enabled = (moveState == MovementType.Walk);

            fpsAnimationController.UpdateMovementType(moveState);
        }

        // Update the speed based on the current movement type
        currentSpeed = moveState == MovementType.Walk ? walkSpeed : crawlSpeed;
    }

    /// <summary>
    /// Runs at the end of every frame
    /// </summary>
    private void LateUpdate()
    {
        LookArround();
    }

    /// <summary>
    /// Runs at every phisics update
    /// </summary>
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

    /// <summary>
    /// Allows the player to look arround with the mouse
    /// </summary>
    private void LookArround()
    {
        // Ensure cam follows head bone position
        cam.position = headPosition.position;

        // Ensure the cursor is always locked when set
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        // Allow the script to clamp based on a desired target value.
        var targetOrientation = Quaternion.Euler(targetDirection);
        var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

        // Get raw mouse input for a cleaner reading on more sensitive mice.
        var mouseDelta = fpsControllerInput.MouseAxis();

        // Scale input against the sensitivity setting and multiply that against the smoothing value.
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        // Interpolate mouse movement over time to apply smoothing delta.
        smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
        smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

        // Find the absolute mouse movement value from point zero.
        mouseAbsolute += smoothMouse;

        // Clamp and apply the global y value.
        mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -clampAngle, clampAngle);

        // Check if we should invert the Y axis
        if (invertYAxis)
        {
            // Apply X rotation to the player
            cam.transform.localRotation = Quaternion.AngleAxis(mouseAbsolute.y, targetOrientation * Vector3.right) * targetOrientation;
        }
        else
        {
            // Apply X rotation to the player
            cam.transform.localRotation = Quaternion.AngleAxis(-mouseAbsolute.y, targetOrientation * Vector3.right) * targetOrientation;
        }
        
        // Apply Y rotation to the player
        var yRotation = Quaternion.AngleAxis(mouseAbsolute.x, Vector3.up);
        transform.localRotation = yRotation * targetCharacterOrientation;
    }

    /// <summary>
    /// Requests the climb animation
    /// </summary>
    public void PlayerClimb()
    {
        fpsAnimationController.Climb();
    }

    /// <summary>
    /// Teleports the player to the top of the object he climbed
    /// </summary>
    public void ClimbFinish()
    {
        transform.position = climbTP.position;
    }
}

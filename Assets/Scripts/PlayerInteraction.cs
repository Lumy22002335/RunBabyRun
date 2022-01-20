using UnityEngine;
using TMPro;

/// <summary>
/// Responsible for handling all player interactions
/// </summary>
[RequireComponent(typeof(FpsControllerInput))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private TextMeshProUGUI interactionText;

    private FpsControllerInput fpsControllerInput;
    private FpsController fpsController;
    private PlayerInventory playerInventory;
    private Camera cam;

    private bool successfullHit;

    // Start is called before the first frame update
    private void Start()
    {
        fpsControllerInput = GetComponent<FpsControllerInput>();
        fpsController = GetComponent<FpsController>();
        playerInventory = GetComponent<PlayerInventory>();
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckForInteractable();
    }

    /// <summary>
    /// Ray cast to check for an interactible
    /// </summary>
    private void CheckForInteractable()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        successfullHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable;

            // If it hits an interactible
            if (hit.collider.TryGetComponent<Interactable>(out interactable))
            {
                if (!interactable.StandingOnly || 
                    (interactable.StandingOnly && fpsController.MoveState == MovementType.Walk))
                {
                    // Handle the interaction
                    HandleInteraction(interactable);
                }
            }
        }

        if (!successfullHit)
        {
            interactionText.text = string.Empty;
        }
    }

    /// <summary>
    /// Handles the interaction between the player and the object
    /// </summary>
    /// <param name="interactable">The interactible object</param>
    private void HandleInteraction(Interactable interactable)
    {
        // Check if the interactible is pickable and inventory is full
        if (((interactable is IPickable) && !playerInventory.IsFull) || 
            !(interactable is IPickable))
        {
            interactionText.text = interactable.Description;
        }
        else
        {
            // If so display a warning for a full inventory
            interactionText.text = "Inventory is Full";
        }

        successfullHit = true;

        // Check if the player pressed the interaction key
        if (fpsControllerInput.PlayerInteract())
        {
            if (((interactable is IPickable) && !playerInventory.IsFull) || 
            !(interactable is IPickable))
            {
                // If it's a pickable and the inventory is no full pick up the object
                interactable.Interact();
            }


            if (interactable is IPickable)
            {
                playerInventory.AddToInventory ((interactable as IPickable));
            }
        }
    }
}

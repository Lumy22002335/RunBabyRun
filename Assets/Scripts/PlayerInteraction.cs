using UnityEngine;
using TMPro;

[RequireComponent(typeof(FpsControllerInput))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private TextMeshProUGUI interactionText;

    private FpsControllerInput fpsControllerInput;
    private Camera cam;

    private bool successfullHit;

    // Start is called before the first frame update
    private void Start()
    {
        fpsControllerInput = GetComponent<FpsControllerInput>();
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        successfullHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable;

            if (hit.collider.TryGetComponent<Interactable>(out interactable))
            {
                HandleInteraction(interactable);
            }
        }

        if (!successfullHit)
        {
            interactionText.text = string.Empty;
        }
    }

    private void HandleInteraction(Interactable interactable)
    {
        interactionText.text = interactable.Description;
        successfullHit = true;

        if (fpsControllerInput.PlayerInteract())
        {
            interactable.Interact();
        }
    }
}

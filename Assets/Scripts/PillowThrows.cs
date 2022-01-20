using UnityEngine;

/// <summary>
/// Allows the player to trow pillows from the bed to the ground
/// </summary>
public class PillowThrows : Interactable
{
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private GameObject[] pillows;

    [SerializeField] private GameObject climbPoint;

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    public override string Description => "Press [E] to Throw Pillow";

    private int numPillowsThrown;

    /// <summary>
    /// Runs at the start
    /// </summary>
    private void Start() 
    {
        numPillowsThrown = 0;
    }

    /// <summary>
    /// Player Interaction
    /// </summary>
    public override void Interact()
    {
        // Check if the num of pillows thrown is lower that 6
        if (numPillowsThrown < 6)
        {
            // If so try to get a pillow from the inventory
            if (inventory.GetFromInventory("Pillow"))
            {
                numPillowsThrown++;

                // Activate the next pillow on the ground
                for (int i = 0; i < pillows.Length; i++)
                {
                    if (!pillows[i].activeSelf)
                    {
                        pillows[i].SetActive(true);
                        break;
                    }
                }
            }

            // If the player had thrown all pillows
            if (numPillowsThrown >= 6)
            {
                // Enable the climb feature
                climbPoint.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}

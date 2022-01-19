using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for allowing the player to create a pillow ladder
/// </summary>
public class PillowLadder : Interactable
{
    [SerializeField] private GameObject[] pillows;
    [SerializeField] private GameObject[] pillowsReference;
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    public override string Description => "Place Pillow";

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
        // Try to get a pillow from the inventory
        if (inventory.GetFromInventory("Pillow"))
        {
            numPillowsThrown++;

            // Set the next pillow in the ladder active
            for (int i = 0; i < pillows.Length; i++)
            {
                if (!pillows[i].activeSelf)
                {
                    pillows[i].SetActive(true);
                    break;
                }
            }

            // Check if we have all pillows
            if (numPillowsThrown >= 7)
            {
                gameObject.SetActive(false);
            } 
            else
            {
                // Disable the corresponding hint pillow
                pillowsReference[numPillowsThrown - 1].SetActive(false);
                pillowsReference[numPillowsThrown].SetActive(true);
            }
        }
    }
}

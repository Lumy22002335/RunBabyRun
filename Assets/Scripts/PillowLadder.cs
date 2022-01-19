using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowLadder : Interactable
{
    [SerializeField] private GameObject[] pillows;
    [SerializeField] private GameObject[] pillowsReference;
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    public override string Description => "Place Pillow";

    private int numPillowsThrown;

    private void Start()
    {
        numPillowsThrown = 0;
    }

    public override void Interact()
    {
        if (inventory.GetFromInventory("Pillow"))
        {
            numPillowsThrown++;

            for (int i = 0; i < pillows.Length; i++)
            {
                if (!pillows[i].activeSelf)
                {
                    pillows[i].SetActive(true);
                    break;
                }
            }

            if (numPillowsThrown >= 7)
            {
                gameObject.SetActive(false);
            } 
            else
            {
                pillowsReference[numPillowsThrown - 1].SetActive(false);
                pillowsReference[numPillowsThrown].SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowThrows : Interactable
{
    [SerializeField] private FpsController fpsController;

    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private GameObject[] pillows;

    private int numPillowsThrown;

    private void Start() 
    {
        numPillowsThrown = 0;
    }

    public override string Description 
    { 
        get
        {
            if (numPillowsThrown < 6)
            {
                return "Press [E] to Throw Pillow";
            }
            else
            {
                return "Press [E] to Climb";
            }
        }
    }

    public override void Interact()
    {
        if (numPillowsThrown < 6)
        {
            if (inventory.GetFromInventory ("Pillow"))
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
            }
        }
        else
        {
            fpsController.PlayerClimb();
        }
    }
}

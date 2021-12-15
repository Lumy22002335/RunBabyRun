using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowThrows : Interactable
{
    [SerializeField] private FpsController fpsController;

    [SerializeField] private int numPillowsThrown;

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
            
        }
        else
        {
            fpsController.PlayerClimb();
        }
    }
}

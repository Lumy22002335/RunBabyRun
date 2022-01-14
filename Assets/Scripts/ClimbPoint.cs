using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbPoint : Interactable
{
    [SerializeField] private FpsController fpsController;

    public override string Description => "Press [E] to climb";

    public override void Interact()
    {
        fpsController.PlayerClimb();
        gameObject.SetActive(false);
    }
}

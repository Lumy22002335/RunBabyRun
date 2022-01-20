using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holder for the bed door
/// </summary>
public class DoorHolder : Interactable
{
    [SerializeField] private string description;
    public override string Description => description;

    int interact = Animator.StringToHash("Interact");

    public bool Holding { get; private set; }

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    /// <summary>
    /// Runs at the start
    /// </summary>
    private void Start()
    {
        Holding = true;
    }

    /// <summary>
    /// Player Interaction
    /// </summary>
    public override void Interact()
    {
        // Animates the player pulling out the holder
        GetComponent<Animator>().SetTrigger(interact);
    }

    /// <summary>
    /// Sets the it is no longer holding
    /// </summary>
    public void StopHolding()
    {
        Holding = false;
    }

    /// <summary>
    /// Disables the holder
    /// </summary>
    public void DisableMe()
    {
        gameObject.SetActive(false);
    }
}

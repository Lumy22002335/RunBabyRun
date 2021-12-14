using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : Interactable
{
    [SerializeField] private string description;
    public override string Description => description;

    int interact = Animator.StringToHash("Interact");

    public bool Holding { get; private set; }

    private void Start()
    {
        Holding = true;
    }

    public override void Interact()
    {
        GetComponent<Animator>().SetTrigger(interact);
    }

    public void StopHolding()
    {
        Holding = false;
    }

    public void DisableMe()
    {
        gameObject.SetActive(false);
    }
}

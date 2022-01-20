using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cubes : Interactable, IPickable
{
    [SerializeField] private string pickableName;
    public string Name => pickableName;

    public override bool StandingOnly => false;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    public override string Description => "Press [E] to pick up";

    public override void Interact ()
    {
        gameObject.SetActive(false); 
    } 
}

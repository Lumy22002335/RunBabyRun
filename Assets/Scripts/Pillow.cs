using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Interactable, IPickable
{
    [SerializeField] private string name;
    public string Name => name;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    public override string Description => "Press [E] to pick up";

    public override void Interact ()
    {
        gameObject.SetActive(false); 
    } 
}

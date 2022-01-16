using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimonButton : Interactable
{
    [SerializeField] private string buttonColor;

    [SerializeField] private SimonChest chest;

    public override string Description => "Press [E] to click button";

    public override void Interact ()
    {
        chest.AddValueAndCheckSequence(buttonColor);
    } 
}

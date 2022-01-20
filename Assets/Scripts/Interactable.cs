using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactibles abstract class
/// For all the interactibles in the game
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    /// <summary>
    /// The Description
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// If you can only interact while standing
    /// </summary>
    public abstract bool StandingOnly { get; }

    /// <summary>
    /// Interact with the object
    /// </summary>
    public abstract void Interact();
}

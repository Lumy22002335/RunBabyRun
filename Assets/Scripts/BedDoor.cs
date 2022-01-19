using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Drops the bed door when possible
/// </summary>
public class BedDoor : MonoBehaviour
{
    [SerializeField] private DoorHolder holderOne;
    [SerializeField] private DoorHolder holderTwo;
    [SerializeField] private GameObject pillowThrows;

    int drop;
    
    private Animator animator;

    /// <summary>
    /// Runs at the start
    /// </summary>
    private void Start()
    {
        drop = Animator.StringToHash("Drop");
        animator = GetComponent<Animator>();

        StartCoroutine(WaitDoorDrop());
    }

    /// <summary>
    /// Wait for the holders to be removed to drop the door
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitDoorDrop()
    {
        // Run in loop while the holders are in place
        do
        {
            yield return null;
        } while (holderOne.Holding || holderTwo.Holding);

        // Trigger the drop dor animation
        animator.SetTrigger(drop);
        pillowThrows.SetActive(true);
    }
}

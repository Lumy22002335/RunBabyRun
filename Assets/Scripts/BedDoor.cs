using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDoor : MonoBehaviour
{
    [SerializeField] private DoorHolder holderOne;
    [SerializeField] private DoorHolder holderTwo;
    [SerializeField] private GameObject pillowThrows;

    int drop;
    
    private Animator animator;

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
        do
        {
            yield return null;
        } while (holderOne.Holding || holderTwo.Holding);

        animator.SetTrigger(drop);
        pillowThrows.SetActive(true);
    }
}

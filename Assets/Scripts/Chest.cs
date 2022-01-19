using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private GameObject[] slots;

    private Animator animator;

    private int numSlots;

    private void Start ()
    {
        animator = GetComponent<Animator>();

        numSlots = slots.Length;
    }

    private void Update ()
    {
        int combinationCheck = 0;

        for (int i = 0; i < numSlots; i++)
        {
            if (cubes[i].tag == slots[i].tag)
            {
                combinationCheck++;
            }
        }

        if (combinationCheck == numSlots)
        {
            animator.SetTrigger("Open");
        }
    }
}

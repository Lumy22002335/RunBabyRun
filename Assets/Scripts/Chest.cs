using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private GameObject[] slots;
    [SerializeField] private bool Opened = false;

    private int numSlots;

    private void Start ()
    {
        numSlots = this.gameObject.transform.childCount;
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
            Opened = true;
            // Add here trigger to open the chest;
        }
    }
}

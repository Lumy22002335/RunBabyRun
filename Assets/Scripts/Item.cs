using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start() 
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory> ();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // Item can be added
                    inventory.isFull[i] = true;

                    Instantiate (itemButton, inventory.slots[i].transform, false);

                    Destroy (gameObject);

                    break;
                }
            }
        }    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public KeyCode key;

    private void Start() 
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory> ();  
    }

    private void Update() 
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

        if (Input.GetKeyDown(key))
        {
            Invoke("DropInventory", 0f);
        }
    }

    public void DropInventory ()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Drop>().DropItem ();
            GameObject.Destroy(child.gameObject);   
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;

    public GameObject[] slots;

    //public InventoryObject inventory;

    // Esta parte eu não sei como queres fazer a interação entre o player e o objecto, por isso deixo como está
    // e só tens que mudar o tipo da função, porque o corpo dela funciona igual.

    /*public void OnTriggerEnter (Collider variable)
    {
        // Qualquer objecto que seja criado e que possa ser incluido no inventário terá que ter um script com 
        // um parâmetro: public ItemObject item;
        
        var item = variable.GetComponent<Item> ();

        if (item)
        {
            inventory.AddItem (item.item);
            Destroy (variable.gameObject);
        }
    }*/

    /*private void OnApplicationQuit () 
    {
        inventory.Container.Clear ();
    }*/
}
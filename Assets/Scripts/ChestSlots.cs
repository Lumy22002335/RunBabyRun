using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlots : Interactable
{
    [SerializeField] private PlayerInventory inventory;

    public override string Description => "Place Cube";

    private Vector3 cubePos;

    private void Start (){

        if (this.gameObject.name == "Slot1")
        {
            cubePos = this.gameObject.transform.position;
        }

        else if (this.gameObject.name == "Slot2")
        {
            cubePos = this.gameObject.transform.position;
        }

        else if (this.gameObject.name == "Slot3")
        {
            cubePos = this.gameObject.transform.position;
        }

        else if (this.gameObject.name == "Slot4")
        {
            cubePos = this.gameObject.transform.position;
        }
    }

    public override void Interact()
    {

        if (inventory.InventoryItem("Star Cube") == "Star Cube")
        {
            Instantiate (GameObject.Find ("CubeStart"), cubePos, Quaternion.identity);

            this.gameObject.tag = "Star";
        }

        else if (inventory.InventoryItem("Triangle Cube") == "Triangle Cube")
        {
            Instantiate (GameObject.Find ("CubeTriangle"), cubePos, Quaternion.identity);

            this.gameObject.tag = "Triangle";
        }

        else if (inventory.InventoryItem("Circle Cube") == "Circle Cube")
        {
            Instantiate (GameObject.Find ("CubeCircle"), cubePos, Quaternion.identity);

            this.gameObject.tag = "Circle";
        }

        else if (inventory.InventoryItem("Square Cube") == "Square Cube")
        {
            Instantiate (GameObject.Find ("CubeSquare"), cubePos, Quaternion.identity);

            this.gameObject.tag = "Square";
        }
    }
}
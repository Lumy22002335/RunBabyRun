using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlots : Interactable
{
    [SerializeField] private PlayerInventory inventory;

    public override string Description => "Place Cube";

    [SerializeField] private GameObject[] slot;

    private Vector3 cubePos;

    private void Start (){

        if (this.gameObject.name == "Slot1")
        {
            this.gameObject.transform.localPosition = new Vector3 (0, 0, 0);
            cubePos = this.gameObject.transform.position;
        }

        else if (this.gameObject.name == "Slot2")
        {
            this.gameObject.transform.localPosition = new Vector3 (0, 0, +0.1f);
            cubePos = this.gameObject.transform.position;
        }

        else if (this.gameObject.name == "Slot3")
        {
            this.gameObject.transform.localPosition = new Vector3 (0, 0, +0.2f);
            cubePos = this.gameObject.transform.position;
        }

        else if (this.gameObject.name == "Slot4")
        {
            this.gameObject.transform.localPosition = new Vector3 (0, 0, +0.3f);
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
            Instantiate (GameObject.Find ("SquareCube"), cubePos, Quaternion.identity);

            this.gameObject.tag = "Square";
        }
    }
}
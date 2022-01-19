using UnityEngine;

public class ChestSlots : Interactable
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Transform spawnCube;
    [SerializeField] private string myCubeName;
    [SerializeField] private GameObject myLight;

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    public override string Description => "Place Cube";

    private void Update()
    {
        if (inventory.InventoryItem(myCubeName))
        {
            myLight.SetActive(true);
        }
        else
        {
            myLight.SetActive(false);
        }
    }

    public override void Interact()
    {

        if (inventory.GetFromInventory("Star Cube"))
        {
            Instantiate(Resources.Load("CubeStar"), spawnCube.position, Quaternion.identity);

            this.gameObject.tag = "Star";
        }

        else if (inventory.GetFromInventory("Triangle Cube"))
        {
            Instantiate(Resources.Load("CubeTriangle"), spawnCube.position, Quaternion.identity);

            this.gameObject.tag = "Triangle";
        }

        else if (inventory.GetFromInventory("Circle Cube"))
        {
            Instantiate(Resources.Load("CubeCircle"), spawnCube.position, Quaternion.identity);

            this.gameObject.tag = "Circle";
        }

        else if (inventory.GetFromInventory("Square Cube"))
        {
            Instantiate(Resources.Load("CubeSquare"), spawnCube.position, Quaternion.identity);

            this.gameObject.tag = "Square";
        }
    }
}
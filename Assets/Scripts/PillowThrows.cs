using UnityEngine;

public class PillowThrows : Interactable
{
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private GameObject[] pillows;

    [SerializeField] private GameObject climbPoint;

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    public override string Description => "Press [E] to Throw Pillow";

    private int numPillowsThrown;

    private void Start() 
    {
        numPillowsThrown = 0;
    }

    public override void Interact()
    {
        if (numPillowsThrown < 6)
        {
            if (inventory.GetFromInventory("Pillow"))
            {
                numPillowsThrown++;

                for (int i = 0; i < pillows.Length; i++)
                {
                    if (!pillows[i].activeSelf)
                    {
                        pillows[i].SetActive(true);
                        break;
                    }
                }
            }

            if (numPillowsThrown >= 6)
            {
                climbPoint.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}

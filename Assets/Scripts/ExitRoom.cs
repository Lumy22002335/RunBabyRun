using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRoom : Interactable
{
    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private bool standingOnly;
    public override bool StandingOnly => standingOnly;

    public override string Description => "Press [E] to Use Giraffe";

    private BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        collider.enabled = inventory.InventoryItem("Giraffe");
    }

    public override void Interact()
    {
        SceneManager.LoadScene("Credits");
    }
}

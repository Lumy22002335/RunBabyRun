using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for allowing the player to save
/// or remove items from the inventory
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    private IPickable[] slots;

    public bool IsFull {get; private set;}

    [SerializeField] private Image[] selected;
    [SerializeField] private Image[] icons;

    private FpsControllerInput fpsControllerInput;

    private int selectedIndex;

    private void Start() 
    {
        fpsControllerInput = GetComponent<FpsControllerInput> ();
        slots = new IPickable[4];
        selectedIndex = 0;
    }

    /// <summary>
    /// Runs once per frame
    /// </summary>
    private void Update() 
    {
        // If there's a new select input
        if (fpsControllerInput.SelectItem())
        {
            // Update the selected slot
            UpdateSelectedItem();
        }

        // Checks if the inventory is full
        for (int i = 0; i < slots.Length; i++)
        {
            IsFull = true;

            if (slots[i] == null)
            {
                IsFull = false;
                break;
            }
        }
    }

    /// <summary>
    /// Update the selected inventory slot
    /// </summary>
    private void UpdateSelectedItem ()
    {
        selected[0].enabled = fpsControllerInput.SelectItem1();
        selected[1].enabled = fpsControllerInput.SelectItem2();
        selected[2].enabled = fpsControllerInput.SelectItem3();
        selected[3].enabled = fpsControllerInput.SelectItem4();

        for (int i = 0; i < 4; i++)
        {
            selectedIndex = selected[i].enabled ? i : selectedIndex;
        }
    }

    /// <summary>
    /// Adds and object to the inventory
    /// </summary>
    /// <param name="pickable">The object must be a pickable</param>
    public void AddToInventory (IPickable pickable)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = pickable;
                icons[i].sprite = pickable.Icon;
                break;
            }
        }
    }

    /// <summary>
    /// Gets and object from the inventory
    /// </summary>
    /// <param name="name">Name of the object</param>
    /// <returns>If we got the object</returns>
    public bool GetFromInventory (string name)
    {
        if (slots[selectedIndex] != null && slots[selectedIndex].Name == name)
        {
            slots[selectedIndex] = null;
            icons[selectedIndex].sprite = null;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if a certain object is in the Inventory
    /// </summary>
    /// <param name="name">Name of the Object</param>
    /// <returns>If the player has the object</returns>
    public bool InventoryItem(string name)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                if (slots[i].Name == name)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
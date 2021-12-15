using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update() 
    {
        if (fpsControllerInput.SelectItem())
        {
            UpdateSelectedItem();
        }

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

    private void UpdateSelectedItem ()
    {
        selected[0].enabled = fpsControllerInput.SelectItem1();
        selectedIndex = selected[0].enabled ? 0 : selectedIndex;

        selected[1].enabled = fpsControllerInput.SelectItem2();
        selectedIndex = selected[1].enabled ? 1 : selectedIndex;

        selected[2].enabled = fpsControllerInput.SelectItem3();
        selectedIndex = selected[2].enabled ? 2 : selectedIndex;
    }

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

    public bool GetFromInventory (string name)
    {
        if (slots[selectedIndex] != null && slots[selectedIndex].Name == name)
        {
            slots[selectedIndex] = null;
            icons[selectedIndex].sprite = null;
            return true;
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                if (slots[i].Name == name)
                {
                    slots[i] = null;
                    icons[i].sprite = null;
                    return true;
                }
            }
        }

        return false;
    }
}
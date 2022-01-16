using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonChest : MonoBehaviour
{
    [SerializeField]
    private string correctSequence, currentSequence;
    Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        correctSequence = "1234";
        currentSequence = "";
        
    }


    public void AddValueAndCheckSequence(string ButtonColor)
    {
        switch(ButtonColor)
        {
            case "Red":
                currentSequence += 1;
                break;
            case "Green":
                currentSequence += 2;
                break; 
            case "Yellow":
                currentSequence += 3;
                break; 
            case "Orange":
                currentSequence += 4;
                break;
        }
        
        if (currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
        }
        else if (currentSequence == correctSequence)
        {
            currentSequence = "";
            animator.SetTrigger("Open");
        }
    }

    
    
}

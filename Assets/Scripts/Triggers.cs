using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public DisplayText displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayText.AddText("Make your way to the fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering Trigger");
        if (tag == "WalkTextTrigger")
        {
            displayText.ClearText();
            other.transform.GetComponent<DisplayText>();
            displayText.AddText("Press the WSAD Keys to Move...");
            Debug.Log("Press the WSAD Keys to Move...");
        }

        if (tag == "JumpTextTrigger")
        {
            displayText.ClearText();
            other.transform.GetComponent<DisplayText>();
            displayText.AddText("Press Space to Jump...");
            Debug.Log("Press Space to Jump...");
        }

        if (tag == "River")
        {
            displayText.AddText("You Have lost a life");
            PlayerMovement Respawn = GetComponent<PlayerMovement>();
         
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaving Trigger");
        if (tag == "WalkTextTrigger")
        {
            displayText.ClearText();
            Debug.Log("Text cleared");
        }

        if(tag == "JumpTextTrigger")
        {
            displayText.ClearText();
            Debug.Log("Text cleared");
        }

        if(tag == "RiverTrigger")
        {
            displayText.ClearText();
            Debug.Log("Text cleared");
        }
    }

  
   

    
}

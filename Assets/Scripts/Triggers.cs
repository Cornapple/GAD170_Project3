using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public DisplayText displayText;
    public PlayerMovement playerMovement;
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
            displayText.AddText("Press Space to Jump...");
            Debug.Log("Press Space to Jump...");
        }

        if (tag == "RiverTrigger")
        {
            displayText.ClearText();
            displayText.AddText("You Have Drowned.");
            Debug.Log("You have drowned");
            //playerMovement = GetComponent<PlayerMovement>();
            playerMovement.Respawn();
            Debug.Log("Respawn function called");
        }

        //if (tag == "RespawnTrigger")
        //{
        //    displayText.ClearText();
        //    displayText.AddText("You have reached a respawn point. If you drown, you will respawn here. If you drown 5 times, the game will Restart.");
        //}
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

        //if(tag == "RiverTrigger")
        //{
        //    displayText.ClearText();
        //    Debug.Log("Text cleared");
        //}
    }

  
   

    
}

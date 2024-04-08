using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public DisplayText displayText;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}

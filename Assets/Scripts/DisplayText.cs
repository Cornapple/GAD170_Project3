using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI myText; // all code in this script will be able to be accessed by other scripts in order to display text in the Unity Scene
    public void AddText(string textToAdd) // will add text to the text box in the uniy scene
    {
        myText.text += textToAdd;
    }
    public void ClearText() // will clear the text form the text box
    {
        myText.text = "";
    }
}

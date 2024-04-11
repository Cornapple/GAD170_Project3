using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float speed = 12f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;

    public GameObject Player;
    public DisplayText displayText;

    public CharacterController controller;
    private Vector3 velocity;

    
    public int lifeCount = 0;

    // Customisable gravity
    public float gravity = -20f;

    // Tells the script how far to keep the object off the ground
    public float groundDistance = 0.4f;

    // So the script knows if you can jump!
    private bool isGrounded;

    // How high the player can jump
    public float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // If the variable "controller" is empty...
        if (controller == null)
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            controller = GetComponent<CharacterController>();
        }

        lifeCount = 5;
        Debug.Log("You have" + lifeCount + "lives");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // These lines let the script rotate the player based on the mouse moving
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -40, 40);
        
        // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Let the player jump if they are on the ground and they press the jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Rotate the player based off those mouse values we collected earlier
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0);

        // This is stealing the data about the player being on the ground from the character controller
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // This fakes gravity!
        velocity.y += gravity * Time.deltaTime;

        // This takes the Left/Right and Forward/Back values to build a vector
        Vector3 move = transform.right * x + transform.forward * z;

        // Finally, it applies that vector it just made to the character
        controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);


        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    OnDeath();
        //}
    }

    //public void OnDeath()
    //{
        

    //    Respawn();
    //}

    public void Respawn()
    {
        for  (int i = 0; lifeCount < 5; i++) 
        {
            DisableMovement();
            displayText.ClearText();
            lifeCount += 1;

            Debug.Log(lifeCount);
            Debug.Log("You have drowned. Press R to Respawn");

            displayText.AddText("You have drowned. Press R to Respawn");
            Player.transform.position = new Vector3(-90, 73, -73);
            EnableMovement();
            
        }


    }

    public void DisableMovement()
    {
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
    }

    public void EnableMovement()
    {
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = true;
    }
}

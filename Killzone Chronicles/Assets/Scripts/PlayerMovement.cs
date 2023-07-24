using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // Speed
    public float speed = 12f;
    // Gravity
    public float gravity = -9.81f;
    // Jump Height
    public float jumpHeight = 3f;

    // The transform of the Ground Check Game Object
    public Transform groundCheck;
    // Radius of the CheckSphere
    public float groundDistance = 0.4f;
    // what Layers the CheckSphere can detect
    public LayerMask groundMask;

    // Velocity
    Vector3 velocity;
    // If the player is Grounded
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // References the Character Controller component
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        // If player is grounded and velovity.y is less than 0 it sets velocity.y to -2 so that it stops decreasing. It gets set to -2 instead of 0 incase it detects the gorund slightly before it hits the ground so it doesn't stop midair right before hitting the gorund
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Detects if the player is moving sideways
        float x = Input.GetAxis("Horizontal");
        // Detects if the player is moving forwards
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;
        
        // Moves the Player 
        controller.Move(move * speed * Time.deltaTime);

        // Allows the player to jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * Time.deltaTime);
        }

        // Applies Gravity
        velocity.y += gravity * Time.deltaTime;

        // Makes the player fall
        controller.Move(velocity * Time.deltaTime);
    }
}

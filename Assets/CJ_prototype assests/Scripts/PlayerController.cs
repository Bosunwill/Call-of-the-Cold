using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This controller uses the Rigidbody system for movement
    public Rigidbody theRB;

    //Variables for movement and jump force

    public float moveSpeed;
    public float jumpForce;

    private Vector2 moveInput;

    // These build a raycast system for jumping
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    //Animator refrence 
    public Animator anim;

    //For accessing the SpriteRenderers X/Y flip
    public SpriteRenderer theSR;

    void Start()
    {

    }

    void Update()
    {
        //Gets the inputs for movement
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        //Stops any wierd directional movement speed increases
        moveInput.Normalize();

        // Applies the inputs to the Rigidbody 
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);

        //Animator controller for movement recieved from the rigidbody
        anim.SetFloat("Speed", theRB.velocity.magnitude);

        //Stores information if the raycast hits anything and detects the gorund when jumping
        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }


        // Key input for the jump and velocity
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }


        //This flips the sprite when moving
        if(!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
        } else if(theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = false;
        }

    }
}

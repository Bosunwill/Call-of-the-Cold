using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //This controller uses the Rigidbody system for movement
    public Rigidbody theRB;

    //Variables for movement and jump force

    public float moveSpeed;
    public float jumpForce;
    public bool isCrouched;

    private Vector2 moveInput;

    // These build a raycast system for jumping
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    //Animator refrence 
    public Animator anim;

    //For accessing the SpriteRenderers X/Y flip
    public SpriteRenderer theSR;

    // These sets of code control the hot and cold and players health
    //Collider triggers for Hot and Cold

    public float maxHealth = 100;
    [Range(0, 100)]
    public float currentHealth;

    public float normalTemp = 32f;
    [Range(32f, 100f)]
    public float currentTemp;

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Cold" && currentTemp >= 32f && currentHealth < 100)
        {
            currentTemp -= 3f * Time.deltaTime * 1;

            Debug.Log("You are cold" + currentHealth);
        }
        if (other.gameObject.tag == "Hot" && currentTemp < 120f)
        {
            currentTemp += 1f * Time.deltaTime * 1;
            //    Debug.Log("You are hot" + currentHealth);
        }
    }


    void Start()
    {
        currentHealth = maxHealth;
        currentTemp = normalTemp;
    }

    void Update()
    {

        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("CROUCHING");
            isCrouched = true;
            moveSpeed = 0;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouched = false;
            moveSpeed = 10;
        }

        // not sure what this code does is this part of the inventory? -CJ
        /*  if (EventSystem.current.IsPointerOverGameObject())
              return; */

        //Gets the inputs for movement
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        //Stops any wierd directional movement speed increases
        moveInput.Normalize();

        // Applies the inputs to the Rigidbody 
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);

        //Animator controller for movement recieved from the rigidbody
        anim.SetFloat("Speed", theRB.velocity.magnitude);
        anim.SetBool("isCrouched", isCrouched);


        //Control for crouching 


        //Commented out to remove jumping but not deleted incase we change our minds
        //Stores information if the raycast hits anything and detects the gorund when jumping
        /*RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        // Key input for the jump and velocity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        } */


        //This flips the sprite when moving
        if (!theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = true;
        }
        else if (theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = false;
        }

        if (currentTemp > 60f)
        {
            Debug.Log("You are too hot!");
            currentHealth -= 1 * Time.deltaTime * 1;
        }

        if (currentTemp < 40f && currentHealth < 100)
        {
            currentHealth += 1 * Time.deltaTime * 1;
        }

    }
}

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

    public HealthBar healthBar;

    public float maxHealth = 100;
    [Range(0, 100)]
    public float currentHealth = 100;
    // Temps are in - because they need to rotate to the right

    public float normalTemp = -45f;
    [Range(0f, -90f)]
    public float currentTemp;

    private bool isVicDead = false;

    //Function on trigger to control temp on collision might be able to be 
    //expanded for ambient temp system later
    void OnTriggerStay(Collider other)
    {
        Debug.Log("triggered");

        if (other.gameObject.tag == "Cold" && currentTemp >= -90f)// && currentHealth < 100f)
        {
            currentTemp -= 3f * Time.deltaTime * 1;

            Debug.Log("You are cold" + currentHealth);
        }
        if (other.gameObject.tag == "Hot")
        {
            Debug.Log("Hot");
            currentTemp += 1f * Time.deltaTime * 1;

            //    Debug.Log("You are hot" + currentHealth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            // Debug.Log("HIT");
        }
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("You got hit");
            currentHealth -= 200 * Time.deltaTime;
         //   healthBar.SetHealth(currentHealth);

        }
    }


    public Transform tempArrow;

    void TempGuage()
    {
        tempArrow.localRotation = Quaternion.Euler(0f, 0f, currentTemp);

    }


    void Start()
    {
        currentHealth = maxHealth;
        
        currentTemp = normalTemp;

        
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);
        TempGuage();
        // Code for crouching and stoping movement when crouching
        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("CROUCHING");
            isCrouched = true;
            moveSpeed = 0;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouched = false;
            moveSpeed = 4;
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

        if (currentHealth < 0.1)
        {
            isVicDead = true;
        }

        //Animator controller for movement recieved from the rigidbody
        anim.SetFloat("Speed", theRB.velocity.magnitude);
        anim.SetBool("isCrouched", isCrouched);
        anim.SetFloat("currentHealth", currentHealth);
        anim.SetBool("victorDead", isVicDead);


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
        //temp code for temperature based healing. 
        if (currentTemp > -23f)
        {
            Debug.Log("You are too hot!");
            currentHealth -= 1 * Time.deltaTime * 1;
          //  healthBar.SetHealth(currentHealth);

        }

        if (currentTemp < -70f && currentHealth < 100)
        {
            currentHealth += 1 * Time.deltaTime * 1;
           // healthBar.SetHealth(currentHealth);

        }

    }
}

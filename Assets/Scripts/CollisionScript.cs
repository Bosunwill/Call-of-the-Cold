using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public HealthBar healthBar;

    public float maxHealth = 100;
    [Range(0, 100)]
    public float currentHealth;
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
            currentTemp += 2f * Time.deltaTime * 1;

            //    Debug.Log("You are hot" + currentHealth);
        }
    }

    [SerializeField]
    Transform tempArrow;

    void TempGauge()
    {
        tempArrow.localRotation = Quaternion.Euler(0f, 0f, currentTemp);

    }
    void Start()
    {
        currentTemp = normalTemp;
        currentHealth = maxHealth;


    }

    void Update()
    {
        TempGauge();
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

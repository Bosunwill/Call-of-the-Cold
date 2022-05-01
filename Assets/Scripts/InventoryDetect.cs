using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDetect : MonoBehaviour
{

    bool displayText = false;

    [SerializeField] InventoryUI ui;

    //this script activates the words telling you what is interactable.

    void Start()
    {
        ui = GameObject.Find("GameManager").GetComponent<InventoryUI>();
        ui.interactText.SetActive(false);
    }
    

    void Update()
    {
        if(displayText)
        {
            ui.interactText.SetActive(true);
        }
        else if(!displayText)
        {
            ui.interactText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            displayText = true;
            
        }
        if(other.gameObject.CompareTag("KeyCardDoor"))
        {
            ui.keyDoorNear = true;
        }
        if(other.gameObject.CompareTag("ScrewDriverDoor"))
        {
            ui.brokenDoorNear = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            if(!ui.inventoryUp)
            {
                displayText = true;
            }
            else if(ui.inventoryUp)
            {
                displayText = false;
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            displayText = false;
        }
        if(other.gameObject.CompareTag("KeyCardDoor"))
        {
            ui.keyDoorNear = false;
        }
        if(other.gameObject.CompareTag("ScrewDriverDoor"))
        {
            ui.brokenDoorNear = false;
        }
    }
}

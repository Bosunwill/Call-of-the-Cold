using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public bool canPickup = false;
    public bool opened = false;
    public Item item;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canPickup == true && opened == false)
        {
            PickUp();
        }
    }

    void PickUp ()
    {
        //Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        {
            opened = true;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("canPickup is now true!");
            canPickup = true;
        }
    }
}

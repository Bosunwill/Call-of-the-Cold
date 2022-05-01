using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    AudioLibrary aud;
    InventoryItemControl control;
    public bool canPickup = false;
    public bool opened = false;
    public Item item;

    public Animator notifAnim;

    public TextMeshProUGUI notifText;

    void Start()
    {
        control = GameObject.Find("GameManager").GetComponent<InventoryItemControl>();
        aud = control.GetComponent<AudioLibrary>();
        notifText = control.notif.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        notifAnim = control.notif.GetComponent<Animator>();
    }

    void Update()
    {
        if(Inventory.instance.outOfRoom)
        {
            canPickup = false;
        }
        if(Input.GetKeyDown(KeyCode.E) && canPickup == true && opened == false)
        {
            PickUp();
        }
        if(opened)
        {
            canPickup = false;
        }
    }

    void PickUp ()
    {
        aud.Play4();
        opened = true;
        //bool wasPickedUp = false;
        //Debug.Log("Picking up " + item.name);
        if(item.slotItem)
        {
            Debug.Log("slot is running");
            Inventory.instance.Add(item);
        }
        
        control.notif.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;

        notifAnim.SetTrigger("NotifTrigger");
        notifText.text = "Picked up " + item.name;

        // if(wasPickedUp)
        // {
        // }
        if(item.thisItem == Item.itemType.HandHeldFan)
        {
            control.fanObtained = true;
        }
        else if(item.thisItem == Item.itemType.CassettePlayer)
        {
            control.casObtained = true;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!opened)
            {
                Debug.Log("canPickup is now true!");
                canPickup = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!opened)
            {
                Debug.Log("canPickup is now true!");
                canPickup = true;
            }
        }
    }
}

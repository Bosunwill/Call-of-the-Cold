using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public InventoryItemControl control;
    public bool canPickup = false;
    public bool opened = false;
    public Item item;

    AudioLibrary aud;

    public Animator notifAnim;

    public TextMeshProUGUI notifText;

    void Start()
    {
        control = GameObject.Find("GameManager").GetComponent<InventoryItemControl>();
        notifAnim = GameObject.Find("Notifs").GetComponent<Animator>();
        aud = GameObject.Find("GameManager").GetComponent<AudioLibrary>();
        notifText = GameObject.Find("Notif Text").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
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
        opened = true;
        aud.Play4();
        
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

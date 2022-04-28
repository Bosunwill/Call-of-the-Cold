using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    InventoryItemControl control;
    public bool canPickup = false;
    public bool opened = false;
    public Item item;

    public Animator notifAnim;

    public TextMeshProUGUI notifText;

    void Start()
    {
        control = GameObject.Find("Game UI").GetComponent<InventoryItemControl>();
        notifText = control.notif.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        notifAnim = control.notif.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canPickup == true && opened == false)
        {
            PickUp();
        }
    }

    void PickUp ()
    {
        bool wasPickedUp = false;
        //Debug.Log("Picking up " + item.name);
        if(item.slotItem)
        {
            wasPickedUp = Inventory.instance.Add(item);
        }
        
        control.notif.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;

        notifAnim.SetTrigger("NotifTrigger");
        notifText.text = item.name + "has been added to inventory";

        if(wasPickedUp)
        {
            opened = true;
        }
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
            Debug.Log("canPickup is now true!");
            canPickup = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("canPickup is now false");
            canPickup = false;
        }
    }
}

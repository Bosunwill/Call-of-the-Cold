using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject interactText;
    public GameObject inventoryUI;

    public bool hasCassette = false;
    public bool hasFan = false;
    public bool inventoryUp = false;
    public bool keyDoorNear = false;
    public bool brokenDoorNear = false;

    InventoryItemControl control;
    public InventorySlot[] slots;
    Inventory inventory;
    playerController player;

    // Start is called before the first frame update
    void Start()
    {
        inventoryUI = GameObject.Find("Inventory Panel");
        itemsParent = GameObject.Find("Items Parent").transform;
        inventory = Inventory.instance;
        inventoryUI.SetActive(false);
        //StartCoroutine(WaitAtStart());
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<playerController>();
        player.healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        player.tempArrow = GameObject.Find("tempArrow").transform;
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Activating Inv");
            if(inventoryUp)
            {
                TurnOffInventory();
            }
            else if(!inventoryUp)
            {
                TurnOnInventory();
            }
        }
    }

    void UpdateUI()
    {
        Debug.Log("The script is running");
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("The for is running");
            if (i < inventory.items.Count)
            {
                Debug.Log("i = " + i);
                slots[i].AddItem(inventory.items[i]);
            }
           // else
           // {
           //     slots[i].ClearSlot();
           // }
        }
        
    }

    // IEnumerator WaitAtStart()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     inventoryUI.SetActive(false);
    // }


    public void TurnOnInventory()
    {
        //display inventory
        inventoryUI.SetActive(true);
        //player can't move
        player.enabled = false;
        //set boolean 
        inventoryUp = true;
    }

    public void TurnOffInventory()
    {
        inventoryUI.SetActive(false);
        player.enabled = true;
        inventoryUp = false;
    }
}

using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject inventoryUI;

    public bool hasCassette = false;
    public bool hasFan = false;
    public bool inventoryUp = false;

    InventorySlot[] slots;
    Inventory inventory;
    playerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerController>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        inventoryUI.SetActive(false);

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
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
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
           // else
           // {
           //     slots[i].ClearSlot();
           // }
        }
        
    }


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

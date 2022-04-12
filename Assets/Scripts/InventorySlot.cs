using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;
    Item item;
    public bool isPlaying = false;

    public AudioLibrary aud;


    public void Start()
    {
        aud = GameObject.Find("AudioManager").GetComponent<AudioLibrary>();
    }

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }

    // public void ClearSlot()
    // {
    //     //if(item.permItem == false)
    //     //{
    //         item = null;   
    //         icon.sprite = null;
    //         icon.enabled = false;
    //         //removeButton.interactable = false;
    //    // }
    // }

    public void OnRemoveButton()
    {
        //Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if(item.isCassette1 && !aud.audi.isPlaying)
            {
                aud.Play1();
            }
            if(item.isCassette2)
            {
                aud.Play2();
            }
            if(item.isCassette3)
            {
                aud.Play3();
            }
            else
            {
                item.Use();
                //item = null;
                //icon.enabled = false;
                //icon.sprite = null;
            }
        }   
    }
}

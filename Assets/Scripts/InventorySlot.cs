using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ITypewriter typeAnim;
    InventoryUI invUI;
    InventoryItemControl control;

    public Image icon;
    //public Button removeButton;
    Item item;
    public bool isPlaying = false;

    public AudioLibrary aud;


    public void Start()
    {
        //aud = GameObject.Find("AudioManager").GetComponent<AudioLibrary>();
        invUI = GameObject.Find("Player").GetComponent<InventoryUI>();
        control = GameObject.Find("Game UI").GetComponent<InventoryItemControl>();
    }

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        aud.Play4();
        //removeButton.interactable = true;
    }

     //public void ClearSlot()
     //{
     //   if(item.permItem == false)
     //   {
     //   item = null;   
     //   icon.sprite = null;
     //   icon.enabled = false;
     // //removeButton.interactable = false;
     //   }
     //}

    public void OnRemoveButton()
    {
        //Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if(item.thisItem == Item.itemType.Tape)
            {
               if(item.isCassette1 && !aud.audi.isPlaying && item.cassetteTape)
                {
                    if(control.casObtained)
                    {
                        control.casAnim.SetBool("IsPlaying", true);
                        control.casAnim.SetBool("IsCas1", true);
                        typeAnim.StartCoroutine(typeAnim.TrialType(1f));
                        StartCoroutine(EndAnim(18f));
                        aud.Play1();
                    }
                    
                }
                if(item.isCassette2)
                {
                    if(control.casObtained)
                    {
                        control.casAnim.SetBool("IsPlaying", true);
                        control.casAnim.SetBool("IsCas2", true);
                        StartCoroutine(EndAnim(12.5f));
                        aud.Play2();
                    }
                }
                if(item.isCassette3)
                {
                    if(control.casObtained)
                    {
                        control.casAnim.SetBool("IsPlaying", true);
                        control.casAnim.SetBool("IsCas2", true);
                        StartCoroutine(EndAnim(29f));
                        aud.Play3();
                    }
                } 
            }
            
            if(item.thisItem == Item.itemType.Batteries)
            {
                Inventory.instance.Remove(item);
                item = null;
                icon = null;
                control.fanAnim.SetBool("StartFan", true);
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

    IEnumerator EndAnim(float animLength)
    {
        yield return new WaitForSeconds(animLength);
        control.casAnim.SetBool("IsPlaying", false);
        control.casAnim.SetBool("IsCas1", false);
        control.casAnim.SetBool("IsCas2", false);
        control.casAnim.SetBool("IsCas3", false);
    }
}

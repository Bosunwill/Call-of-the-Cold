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
    public Item item;
    public bool isPlaying = false;

    public bool slotTaken = false;

    public AudioLibrary aud;

    public GameObject text;

    public GameObject fanText;


    public void Start()
    {
        aud = GameObject.Find("GameManager").GetComponent<AudioLibrary>();
        invUI = GameObject.Find("GameManager").GetComponent<InventoryUI>();
        control = GameObject.Find("GameManager").GetComponent<InventoryItemControl>();
    }

    public void AddItem (Item newItem)
    {
        Debug.Log("I am " + this.gameObject.name + " and I have added " + newItem);
        slotTaken = true;
        item = newItem;
        icon.sprite = item.icon;
        //control.icons.Add(icon.sprite);
        icon.enabled = true;
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
                        text.SetActive(true);
                        control.casAnim.SetBool("IsPlaying", true);
                        control.casAnim.SetBool("IsCas1", true);
                        typeAnim.StartCoroutine(typeAnim.TrialType(aud.cas1Text));
                        StartCoroutine(EndAnim(19f));
                        aud.Play1();
                    }
                    
                }
                if(item.isCassette2)
                {
                    if(control.casObtained)
                    {
                        text.SetActive(true);
                        control.casAnim.SetBool("IsPlaying", true);
                        control.casAnim.SetBool("IsCas2", true);
                        typeAnim.StartCoroutine(typeAnim.TrialType(aud.cas2Text));
                        StartCoroutine(EndAnim(15f));
                        aud.Play2();
                    }
                }
                if(item.isCassette3)
                {
                    if(control.casObtained)
                    {
                        text.SetActive(true);
                        control.casAnim.SetBool("IsPlaying", true);
                        control.casAnim.SetBool("IsCas2", true);
                        typeAnim.StartCoroutine(typeAnim.TrialType(aud.cas3Text));
                        StartCoroutine(EndAnim(35f));
                        aud.Play3();
                    }
                } 
            }
            
            if(item.thisItem == Item.itemType.Batteries)
            {
                if(control.fanObtained)
                {
                    Inventory.instance.Remove(item);
                    item = null;
                    icon.enabled = false;
                    control.fanAnim.SetBool("StartFan", true);
                    aud.PlayFan();
                }
                else if(!control.fanObtained)
                {
                    StartCoroutine(DisplayFanText());
                }
            }
            // else
            // {
            //     item.Use();
            //     //item = null;
            //     //icon.enabled = false;
            //     //icon.sprite = null;
            // }
        }   
    }

    IEnumerator EndAnim(float animLength)
    {
        yield return new WaitForSeconds(animLength);
        text.SetActive(false);
        control.casAnim.SetBool("IsPlaying", false);
        control.casAnim.SetBool("IsCas1", false);
        control.casAnim.SetBool("IsCas2", false);
        control.casAnim.SetBool("IsCas3", false);
    }

    IEnumerator DisplayFanText()
    {
        fanText.SetActive(true);
        yield return new WaitForSeconds(1f);
        fanText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    //public Button removeButton;
    Item item;
    public bool isPlaying = false;

    public AudioLibrary aud;

    public Animator casAnim;


    public void Start()
    {
        //aud = GameObject.Find("AudioManager").GetComponent<AudioLibrary>();
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
            if(item.isCassette1 && !aud.audi.isPlaying && item.cassetteTape)
            {
                casAnim.SetBool("IsPlaying", true);
                casAnim.SetBool("IsCas1", true);
                StartCoroutine(EndAnim());
                aud.Play1();
            }
            if(item.isCassette2)
            {
                casAnim.SetBool("IsPlaying", true);
                casAnim.SetBool("IsCas2", true);
                StartCoroutine(EndAnim());
                aud.Play2();
            }
            if(item.isCassette3)
            {
                casAnim.SetBool("IsPlaying", true);
                casAnim.SetBool("IsCas2", true);
                StartCoroutine(EndAnim());
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

    IEnumerator EndAnim()
    {
        yield return new WaitForSeconds(20f);
        casAnim.SetBool("IsPlaying", false);
        casAnim.SetBool("IsCas1", false);
        casAnim.SetBool("IsCas2", false);
        casAnim.SetBool("IsCas3", false);
    }
}

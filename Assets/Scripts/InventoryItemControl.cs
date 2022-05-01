using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemControl : MonoBehaviour
{
    //this script is for controlling the cassette player and handheld fan images
    public GameObject[] images;

    public List<Sprite> icons;

    public bool fanObtained = false;
    public bool casObtained = false;

    public GameObject cassettePlayer;
    public GameObject fan;

    public GameObject notif;

    public Animator casAnim;
    public Animator fanAnim;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //setting cassette player and fan up if obtained
        // cassettePlayer = GameObject.Find("Cassette");
        // fan = GameObject.Find("Handheld fan");
        // casAnim = cassettePlayer.GetComponent<Animator>();
        // fanAnim = fan.GetComponent<Animator>();
        // notif = GameObject.Find("Notifs");
        if(cassettePlayer != null && fan != null)
        {
            if(casObtained)
            {
                Debug.Log("detecting the cassette player");
                cassettePlayer.SetActive(true);
            }
            else if(!casObtained)
            {
                Debug.Log("detecting no cassette");
                cassettePlayer.SetActive(false);
            }
            if(fanObtained)
            {
                fan.SetActive(true);
            }
            else if(!fanObtained)
            {
                fan.SetActive(false);
            } 
        }

        //restocking inventory for new scene
        // images = GameObject.FindGameObjectsWithTag("Images");
        // foreach(GameObject image in images)
        // {
        //     bool gotSprite = false;
        //     Image icon = image.GetComponent<Image>();
        //     if(icon.enabled && !gotSprite)
        //     {
        //         icons.Add(icon.sprite);
        //         gotSprite = true;
        //     }
        // }

        
    }
}

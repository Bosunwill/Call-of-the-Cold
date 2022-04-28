using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemControl : MonoBehaviour
{
    //this script is for controlling the cassette player and handheld fan images

    public bool fanObtained = false;
    public bool casObtained = false;

    public GameObject cassettePlayer;
    public GameObject fan;

    public GameObject notif;

    public Animator casAnim;
    public Animator fanAnim;

    void Start()
    {
        cassettePlayer = GameObject.Find("Cassette");
        fan = GameObject.Find("Handheld fan");
        fan.SetActive(false);
        cassettePlayer.SetActive(false);
        notif = GameObject.Find("Notifs");
        casAnim = cassettePlayer.GetComponent<Animator>();
        fanAnim = fan.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(casObtained)
        {
            cassettePlayer.SetActive(true);
        }
        if(fanObtained)
        {
            fan.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    //This script holds the cassette audioclips
    //The Inventory Slot script searches through this one to find the specific clip needed
    public AudioClip cas1;
    public AudioClip cas2;
    public AudioClip cas3;

    public AudioClip added;

    public AudioClip fanSound;
    public AudioSource audi;


    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Play1()
    {
        audi.PlayOneShot(cas1);
    }
    public void Play2()
    {
        audi.PlayOneShot(cas2);
    }
    public void Play3()
    {
        audi.PlayOneShot(cas3);
    }

    public void Play4()
    {
        audi.PlayOneShot(added);
    }

    public void PlayFan()
    {
        audi.PlayOneShot(fanSound);
    }
}

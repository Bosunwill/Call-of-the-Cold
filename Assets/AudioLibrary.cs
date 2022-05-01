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

    public string cas1Text;
    public string cas2Text;
    public string cas3Text;

    
    [Range(0f, 1f)]
    public float addedVol = 0.5f;
    public AudioClip added;

    public AudioClip fanSound;
    public AudioSource audi;


    void Start()
    {
        audi = GetComponent<AudioSource>();
        cas1Text = "The human lifespan is so finite. So many discoveries could be made with just a little more time! If only there was someway to extend one's lifespan...";
        cas2Text = "I don't think the director's idea is feasible. I can't bring it up to him because anybody that says it's dangerous gets fire on the spot. Guess it's back to work...";
        cas3Text = "I think my cure for mortality is almost complete! However I have noticed some undesirable side effects among my experiments. The... distastful side effects seems to be spreading among the groups. Even i haven't been feelling up to par. May this not be the last the world hears from Victor Asimov";
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
        audi.PlayOneShot(added, addedVol);
    }

    public void PlayFan()
    {
        audi.PlayOneShot(fanSound);
    }
}

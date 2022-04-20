using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    public AudioClip cas1;
    public AudioClip cas2;
    public AudioClip cas3;

    public AudioClip added;
    public AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
}

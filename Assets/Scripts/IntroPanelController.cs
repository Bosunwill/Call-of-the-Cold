using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPanelController : MonoBehaviour
{
    // A simple script to control my buttons for the Tutorial Posters - by Emily

    public Animator anim;
    
    public void Next()
    {
        anim.SetTrigger("Next");
    }

    public void Back()
    {
        anim.SetTrigger("Back");
    }
    public void Close()
    {
        anim.SetTrigger("Close");
    }
}

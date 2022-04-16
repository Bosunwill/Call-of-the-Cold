using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    void Awake()
    {

        // Saves items with this tag so UI doesn't get destroyed
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ui");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

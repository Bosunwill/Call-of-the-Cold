using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterScript2 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Destroy(this.gameObject);
        }
    }
}

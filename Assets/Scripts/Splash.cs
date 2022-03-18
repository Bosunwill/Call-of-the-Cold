using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{

    // Start is called before the first frame update
    void Update()
    {
      StartCoroutine(splash());   
    }
    IEnumerator splash()
    {
            if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            yield return new WaitForSeconds(10);
            SceneManager.LoadScene("Menu");
        }
    }
}

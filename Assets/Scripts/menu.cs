using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{   
    bool enter = false;
    List<string> Einventory = new List<string>{"isCassette1", "isCassette1", "isCassette2"};
    public void GamePlay ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void LateUpdate()
    {
        Content();
    }

    void OnTriggerEnter(Collider other)
    {
        if (enter == true)
        {
             SceneManager.LoadScene(2);
        }
       
    }

    void Content()
    {
        Debug.Log("Content is called");
        for (int j = 0; j < Einventory.Count; ++j) 
        {
            Debug.Log("I search Inventory");
            if (Einventory[j] == "isCassette1")
            {
                ++j;
                if (j == 1)
                {
                    enter = true;
                    this.GetComponent<Collider>().isTrigger = true;
                    Debug.Log("I have an Item");
                }
                else
                {
                    enter = false;
                }
            }

        }
    }

    public void EndGame ()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}

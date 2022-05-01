using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneNumber;
    
private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Loading Next Scene");
        SceneManager.LoadScene(sceneBuildIndex: sceneNumber);
    }


}

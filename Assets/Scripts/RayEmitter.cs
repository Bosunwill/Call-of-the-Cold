using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEmitter : MonoBehaviour
{
    public bool canSeePlayer;
    public Transform Player, rayEmitter;
    public float fieldOfView = 60;
    private RaycastHit hit;
    private Renderer rend; 

    // Start is called before the first frame update
    void Start()
    {
    rend = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayDirection = Player.position - this.transform.position;
        float angle = Vector3.Angle(rayDirection, transform.forward);

        if(Physics.Raycast(rayEmitter.position, transform.forward, out hit))
        {
            if(hit.collider.CompareTag("Player"))
            {
                rend.material.color = Color.red;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.red, 1);
            }
            if(angle < fieldOfView) canSeePlayer = true;
            Debug.DrawRay(this.transform.position, transform.forward * 5);
            Debug.DrawRay(this.transform.position, rayDirection, angle < fieldOfView
            ? Color.green : Color.red);
            Debug.Log("Angle to player: " + angle);
        }
    }
}

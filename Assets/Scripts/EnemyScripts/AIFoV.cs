using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFoV : MonoBehaviour
{
    public Transform player;
    public float fieldOfView = 45;
    public Transform emitter;

    //public Renderer rend;

    public bool canSeePlayer = false;

    public float sightDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (emitter == null) emitter = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 rayDirection = (player.position + Vector3.up) - emitter.position;

        Vector3 endVector = Quaternion.AngleAxis(fieldOfView, Vector3.up) * emitter.forward * 10;
        Debug.DrawRay(emitter.position, endVector, Color.magenta);

        Vector3 endVector2 = Quaternion.AngleAxis(-fieldOfView, Vector3.up) * emitter.forward * 10;
        Debug.DrawRay(emitter.position, endVector2, Color.magenta);


        float angle = Vector3.Angle(rayDirection, emitter.forward);

        if (angle < fieldOfView)
        {
            // draw a ray
            if (Physics.Raycast(emitter.position, rayDirection, out hit, sightDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    canSeePlayer = true;
                    Debug.DrawRay(emitter.position, rayDirection, Color.green);
                    //rend.material.color = Color.green;
                }
                else
                {
                    canSeePlayer = false;
                    Debug.DrawRay(emitter.position, rayDirection, Color.red);
                    //end.material.color = Color.red;
                }
            }
            else
            {
                canSeePlayer = false;
                // if the AI sees nothing because the player is too far away, be gray.
                //rend.material.color = Color.gray;
                Debug.DrawRay(emitter.position, rayDirection, Color.cyan);
            }
        }
        else
        {
            canSeePlayer = false;
            // if the AI cannot see me because I am out of it's field of view, be gray.
           // rend.material.color = Color.gray;
            Debug.DrawRay(emitter.position, rayDirection, Color.cyan);
        }

    }
}

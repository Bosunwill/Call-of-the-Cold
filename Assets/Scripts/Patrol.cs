using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour
{
    public Transform[] points;
    public Transform Goal;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private float minDistance = 10;
    private float pos;

    public RayEmitter eye;

    // Start is called before the first frame update
    void Start()
    {
     agent = GetComponent<NavMeshAgent>();
     agent.autoBraking = false;

     GotoNextPoint();   
    }

    void GotoNextPoint(){
        if (points.Length == 0)
        return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }    

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        GotoNextPoint();
        Debug.Log("Distance to Player: " + Vector3.Distance(this.transform.position, 
        Goal.transform.position));
        pos = Vector3.Distance(this.transform.position, Goal.transform.position);
        if(eye.canSeePlayer && pos < minDistance){
            agent.destination = Goal.position;
        } else
        {
            eye.canSeePlayer = false;
            agent.destination = points[destPoint].position;
        }

    }
}

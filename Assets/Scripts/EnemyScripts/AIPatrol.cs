// Patrol.cs
using UnityEngine;
using UnityEngine.AI;                   // for NavMeshAgent
using System.Collections;               // for IEnumerator
using System.Collections.Generic;       // for lists

[RequireComponent(typeof(AIFoV))]
public class AIPatrol : MonoBehaviour
{

    public Transform[] points;
    public float reactionTime = 1;      // how long can we see the player before springing into action.

    public enum state { Patrolling, Chasing, Searching };
    public state currentState = state.Patrolling;

    private int destPoint = 0;
    private NavMeshAgent agent;

    private AIFoV fov;
    bool waitingAtPoint = false;
    public float waitAtPointInterval = 2f;

    //Animator Booleans

    public Animator anim;
    public bool isMoving = false;
    public bool isSearching = false;
    
    IEnumerator wait;

    state lastFrameState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<AIFoV>();

        lastFrameState = currentState;

        //anim.SetFloat("isMoving", isMoving);
        //anim.SetBool("isSearching", isSearching);
        //anim.SetBool();
        wait = WaitAtPatrolPoint();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        // agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        isMoving = true;

        currentState = state.Patrolling;

    }

    private float eyesOnPlayerTimer = 0;

    void Patrolling()
    {
        LookForPlayer();

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {

            currentState = state.Searching;       // this is searching
                                                  // go to the searching state.
        }
    }

    void Chasing()
    {

        agent.destination = fov.player.position;
        float distance = Vector3.Distance(this.transform.position, fov.player.position);
        if (distance > fov.sightDistance)
        {

            currentState = state.Patrolling;
        }
    }


    void Searching()
    {

        if (!waitingAtPoint)
        {
            wait = WaitAtPatrolPoint();
            StartCoroutine(wait);

        }

       // LookForPlayer();

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentState = state.Searching;       // this is searching
                                                  // go to the searching state.
        }
    }

    void LookForPlayer()
    {
        if (fov.canSeePlayer == true)
        {
            eyesOnPlayerTimer += Time.deltaTime;
            if (eyesOnPlayerTimer > reactionTime * .01f)
            {
                currentState = state.Chasing;
                eyesOnPlayerTimer = 0;
                StopCoroutine(wait);
                //wait = null;
               // eyePivot.rotation = looks[0].rotation;
                waitingAtPoint = false;
                return;     // don't look at anything else in the Update function.
            }
        }else
        {


            //reset the eyesOnPlayerTimer if we lose sight of the player.
            // this is stupid code, I need to change it.
            eyesOnPlayerTimer = 0;
        }
    }

    void Update()
    {          
        switch (currentState)
        {
            case state.Patrolling: Patrolling(); break;
            case state.Chasing: Chasing(); break;
            case state.Searching: Searching(); break;
        }


        if (lastFrameState != currentState)
        {
            Debug.Log("State has changed to " + currentState);

        }

        lastFrameState = currentState;

        Debug.Log("The doctor is moving " + isMoving + " And is searching" + isSearching);

    }

    //public Transform eyePivot;
    public AnimationCurve curve;
   // public List<Transform> looks = new List<Transform>();

    IEnumerator WaitAtPatrolPoint()
    {
        waitingAtPoint = true;
        isMoving = false;
        //yield return new WaitForSeconds(1);
        float timer = 0;
        while (timer < 1)
        {
           // eyePivot.rotation = Quaternion.Lerp(looks[0].rotation, looks[1].rotation, curve.Evaluate(timer));
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        timer = 0;
        while (timer < 1)
        {
           // eyePivot.rotation = Quaternion.Lerp(looks[1].rotation, looks[2].rotation, curve.Evaluate(timer));
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);


        timer = 0;
        while (timer < 1)
        {
            //eyePivot.rotation = Quaternion.Lerp(looks[2].rotation, looks[0].rotation, curve.Evaluate(timer));
            timer += Time.deltaTime;
            yield return null;
        }


        GotoNextPoint();
        waitingAtPoint = false;

    }
}
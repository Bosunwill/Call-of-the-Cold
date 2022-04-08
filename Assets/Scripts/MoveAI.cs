using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAI : MonoBehaviour
{
    public Transform Goal;
    NavMeshAgent agent;

    //public animator for accessing the parameters for animation
    public Animator animEnemy;
    public SpriteRenderer enemySR;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        agent.destination = Goal.position;
        // Code for animating the enemy
        animEnemy.SetBool("enemyMovement", true);

        if (!enemySR.flipX && Goal.position.x > 0)
        {
            enemySR.flipX = true;
        } else if (enemySR.flipX && Goal.position.x < 0){ 
            enemySR.flipX = false;
        }
    }
    
}


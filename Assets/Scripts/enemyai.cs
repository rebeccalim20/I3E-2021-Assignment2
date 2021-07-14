/******************************************************************************
Author: 

Name of Class: enemyai

Description of Class: This class will control the movement of the enemy 

Date Created: 15/7/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
    Transform target;

    NavMeshAgent agent;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance >2)
        {
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            agent.updatePosition = false;
            anim.SetBool("isWalking",false);
            anim.SetBool("isAttacking", true);
        }
    }
}

/******************************************************************************
Author: 

Name of Class: EnemySpawn

Description of Class: Randomly spawn enemies (Zombies)

Date Created: 15/07/2021

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public Transform[] spawnPoints;
    BoxCollider trigger;



    [SerializeField] float repeatRate=0.1f;
   

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("SpawnEnemies", 0.5f, repeatRate);
            Destroy(gameObject, 11f);
            trigger.enabled = false;
        }
    }



    void SpawnEnemies()
    {
        foreach (var sp in spawnPoints)
        {
            Instantiate(enemyToSpawn, sp.position, sp.rotation);
        }
    }

    
}

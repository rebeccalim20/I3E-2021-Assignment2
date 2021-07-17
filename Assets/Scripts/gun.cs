/******************************************************************************
Author:

Name of Class: gun

Description of Class:shoots the enemy scans 

Date Created: 9/7/2021
******************************************************************************/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the ammo is greater than  0

        if(GameManager.ammoleft>0)
        {
            if (Input.GetButtonDown("Fire1"))
            {   
                //deduct ammo by 2
                GameManager.ammoleft -= 2;
                Shoot();
            }

        }
    }

    void Shoot()
    {
        //play particle systems
        muzzleFlash.Play();


        RaycastHit hit;
        

        if (Physics.Raycast(fpscam.transform.position,fpscam.transform.forward,out hit ,range))
        {
            
            enemyhealth target = hit.transform.GetComponent<enemyhealth>();
            
            //check if the target is not null
            if(target !=null)
            {
                target.takedamange(damage);
            }
        }
        

    }

}

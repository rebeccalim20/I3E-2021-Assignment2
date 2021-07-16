/******************************************************************************
Author: 

Name of Class: enemyai

Description of Class: enemy health scripting and infos 

Date Created: 15/7/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyhealth : MonoBehaviour
{
    public float enemyhealthpt = 50f;
    public GameObject enemyhealthtxt;
    

    private void Start()
    {
        enemyhealthpt = 50f;
        enemyhealthtxt.GetComponent<TextMeshPro>().text = enemyhealthpt.ToString();
    }
    private void Update()
    {
        
    }

    public void takedamange(float amount )
    {
        enemyhealthpt -= amount;
        enemyhealthtxt.GetComponent<TextMeshPro>().text = enemyhealthpt.ToString();
        if (enemyhealthpt <=0f)
        {
            die();
        }

       
    }
   void die ()
    {
        Destroy(gameObject);
    }
}

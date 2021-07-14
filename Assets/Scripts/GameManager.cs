/******************************************************************************
Author:  

Name of Class: GameManager

Description of Class: mainly keeps tracks of the game and for multiple scene and 
levels stores the player and enemy infos

Date Created: 9/7/2021
******************************************************************************/




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text Healthtxt;
    public Text Cointxt;
    public Text Ammotxt;
    
    //playerhealth
    public int playerhealth =10;

    // Start is called before the first frame update
    void Start()
    {
        Healthtxt = GameObject.Find("Healthtxt").GetComponent<Text>();
        Healthtxt.text = " Health:" +playerhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

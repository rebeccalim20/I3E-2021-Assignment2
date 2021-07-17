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
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text playerHealthtxt;
    public Text Cointxt;
    public Text Ammotxt;
    
    //playerhealth
    public static float playerhealth =100;
    public static float coincollect=0;
    public static float ammoleft = 20;
    public static float key = 0;


    public static int countenemy;
    public static GameObject pistol;

    /// <summary>
    /// Quest text ui update
    /// </summary>
    public Text quest1;
    public Text quest2;
    public Text quest3;
    public Text quest4;
    public Text quest5;


    // Start is called before the first frame update
    void Start()
    {
        playerhealth = 100;
        coincollect = 0;
        ammoleft = 20;
        key = 0;
        playerHealthtxt = GameObject.Find("playerHealthtxt").GetComponent<Text>();
        pistol = GameObject.Find("/Player/Main Camera/pistol"); ;
        pistol.SetActive(false);

        quest1.text = " Quest 1 : collect  the  coins";
        quest2.text = " Quest 2 : collect key ";
        quest3.text = " Quest 3: Pickup gun";
        quest4.text = " Quest 4: Kill the zombies ";
        quest5.text = " Quest 5 :kill the boss";

    }

    // Update is called once per frame
    void Update()
    {
        //update health and some pickups for the ui 

        playerHealthtxt.text = " Health:" +playerhealth;
        Cointxt.text = " Coins:" + coincollect;
        Ammotxt.text = " Ammo left :" + ammoleft;
        playerdeath();

        if (ammoleft <= 0)
        {
            ammoleft = 0;
        }
        //check if the coin is greater than 50 

        if (coincollect >=50)
        {
            quest1.text = " Quest 1 : collect  the  coins ( complete)" ;
        }
        if (key >= 1)
        {
            quest2.text = " Quest 2 : collect key  ( complete)";
            
        }
        //check if the pistol is set active 

        if(pistol.activeInHierarchy ==true)
        {
            quest3.text = " Quest 3: Pickup gun (complete)";
        }
        Debug.Log(countenemy);
        if(countenemy >=60)
        {
            quest4.text = " Quest 4: Kill the zombies (complete) ";
        }

    }



    void playerdeath()
    {
        //set text to zero less than zero

        if (playerhealth <= 0)
        {
            playerhealth = 0;
            SceneManager.LoadScene("Lose");


        }

    }

}

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
    
    //ui text for added on the ui
    public Text playerHealthtxt;
    public Text Cointxt;
    public Text Ammotxt;
    
    //players stats
    public static float playerhealth =100;
    public static float coincollect=0;
    public static float ammoleft = 20;
    public static float key = 0;

    //Check count enemy 
    public static int countenemy;

    //get the pistol gameobject
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

        //on start the game set the int/float to respective 

        playerhealth = 100;
        coincollect = 0;
        ammoleft = 20;
        key = 0;

        //find the game object
        playerHealthtxt = GameObject.Find("playerHealthtxt").GetComponent<Text>();
        pistol = GameObject.Find("/Player/Main Camera/pistol"); ;
        pistol.SetActive(false);


        //set the text to respective text 
        quest1.text = " Quest 1 : collect  the  coins";
        quest2.text = " Quest 2 : collect key ";
        quest3.text = " Quest 3: Pickup gun";
        quest4.text = " Quest 4: Kill the zombies ";
        quest5.text = " Quest 5 :kill the boss";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            pistol.SetActive(true);
        }
            //update health and some pickups for the ui 

            playerHealthtxt.text = " Health:" +playerhealth;
        Cointxt.text = " Coins:" + coincollect;
        Ammotxt.text = " Ammo left :" + ammoleft;
        playerdeath();


        //check if ammo is left than 0 and set the ammo to 0
        if (ammoleft <= 0)
        {
            ammoleft = 0;
        }
        //check if the coin is greater than 50 

        if (coincollect >=50)
        {
            quest1.text = " Quest 1 : collect  the  coins ( complete)" ;
        }
        //check the coin key is greater than 1

        if (key >= 1)
        {
            quest2.text = " Quest 2 : collect key  ( complete)";
            
        }
        //check if the pistol is set active 

        if(pistol.activeInHierarchy ==true)
        {
            quest3.text = " Quest 3: Pickup gun (complete)";
        }

       /* Debug.Log(countenemy);*/
        
        //count the enemy points
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

            //load the scene
            SceneManager.LoadScene("Lose");
        }

    }

}

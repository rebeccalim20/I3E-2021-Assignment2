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
    public static int playerhealth =100;
    public static float coincollect=0;
    public static float ammoleft = 20;

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
        playerHealthtxt = GameObject.Find("playerHealthtxt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthtxt.text = " Health:" +playerhealth;
        Cointxt.text = " Coins:" + coincollect;
        Ammotxt.text = " Ammo left :" + ammoleft;
        playerdeath();
        if(coincollect >=50)
        {
            quest1.text = " Quest 1 : collect  the  coins ( complete)" ;
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

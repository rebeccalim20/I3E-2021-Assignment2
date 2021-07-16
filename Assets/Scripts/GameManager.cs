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
        Ammotxt.text = " Coins:" + ammoleft;
        playerdeath();

        

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

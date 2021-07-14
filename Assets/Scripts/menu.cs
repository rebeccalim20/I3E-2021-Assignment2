/******************************************************************************
Author: 

Name of Class: Menu 

Description of Class: menu script mainly load the games and menu scripts.

Date Created: 9/7/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class menu : MonoBehaviour
{
    //load menu 
    public void loadmenu(string menu)
    {
        SceneManager.LoadScene("menu");
    }

    //Load level1
    
    //Load level2
    public void gamescene(string gamescene)
    {
        SceneManager.LoadScene("gamescene");
    }

    //quit game exit
    public void ExitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
       
    }
}

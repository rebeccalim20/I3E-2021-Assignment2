/******************************************************************************
Author: 

Name of Class: Menu 

Description of Class: menu script mainly load the games and menu scripts and quit game.

Date Created: 9/7/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class menu : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip hoversound;
    public AudioClip clicksound;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (SamplePlayer.lockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void hoversounds()
    {
        audiosource.PlayOneShot(hoversound,0.7F);
    }
    public void clicksounds()
    {
        audiosource.PlayOneShot(clicksound, 0.7F);
    }


    //load menu 
    public void loadmenu(string menu)
    {
        SceneManager.LoadScene("menu");
    }

    //Load gamescene
    
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

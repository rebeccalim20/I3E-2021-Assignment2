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
        Application.Quit();
        /* Debug.Log("works");*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

     public void LoadGame(string name)
    {
        SceneManager.LoadScene(name); 
    }

     public void ExitGame()
    {
        Application.Quit();
    } 

}

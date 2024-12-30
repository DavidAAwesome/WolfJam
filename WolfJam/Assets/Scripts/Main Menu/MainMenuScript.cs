using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour 
{
    

    public void Play()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit ()
    {
        Application.Quit();
        Debug.Log("User has quit the game");
    }

    public void GoToMainMenu()
    {
        // Load the first scene (main menu)
        SceneManager.LoadScene(0); 
    }

}

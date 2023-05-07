using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public static bool _optionMenu = false;
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //move to Endless
    }

    //do option setting in unity

    public void QuitGame() {
        Application.Quit(); 
        Debug.Log("Quitting Game...");
    }
}

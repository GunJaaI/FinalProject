using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasueMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    //private bool a = true;

    // Update is called once per frame
    void Update() {
            if (GameIsPaused == true) {
                Pasue();
                //Resume();
                Debug.Log("Game is Resume.");
            } else {
                Resume();
                //Pasue();
                //Debug.Log("Game is Pause.");
            }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pasue() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu...");
    }

    public void QuitGame() {
        Application.Quit(); 
        Debug.Log("Quitting Game...");
    }
}

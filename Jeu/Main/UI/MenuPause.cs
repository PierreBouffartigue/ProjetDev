using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()  {
        // Si on appuie sur échap
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Si le jeu est en pause
            if (GameIsPaused) {
                // Reprendre le jeu
                Resume();
            } else {
                // Sinon le mettre en pause
                Pause();
            }
        }
    }

    public void Resume (){
        // Enlever l'affichage du menu pause
        pauseMenuUI.SetActive(false);
        // Vitesse du jeu normale
        Time.timeScale = 1f;
        // Définie le jeu comme n'étant pas en pause
        GameIsPaused = false;
    }

    void Pause () {
        // Affiche le menu pause
        pauseMenuUI.SetActive(true);
        // Vitesse du jeu à 0 (en pause)
        Time.timeScale = 0f;
        // Définie le jeu comme étant en pause
        GameIsPaused = true;
    }

    public void LoadMenu(){
        // Charge la scene de login
        SceneManager.LoadScene("Login");
    }

    public void ResumeGame(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}

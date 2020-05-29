using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchMenu : MonoBehaviour {
    public void LoadScene(string ScenePrincipale)
    {
        // Charge la scene principale
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        // Quitte le jeu
        Application.Quit();
    }
}

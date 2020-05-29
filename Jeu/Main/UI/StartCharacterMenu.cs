using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartCharacterMenu : MonoBehaviour
{
    public GameObject StartMenuPerso;
    public Button BoutonChoixPerso;

    void Start()
    {
        // Récupère le bouton choixperso et l'écoute
        Button bth = BoutonChoixPerso.GetComponent<Button>();
        StartMenuPerso.SetActive(false);
        bth.onClick.AddListener(StartMenu);
        bth.enabled = true;
    }

    // Quan lebouton est cliqué
    void StartMenu()
    {
        // Désactive le bouton
        Button bth = BoutonChoixPerso.GetComponent<Button>();
        StartMenuPerso.SetActive(true);
        bth.onClick.AddListener(StartMenu);
        bth.enabled = false;
    }
}

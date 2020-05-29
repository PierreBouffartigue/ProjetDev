using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUserInfos : MonoBehaviour
{
    public GameObject NameDisplay;
    public GameObject MoneyDisplay;

    public GameObject CavalryDisplay;
    public GameObject SpearDisplay;
    public GameObject BowDisplay;

    void Update()
    {
        // Affiche le nom du joueur
        NameDisplay.GetComponent<Text>().text = PlayerStats.user;
        // Affiche l'argent du joueur
        MoneyDisplay.GetComponent<Text>().text = "Pieces: " + PlayerStats.money;

        // Affiche le nombre de cavaliers
        CavalryDisplay.GetComponent<Text>().text = PlayerStats.CavalryTroops.ToString();
        // Affiche le nombre de lanciers
        SpearDisplay.GetComponent<Text>().text = PlayerStats.SpearTroops.ToString();
        // Affiche le nombre d'archers
        BowDisplay.GetComponent<Text>().text = PlayerStats.BowTroops.ToString();
    }
}

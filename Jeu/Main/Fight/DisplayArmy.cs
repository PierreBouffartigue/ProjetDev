using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayArmy : MonoBehaviour
{
    // Savoir si c'est le joueur ou l'ennemie
    public int Fighter = 0;
    public GameObject NameDisplay;
    public GameObject CavalryDisplay;
    public GameObject SpearDisplay;
    public GameObject BowDisplay;

    void Start()
    {
        switch (Fighter)
        {
            // Si c'est le joueur
            case 0:
                // Affiche le nom du joueur
                NameDisplay.GetComponent<Text>().text = PlayerStats.user;
                break;
            // Si c'est l'ennemie
            case 1:
                // Affiche "Enemy"
                NameDisplay.GetComponent<Text>().text = "Enemy";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (Fighter)
        {
            // Si c'est le joueur
            case 0:
                // Affiche le nombre pour chaque troupes du joueur
                CavalryDisplay.GetComponent<Text>().text = PlayerStats.CavalryTroops.ToString();
                SpearDisplay.GetComponent<Text>().text = PlayerStats.SpearTroops.ToString();
                BowDisplay.GetComponent<Text>().text = PlayerStats.BowTroops.ToString();
                break;
            // Si c'est l'ennemie
            case 1:
                // Affiche le nombre pour chaque troupes de l'ennemie
                CavalryDisplay.GetComponent<Text>().text = EnemyStats.CavalryTroops.ToString();
                SpearDisplay.GetComponent<Text>().text = EnemyStats.SpearTroops.ToString();
                BowDisplay.GetComponent<Text>().text = EnemyStats.BowTroops.ToString();
                break;
        }
    }
}

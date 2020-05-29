using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDisplay : MonoBehaviour
{
    public GameObject PCCText, PCSText, PCBText, ECCText, ECSText, ECBText;

    void Update()
    {
        // Affiche du nobre de troupes pour chaque type d'armée du joueur et l'ennemie
        PCCText.GetComponent<Text>().text = PlayerStats.CavalryTroops.ToString();
        PCSText.GetComponent<Text>().text = PlayerStats.SpearTroops.ToString();
        PCBText.GetComponent<Text>().text = PlayerStats.BowTroops.ToString();
        ECCText.GetComponent<Text>().text = EnemyStats.CavalryTroops.ToString();
        ECSText.GetComponent<Text>().text = EnemyStats.SpearTroops.ToString();
        ECBText.GetComponent<Text>().text = EnemyStats.BowTroops.ToString();
    }
}

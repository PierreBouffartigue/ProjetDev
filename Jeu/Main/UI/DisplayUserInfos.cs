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

    void Start()
    {
        
    }

    void Update()
    {
        NameDisplay.GetComponent<Text>().text = PlayerStats.user;
        MoneyDisplay.GetComponent<Text>().text = "Pieces: " + PlayerStats.money;

        CavalryDisplay.GetComponent<Text>().text = PlayerStats.CavalryTroops.ToString();
        SpearDisplay.GetComponent<Text>().text = PlayerStats.SpearTroops.ToString();
        BowDisplay.GetComponent<Text>().text = PlayerStats.BowTroops.ToString();
    }
}

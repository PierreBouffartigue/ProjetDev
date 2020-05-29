using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayArmy : MonoBehaviour
{
    public int Fighter = 0;
    public GameObject NameDisplay;
    public GameObject CavalryDisplay;
    public GameObject SpearDisplay;
    public GameObject BowDisplay;

    void Start()
    {
        switch (Fighter)
        {
            case 0:
                NameDisplay.GetComponent<Text>().text = PlayerStats.user;
                break;
            case 1:
                NameDisplay.GetComponent<Text>().text = "Enemy";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (Fighter)
        {
            case 0:
                CavalryDisplay.GetComponent<Text>().text = PlayerStats.CavalryTroops.ToString();
                SpearDisplay.GetComponent<Text>().text = PlayerStats.SpearTroops.ToString();
                BowDisplay.GetComponent<Text>().text = PlayerStats.BowTroops.ToString();
                break;
            case 1:
                CavalryDisplay.GetComponent<Text>().text = EnemyStats.CavalryTroops.ToString();
                SpearDisplay.GetComponent<Text>().text = EnemyStats.SpearTroops.ToString();
                BowDisplay.GetComponent<Text>().text = EnemyStats.BowTroops.ToString();
                break;
        }
    }
}

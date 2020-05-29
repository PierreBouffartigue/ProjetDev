using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IABatiments : MonoBehaviour
{
    public GameObject Forge;
    public GameObject BatimentEnnemi1;
    public GameObject BatimentEnnemi2;

    void Start()
    {
        BatimentEnnemi1.SetActive(false);
        BatimentEnnemi2.SetActive(false);
        Forge.SetActive(false);
    }

    void Update(){
        if (PlayerStats.money >= 6){
            BatimentEnnemi1.SetActive(true);
        }
        if(PlayerStats.money >= 8){
            Forge.SetActive(true);
        }
        if(PlayerStats.money >= 10){
            BatimentEnnemi1.SetActive(true);
        }
    }
}

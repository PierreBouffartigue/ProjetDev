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
		//Desactive les différents batiments
        BatimentEnnemi1.SetActive(false);
        BatimentEnnemi2.SetActive(false);
        Forge.SetActive(false);
    }

    void Update(){
		//si l'argent du joueur atteint 6 ou plus
        if (PlayerStats.money >= 6){
			//fait apparaitre le premier batiment
            BatimentEnnemi1.SetActive(true);
        }
		//si l'argent du joueur atteint 8 ou plus
        if(PlayerStats.money >= 8){
			//fait apparaitre la forge
            Forge.SetActive(true);
        }
		//si l'argent du joueur atteint 10 ou plus
        if(PlayerStats.money >= 10){
			//fait apparaitre le deuxieme batiment
            BatimentEnnemi1.SetActive(true);
        }
    }
}

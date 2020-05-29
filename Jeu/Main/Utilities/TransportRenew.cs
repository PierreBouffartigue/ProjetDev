using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TransportRenew : MonoBehaviour
{
    public GameObject VillagePrincipal;
    public GameObject VillageEnnemi;
    public GameObject ChampBataille;
    public Button TransportEnnemi;
    public Button TransportBataille;
    public Button TransportVillage;

    void Start()
    {
    	// Affiche le village du joueur et désactive le village ennemie et le champ de bataille
        VillagePrincipal.SetActive(true);
        VillageEnnemi.SetActive(false);
        ChampBataille.SetActive(false);
	// Récupération et écoute des trois boutons de déplacement
        Button btt = TransportEnnemi.GetComponent<Button>();
	btt.onClick.AddListener(Ennemi);
        Button bty = TransportBataille.GetComponent<Button>();
	bty.onClick.AddListener(Bataille);
        Button btu = TransportVillage.GetComponent<Button>();
	btu.onClick.AddListener(Village);
    }

    // Quand le boutin transportennemie est cliqué
    void Ennemi()
    {
    	// Affiche le village ennemie et désactive les autres
        VillagePrincipal.SetActive(false);
        VillageEnnemi.SetActive(true);
        ChampBataille.SetActive(false);
    }

    // Quand le boutin transportbataille est cliqué
    void Bataille()
    {
    	// Affiche le champ de bataille et désactive les autres
        VillagePrincipal.SetActive(false);
        VillageEnnemi.SetActive(false);
        ChampBataille.SetActive(true);
    }

    // Quand le boutin transportvillage est cliqué
    public void Village()
    {
    	// Affiche le village du joueur et désactive les autres
        VillagePrincipal.SetActive(true);
        VillageEnnemi.SetActive(false);
        ChampBataille.SetActive(false);
    }
}

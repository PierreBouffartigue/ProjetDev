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
        VillagePrincipal.SetActive(true);
        VillageEnnemi.SetActive(false);
        ChampBataille.SetActive(false);
        Button btt = TransportEnnemi.GetComponent<Button>();
		btt.onClick.AddListener(Ennemi);
        Button bty = TransportBataille.GetComponent<Button>();
		bty.onClick.AddListener(Bataille);
        Button btu = TransportVillage.GetComponent<Button>();
		btu.onClick.AddListener(Village);
    }

    void Ennemi()
    {
        VillagePrincipal.SetActive(false);
        VillageEnnemi.SetActive(true);
        ChampBataille.SetActive(false);
    }

    void Bataille()
    {
        VillagePrincipal.SetActive(false);
        VillageEnnemi.SetActive(false);
        ChampBataille.SetActive(true);
    }

    public void Village()
    {
        VillagePrincipal.SetActive(true);
        VillageEnnemi.SetActive(false);
        ChampBataille.SetActive(false);
    }
}

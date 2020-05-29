using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterChoice : MonoBehaviour {
    	public GameObject ChoixPersoObject;
	public Button BoutonChoixHomme;
    	public Button BoutonChoixFemme;
	[SerializeField] private Image iconHomme;
    	[SerializeField] private Image iconFemme;
    	[SerializeField] private Image choixHomme;
    	[SerializeField] private Image choixFemme;

	void Start () {
		// Affiche les 2 images de coix
		choixFemme.enabled = true;
        	choixHomme.enabled = true;
		// Cache les 2 icons
        	iconHomme.enabled = false;
        	iconFemme.enabled = false;
		// Récuperation des boutons
		Button btv = BoutonChoixHomme.GetComponent<Button>();
        	Button btc = BoutonChoixFemme.GetComponent<Button>();
		// Ecoute les boutons
		btc.onClick.AddListener(HommeBouton);
        	btv.onClick.AddListener(FemmeBouton);
	}

	// Quand le bouton homme est cliqué
	void HommeBouton() {
		// Enlève les images de choix
		choixFemme.enabled = false;
		choixHomme.enabled = false;
		// Affiche l'icon homme
		iconHomme.enabled = false;
		iconFemme.enabled = true;
		// Récupère les boutons pour les désactiver
		Button btv = BoutonChoixHomme.GetComponent<Button>();
		Button btc = BoutonChoixFemme.GetComponent<Button>();
		btv.enabled = false;
		btc.enabled = false;
		ChoixPersoObject.SetActive(false);
	}
	// Quand le bouton homme est cliqué
    	void FemmeBouton() {
		// Enlève les images de choix
		choixFemme.enabled = false;
		choixHomme.enabled = false;
		// Affiche l'icon femme
		iconHomme.enabled = true;
		iconFemme.enabled = false;
		// Récupère les boutons pour les désactiver
		Button btv = BoutonChoixHomme.GetComponent<Button>();
		Button btc = BoutonChoixFemme.GetComponent<Button>();
		btv.enabled = false;
		btc.enabled = false;
		ChoixPersoObject.SetActive(false);
    	}
}

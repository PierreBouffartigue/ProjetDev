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
		choixFemme.enabled = true;
        choixHomme.enabled = true;
        iconHomme.enabled = false;
        iconFemme.enabled = false;
		Button btv = BoutonChoixHomme.GetComponent<Button>();
        Button btc = BoutonChoixFemme.GetComponent<Button>();
		btc.onClick.AddListener(HommeBouton);
        btv.onClick.AddListener(FemmeBouton);
	}

	void HommeBouton() {
        choixFemme.enabled = false;
        choixHomme.enabled = false;
        iconHomme.enabled = false;
        iconFemme.enabled = true;
        Button btv = BoutonChoixHomme.GetComponent<Button>();
        Button btc = BoutonChoixFemme.GetComponent<Button>();
        btv.enabled = false;
        btc.enabled = false;
        ChoixPersoObject.SetActive(false);
	}

    void FemmeBouton() {
        choixFemme.enabled = false;
        choixHomme.enabled = false;
        iconHomme.enabled = true;
        iconFemme.enabled = false;
        Button btv = BoutonChoixHomme.GetComponent<Button>();
        Button btc = BoutonChoixFemme.GetComponent<Button>();
        btv.enabled = false;
        btc.enabled = false;
        ChoixPersoObject.SetActive(false);
    }
}
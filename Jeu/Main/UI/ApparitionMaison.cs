using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ApparitionMaison : MonoBehaviour {

	public GameObject Batiment;
	public Button BoutonPourCacherMaisons;
	[SerializeField] private Image imageacacher;
	public Button BoutonPoursupr;
	public GameObject imageBtnSupr;
	public GameObject Tornade;
	public Button TornadeButton;
	public bool TornadeClicked;
	public int cost = 0;
	public int RandomNumb;

	void Start () {
		//Affichage de l'image du bouton
		imageacacher.enabled = true;

		//Disparition des batiments à construire
		Batiment.SetActive(false);

		//Recuperation de BoutonPourCacherMaisons et la methode TaskOnClick lui est liée
		Button btn = BoutonPourCacherMaisons.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		//Recuperation de BoutonPoursupr et la methode suprOnClick lui est liée
		Button btnSupr = BoutonPoursupr.GetComponent<Button>();
		btnSupr.onClick.AddListener(suprOnClick);

		//On le fait ensuite disparaitre
		imageBtnSupr.SetActive(false);

		//On cache les tornades
		Tornade.SetActive(false);
		
		//Initialisation de la variable TornadeClicked
		TornadeClicked = false;

		//Recuperation de TornadeButton et la methode OnClickTornade lui est liée
		Button btnTornade = TornadeButton.GetComponent<Button>();
		btnTornade.onClick.AddListener(OnClickTornade);

		//On génère ensuite un nombre aléatoire
		RandomNumberGen();
	}
	
	

	//Tâche exécuté lors de l'appui sur le BoutonPourCacherMaison
	void TaskOnClick(){

		//Si joueur a plus d'argent que le prix définit
		if (PlayerStats.money >= cost)
		{
			//Affiche le Batiment
			Batiment.SetActive(true);
			//Cache l'image du bouton
			imageacacher.enabled = false;
			//Réduit l'argent du joueur par rapport au prix du batiment
			PlayerStats.DecreaseMoney(cost);
			//Affiche le bouton pour supprimer le batiment
			imageBtnSupr.SetActive(true);
			//Lance la fonction TornadeOrNot (Evenement aléatoire)
			TornadeOrNot();

		}
		//Sinon
		else
		{
			//Recupere le BoutonPourCacherMaisons et le réactive
			Button btn = BoutonPourCacherMaisons.GetComponent<Button>();
			btn.enabled = true;
			//Envoie un msg de debug 
			Debug.Log("Pas assez d'argent, il faut "+cost+" pièces");
			
		}
	}
	//Tâche exécuté lors de l'appui sur le BoutonPoursupr
	void suprOnClick()
    {
		//si Bouton pour acheter batiment pas affiché
		if(imageacacher.enabled == false)
        {
			//Lance la fonction suprBatiment
			suprBatiment();
			//Redonne de l'argent au joueur
			PlayerStats.IncreaseMoney(2);
			

		}
        
        

    }
	//Fonction Permettant de supprimer les batiments
	void suprBatiment()
    {
		//Cache le batiment
		Batiment.SetActive(false);
		//Raffiche le bouton d'achat
		imageacacher.enabled = true;
		//Récupere BoutonPourCacherMaisons et l'active
		Button btn = BoutonPourCacherMaisons.GetComponent<Button>();
		btn.enabled = true;
		//Cache le bouton de suppression
		imageBtnSupr.SetActive(false);
		//cache la tornade si il y en avait une
		Tornade.SetActive(false);
	}

	// Fonctions pour les Tornades

	//Géneration d'un nombre aléatoire entre 0 et 100 dans la variable RandomNumb
	void RandomNumberGen()
	{
		RandomNumb = UnityEngine.Random.Range(0, 100);
	}

	//Fonctione qui définit si une tornade apparait ou non
	void TornadeOrNot()
	{
		//Si RandomNumb est inferieur à 50
		if (RandomNumb < 50)
		{
			//On démarre une fonction timer
			StartCoroutine(DestOrSurvive());
			//On affiche la tornade
			Tornade.SetActive(true);
			//et on active le TornadeButton 
			Button btnTornade = TornadeButton.GetComponent<Button>();
			btnTornade.enabled = true;


		}
		//Sinon on relance une géneration de nombre aléatoire
		else
		{
			RandomNumberGen();
		}
	}

	//Fonction quand on click sur une tornade
	void OnClickTornade()
    {
		//Passe la variable de false a true se qui veut dire que la tornade à subit un click
		TornadeClicked = true;
    }

	//Fonction avec un Timer qui détruit le batiment au bout d'un certains temps
	IEnumerator DestOrSurvive()
    {
		// On attend 5 secondes
		yield return new WaitForSeconds(5);
		//si la tornade n'a pas été cliqué
		if(TornadeClicked == false)
        {
			//On fait appel a suprBatiment qui supprime le batiment
			suprBatiment();
			//Le TornadeButton et la Tornade disparraissent
			Button btnTornade = TornadeButton.GetComponent<Button>();
			btnTornade.enabled = false;
			Tornade.SetActive(false);
			
		}
		//Si le Tornade a été cliqué
        else
        {
			//Bouton et Tornade disparaissent
			Button btnTornade = TornadeButton.GetComponent<Button>();
			btnTornade.enabled = false;
			Tornade.SetActive(false);
			//Passe TornadeClicked a false
			TornadeClicked = false;
		}

	}
}

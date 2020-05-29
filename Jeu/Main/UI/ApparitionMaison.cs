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
		imageacacher.enabled = true;
		Batiment.SetActive(false);

		Button btn = BoutonPourCacherMaisons.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		Button btnSupr = BoutonPoursupr.GetComponent<Button>();
		btnSupr.onClick.AddListener(suprOnClick);
		imageBtnSupr.SetActive(false);


		Tornade.SetActive(false);
		TornadeClicked = false;
		Button btnTornade = TornadeButton.GetComponent<Button>();
		btnTornade.onClick.AddListener(OnClickTornade);
		
		RandomNumberGen();
	}
	
	


	void TaskOnClick(){
		if (PlayerStats.money >= cost)
		{
			Batiment.SetActive(true);
			imageacacher.enabled = false;
			PlayerStats.DecreaseMoney(cost);
			imageBtnSupr.SetActive(true);
			TornadeOrNot();

		}
		else
		{
			Button btn = BoutonPourCacherMaisons.GetComponent<Button>();
			btn.enabled = true;
			Debug.Log("Pas assez d'argent, il faut "+cost+" pièces");
			
		}
	}
	
	void suprOnClick()
    {
		if(imageacacher.enabled == false)
        {

			suprBatiment();
			PlayerStats.IncreaseMoney(2);
			

		}
        
        

    }
	void suprBatiment()
    {
		Batiment.SetActive(false);
		imageacacher.enabled = true;
		Button btn = BoutonPourCacherMaisons.GetComponent<Button>();
		btn.enabled = true;
		imageBtnSupr.SetActive(false);
		Tornade.SetActive(false);
	}

	// Tornade Methods

	void RandomNumberGen()
	{
		RandomNumb = UnityEngine.Random.Range(0, 100);
	}

	void TornadeOrNot()
	{
		if (RandomNumb < 50)
		{
			StartCoroutine(DestOrSurvive());
			Tornade.SetActive(true);
			Button btnTornade = TornadeButton.GetComponent<Button>();
			btnTornade.enabled = true;


		}
		else
		{
			RandomNumberGen();
		}
	}

	void OnClickTornade()
    {
		TornadeClicked = true;
    }

	IEnumerator DestOrSurvive()
    {
		yield return new WaitForSeconds(5);
		if(TornadeClicked == false)
        {
			suprBatiment();
			Button btnTornade = TornadeButton.GetComponent<Button>();
			btnTornade.enabled = false;
			Tornade.SetActive(false);
			
		}
        else
        {
			
			Button btnTornade = TornadeButton.GetComponent<Button>();
			btnTornade.enabled = false;
			Tornade.SetActive(false);
			TornadeClicked = false;
		}

	}
}
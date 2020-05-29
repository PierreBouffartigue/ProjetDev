using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

public class upgradeMoney : MonoBehaviour
{
	public GameObject moneyDisplay;

	private PlayerStats moneyScipt;

	public Button BoutonUpgrade;
	[SerializeField] private Image imageupgrade;

	
	public static int moneyToWin;

	void Start()
	{
		
		moneyToWin = 1;
		Button btn = BoutonUpgrade.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		
		if (PlayerStats.money >= moneyToWin * 4)
        {
			PlayerStats.money -= moneyToWin * 4;
			moneyToWin += 1;

		}

		
	}
}
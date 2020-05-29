using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

public class WinMoney : MonoBehaviour {
	public Button BoutonMoney;
	[SerializeField] private Image imagepiece;

	private float Countdown;
	private int money;

	private int moneyToWin;

	void Start () {
		Countdown = 5;
		money = 1;
		Button btn = BoutonMoney.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void Update()
	{
		moneyToWin = upgradeMoney.moneyToWin;
		Countdown -= Time.deltaTime;
		if(Countdown < 0)
		{
			Countdown = 5;
			money += moneyToWin;
		}

		if(money == 0)
		{
			imagepiece.enabled = false;
		}
		else
		{
			imagepiece.enabled = true;
		}
	}

	void TaskOnClick(){
		PlayerStats.IncreaseMoney(money);
		money = 0;
	}
}
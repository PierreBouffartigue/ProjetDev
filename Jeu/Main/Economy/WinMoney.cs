using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

public class WinMoney : MonoBehaviour
{
    public Button BoutonMoney;
    [SerializeField] private Image imagepiece;
    private float Countdown;
    private int money;
    private int moneyToWin;

    void Start()
    {
        //Temps avant d'ajouter de l'argent à la "cagnotte"
        Countdown = 5;
        //Argent gagné disponible lors du clic sur le bouton. "cagnotte"
        money = 1;
        //Récupere le BoutonMoney et le lie à une méthode
        Button btn = BoutonMoney.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        //Recuperation du nombre de pieces à gagner à la fin du timer
        moneyToWin = upgradeMoney.moneyToWin;
        Countdown -= Time.deltaTime;
        //si Countdown passe sous 0
        if (Countdown < 0)
        {
            // on le reinitialise
            Countdown = 5;
            //et on ajoute les pieces à gagner à la "cagnotte"
            money += moneyToWin;
        }
        //Si 0 dans la "cagnotte"
        if (money == 0)
        {
            //Le bouton pour récupérer l'argent n'apparaît pas
            imagepiece.enabled = false;
        }
        else
        {
            //Sinon il apparaît
            imagepiece.enabled = true;
        }
    }

    //Tâche exécuté lors de l'appui sur le bouton
    void TaskOnClick()
    {
        //Incrémente l'agent du joueur avec le nombre de pièces dans la "cagnotte"
        PlayerStats.IncreaseMoney(money);
        //Reinitialise la "cagnotte"
        money = 0;
    }
}

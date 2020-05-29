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
        //Initialisation de l'argent à ajouter dans la "cagnotte" de l'hotel de ville
        moneyToWin = 1;
        //Récuperation du bouton d'amélioration et une methode lui est liée
        Button btn = BoutonUpgrade.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    //Quand click sur le bouton
    void TaskOnClick()
    {
        //Si le joueur a exactement ou plus d'argent que 4 fois l'argent qui s'ajoute à la "cagnotte"
        if (PlayerStats.money >= moneyToWin * 4)
        {
            // il perd alors cette somme 
            PlayerStats.money -= moneyToWin * 4;
            //et l'argent qui s'ajoute à la cagnotte augmente de 1
            moneyToWin += 1;

        }


    }
}

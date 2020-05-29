using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSystem : MonoBehaviour
{
    public GameObject Transition;
    private int Round = 1;
    private int victory = 0;
    private string WhoWin = null;
    public Sprite CheckMark, NoneMark, CrossMark;

    public GameObject Round1Display, Round2Display, Round3Display;

    public Button ButtonCavalry, ButtonSpear, ButtonBow;
    private Button btnCavalry, btnSpear, btnBow;

    private bool CavalryEnable = true;
    private bool SpearEnable = true;
    private bool BowEnable = true;
    private bool CavalryEnemyEnable = true;
    private bool SpearEnemyEnable = true;
    private bool BowEnemyEnable = true;

    private float Countdown;

    public GameObject ChoiceDisplay, PChoiceCavalryDisplay, PChoiceSpearDisplay, PChoiceBowDisplay, EChoiceCavalryDisplay, EChoiceSpearDisplay, EChoiceBowDisplay;
    public GameObject BlackPC, BlackPS, BlackPB, BlackEC, BlackES, BlackEB;
    public GameObject VictoryText;

    void Start()
    {
        // Récupère le composant bouton cavalerie
        btnCavalry = ButtonCavalry.GetComponent<Button>();
        // Ecoute le bouton cavalerie
        btnCavalry.onClick.AddListener(OnClickCavalry);
        // Récupère le composant bouton lancier
        btnSpear = ButtonSpear.GetComponent<Button>();
        // Ecoute le bouton lancier
        btnSpear.onClick.AddListener(OnClickSpear);
        // Récupère le composant bouton archer
        btnBow = ButtonBow.GetComponent<Button>();
        // Ecoute le bouton archer
        btnBow.onClick.AddListener(OnClickBow);

        // Manche de départ
        Round = 1;
        // Nombre de victoire du joueur
        victory = 0;
        // Minuteur pour la transition
        Countdown = 3;
        // Initialise le text de victoire
        VictoryText.GetComponent<Text>().text = "";
    }

    void Update()
    {
        // Si le bouton de cavalerie est désactivé
        if (!CavalryEnable)
        {
            // Bouton cavalerie devient inactif
            btnCavalry.enabled = false;
            // Affiche une image noire un peu transparent
            BlackPC.SetActive(true);
        }
        // Sinon
        else
        {
            // Bouton cavalerie est actif
            btnCavalry.enabled = true;
            // Enlève l'image noire
            BlackPC.SetActive(false);
        }

        // Si le bouton de lancier est désactivé
        if (!SpearEnable)
        {
            // Bouton cavalerie devient inactif
            btnSpear.enabled = false;
            // Affiche une image noire un peu transparent
            BlackPS.SetActive(true);
        }
        // Sinon
        else
        {
            // Bouton cavalerie est actif
            btnSpear.enabled = true;
            // Enlève l'image noire
            BlackPS.SetActive(false);
        }

        // Si le bouton d'archer est désactivé
        if (!BowEnable)
        {
            // Bouton archer devient inactif
            btnBow.enabled = false;
            // Affiche une image noire un peu transparent
            BlackPB.SetActive(true);
        }
        else
        {
            // Bouton archer est actif
            btnBow.enabled = true;
            // Enlève l'image noire
            BlackPB.SetActive(false);
        }

        // Si la manche est supérieur à 4 (combat terminé)
        if (Round >= 4)
        {
            // Lance le minuteur
            Countdown -= Time.deltaTime;
        }
        // A la fin du minuteur
        if (Countdown <= 0)
        {
            // Joueur revient à son village
            Transition.GetComponent<TransportRenew>().Village();
            // Réinisialise toutes les variables de la scene de combat
            Round = 1;
            victory = 0;
            Countdown = 3;
            CavalryEnable = true;
            SpearEnable = true;
            BowEnable = true;
            CavalryEnemyEnable = true;
            SpearEnemyEnable = true;
            BowEnemyEnable = true;
            BlackEC.SetActive(false);
            BlackES.SetActive(false);
            BlackEB.SetActive(false);
            Round1Display.GetComponent<Image>().sprite = NoneMark;
            Round2Display.GetComponent<Image>().sprite = NoneMark;
            Round3Display.GetComponent<Image>().sprite = NoneMark;
            ChoiceDisplay.SetActive(false);
            InitCombatUI();
            VictoryText.GetComponent<Text>().text = "";
        }
    }

    // Quand le bouton de cavalerie est cliqué
    void OnClickCavalry()
    {
        // Réinitialise l'affichage du choix du joueur et de l'ennemie
        InitCombatUI();
        // Bouton cavalerie devient inatif
        CavalryEnable = false;
        // Affiche le choix du joueur
        ChoiceDisplay.SetActive(true);
        PChoiceCavalryDisplay.SetActive(true);
        // Lance le combat
        Combat(PlayerStats.TroopsTypes.Cavalry, EnemyChoice());
        // Diminue le nombre de cavaliers de 10
        PlayerStats.DecreaseTroops(PlayerStats.TroopsTypes.Cavalry, 10);
    }

    // Quand le bouton de lancier est cliqué
    void OnClickSpear()
    {
        // Réinitialise l'affichage du choix du joueur et de l'ennemie
        InitCombatUI();
        // Bouton lancier devient inatif
        SpearEnable = false;
        // Affiche le choix du joueur
        ChoiceDisplay.SetActive(true);
        PChoiceSpearDisplay.SetActive(true);
        // Lance le combat
        Combat(PlayerStats.TroopsTypes.Spear, EnemyChoice());
        // Diminue le nombre de lanciers de 10
        PlayerStats.DecreaseTroops(PlayerStats.TroopsTypes.Spear, 10);
    }

    // Quand le bouton d'archer est cliqué
    void OnClickBow()
    {
        // Réinitialise l'affichage du choix du joueur et de l'ennemie
        InitCombatUI();
        // Bouton archer devient inatif
        BowEnable = false;
        // Affiche le choix du joueur
        ChoiceDisplay.SetActive(true);
        PChoiceBowDisplay.SetActive(true);
        // Lance le combat
        Combat(PlayerStats.TroopsTypes.Bow, EnemyChoice());
        // Diminue le nombre d'archers de 10
        PlayerStats.DecreaseTroops(PlayerStats.TroopsTypes.Bow, 10);
    }

    // Choix aléatoire de l'ennemie
    private EnemyStats.TroopsTypes EnemyChoiceRandom()
    {
        // Choisit un chiffre entre 0 et 2 (0 = Cavalerie, 1 = Lancier, 2 = Archer)
        EnemyStats.TroopsTypes enemytroop = (EnemyStats.TroopsTypes)Random.Range(0, 3);
        // Si le chiffre est 0 et qu'il a déjà utilisé la cavalerie
        if (enemytroop == EnemyStats.TroopsTypes.Cavalry && !CavalryEnemyEnable)
        {
            // Relance le choix aléatoire
            return EnemyChoiceRandom();
        }
        // Si le chiffre est 1 et qu'il a déjà utilisé les lanciers
        else if (enemytroop == EnemyStats.TroopsTypes.Spear && !SpearEnemyEnable)
        {
            // Relance le choix aléatoire
            return EnemyChoiceRandom();
        }
        // Si le chiffre est 2 et qu'il a déjà utilisé les archers
        else if (enemytroop == EnemyStats.TroopsTypes.Bow && !BowEnemyEnable)
        {
            // Relance le choix aléatoire
            return EnemyChoiceRandom();
        }
        // Sinon
        else
        {
            // Retourne le choix de l'ennemie
            return enemytroop;
        }
    }

    // Gérer l'interface en fonction du choix de l'ennemie
    private EnemyStats.TroopsTypes EnemyChoice()
    {
        switch (EnemyChoiceRandom())
        {
            // Si le type est cavalerie
            case EnemyStats.TroopsTypes.Cavalry:
                // Affiche la cavalerie
                EChoiceCavalryDisplay.SetActive(true);
                // Diminue de 10 la cavalerie ennemie
                EnemyStats.DecreaseTroops(EnemyStats.TroopsTypes.Cavalry, 10);
                // Désactive la cavalerie des choix
                CavalryEnemyEnable = false;
                // Affiche image noir transparent
                BlackEC.SetActive(true);
                // Retourne le type de troupe
                return EnemyStats.TroopsTypes.Cavalry;
            // Si le type est lancier
            case EnemyStats.TroopsTypes.Spear:
                // Affiche les lanciers
                EChoiceSpearDisplay.SetActive(true);
                // Diminue de 10 les lanciers ennemies
                EnemyStats.DecreaseTroops(EnemyStats.TroopsTypes.Spear, 10);
                // Désactive les lanciers des choix
                SpearEnemyEnable = false;
                // Affiche image noir transparent
                BlackES.SetActive(true);
                // Retourne le type de troupe
                return EnemyStats.TroopsTypes.Spear;
            // Si le type est archer
            case EnemyStats.TroopsTypes.Bow:
                // Affiche les archers
                EChoiceBowDisplay.SetActive(true);
                // Diminue de 10 les archers ennemies
                EnemyStats.DecreaseTroops(EnemyStats.TroopsTypes.Bow, 10);
                // Désactive les archers des choix
                BowEnemyEnable = false;
                // Affiche image noir transparent
                BlackEB.SetActive(true);
                // Retourne le type de troupe
                return EnemyStats.TroopsTypes.Bow;
        }
        // Relance la fonction
        return EnemyChoice();
    }

    // Réinitialise l'interface des choix
    void InitCombatUI()
    {
        // Enlève l'image de la cavalerie joueur
        PChoiceCavalryDisplay.SetActive(false);
        // Enlève l'image des lanciers joueur
        PChoiceSpearDisplay.SetActive(false);
        // Enlève l'image des archers joueur
        PChoiceBowDisplay.SetActive(false);
        // Enlève l'image de la cavalerie ennemie
        EChoiceCavalryDisplay.SetActive(false);
        // Enlève l'image des lanciers ennemie
        EChoiceSpearDisplay.SetActive(false);
        // Enlève l'image des archers ennemie
        EChoiceBowDisplay.SetActive(false);
    }

    // Le système de combat
    void Combat(PlayerStats.TroopsTypes PlayerChoice, EnemyStats.TroopsTypes EnemyChoice)
    {
        // Si le choix du joueur est cavalerie
        if (PlayerChoice == PlayerStats.TroopsTypes.Cavalry)
        {
            switch (EnemyChoice)
            {
                // Si le choix du ennemie est cavalerie
                case EnemyStats.TroopsTypes.Cavalry:
                    // Si je joueur a plus de troupes que celle de l'ennemie
                    if (PlayerStats.CavalryTroops >= EnemyStats.CavalryTroops)
                    {
                        // +1 au nombre de victoire
                        victory += 1;
                        // Joueur qui a gagné
                        WhoWin = PlayerStats.user;
                    }
                    else
                    {
                        // Ennemie qui a gagné
                        WhoWin = "Enemy";
                    }
                    break;
                // Si le choix du ennemie est lancier
                case EnemyStats.TroopsTypes.Spear:
                    // Ennemie qui a gagné
                    WhoWin = "Enemy";
                    break;
                // Si le choix du ennemie est archer
                case EnemyStats.TroopsTypes.Bow:
                    // +1 au nombre de victoire
                    victory += 1;
                    // Joueur qui a gagné
                    WhoWin = PlayerStats.user;
                    break;
            }
        }
        // Si le choix du joueur est lancier
        else if (PlayerChoice == PlayerStats.TroopsTypes.Spear)
        {
            switch (EnemyChoice)
            {
                // Si le choix du ennemie est cavalerie
                case EnemyStats.TroopsTypes.Cavalry:
                    // +1 au nombre de victoire
                    victory += 1;
                    // Joueur qui a gagné
                    WhoWin = PlayerStats.user;
                    break;
                // Si le choix du ennemie est lancier
                case EnemyStats.TroopsTypes.Spear:
                    if (PlayerStats.SpearTroops >= EnemyStats.SpearTroops)
                    {
                        // +1 au nombre de victoire
                        victory += 1;
                        // Joueur qui a gagné
                        WhoWin = PlayerStats.user;
                    }
                    else
                    {
                        // Ennemie qui a gagné
                        WhoWin = "Enemy";
                    }
                    break;
                // Si le choix du ennemie est archer
                case EnemyStats.TroopsTypes.Bow:
                    // Ennemie qui a gagné
                    WhoWin = "Enemy";
                    break;
            }
        }
        // Si le choix du joueur est archer
        else if (PlayerChoice == PlayerStats.TroopsTypes.Bow)
        {
            switch (EnemyChoice)
            {
                // Si le choix du ennemie est cavalerie
                case EnemyStats.TroopsTypes.Cavalry:
                    // Ennemie qui a gagné
                    WhoWin = "Enemy";
                    break;
                case EnemyStats.TroopsTypes.Spear:
                    // +1 au nombre de victoire
                    victory += 1;
                    // Joueur qui a gagné
                    WhoWin = PlayerStats.user;
                    break;
                // Si le choix du ennemie est lancier
                case EnemyStats.TroopsTypes.Bow:
                    if (PlayerStats.BowTroops >= EnemyStats.BowTroops)
                    {
                        // +1 au nombre de victoire
                        victory += 1;
                        // Joueur qui a gagné
                        WhoWin = PlayerStats.user;
                    }
                    else
                    {
                        // Ennemie qui a gagné
                        WhoWin = "Enemy";
                    }
                    break;
            }
        }
        
        // Si c'est le joueur qui a gagné
        if (WhoWin == PlayerStats.user)
        {
            switch (Round)
            {
                // Si manche 1
                case 1:
                    // Affiche une coche sur la première manche
                    Round1Display.GetComponent<Image>().sprite = CheckMark;
                    break;
                // Si manche 2
                case 2:
                    // Affiche une coche sur la deuxième manche
                    Round2Display.GetComponent<Image>().sprite = CheckMark;
                    break;
                // Si manche 1
                case 3:
                    // Affiche une coche sur la troisième manche
                    Round3Display.GetComponent<Image>().sprite = CheckMark;
                    break;
            }
        }
        // Si c'est l'ennemie qui a gagné
        else if (WhoWin == "Enemy")
        {
            switch (Round)
            {
                // Si manche 1
                case 1:
                    // Affiche une croix sur la première manche
                    Round1Display.GetComponent<Image>().sprite = CrossMark;
                    break;
                // Si manche 2
                case 2:
                    // Affiche une croix sur la deuxième manche
                    Round2Display.GetComponent<Image>().sprite = CrossMark;
                    break;
                // Si manche 3
                case 3:
                    // Affiche une croix sur la troisième manche
                    Round3Display.GetComponent<Image>().sprite = CrossMark;
                    break;
            }
        }
        // Réinitialse qui à gagné pour la prochaine manche
        WhoWin = "";
        // Manche suivante
        Round += 1;
        // Si manche est égale à 4 alors le combat est terminé
        if (Round == 4)
        {
            // Si le joueur a 2 victoires ou plus
            if (victory >= 2)
            {
                // Affiche "Victoire"
                VictoryText.GetComponent<Text>().text = "Victoire";
            }
            // Sinon
            else
            {
                // Affiche "Défaite"
                VictoryText.GetComponent<Text>().text = "Défaite";
            }
        }
    }
}

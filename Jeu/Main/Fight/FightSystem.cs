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
        btnCavalry = ButtonCavalry.GetComponent<Button>();
        btnCavalry.onClick.AddListener(OnClickCavalry);
        btnSpear = ButtonSpear.GetComponent<Button>();
        btnSpear.onClick.AddListener(OnClickSpear);
        btnBow = ButtonBow.GetComponent<Button>();
        btnBow.onClick.AddListener(OnClickBow);

        Round = 1;
        victory = 0;
        Countdown = 3;
        VictoryText.GetComponent<Text>().text = "";
    }

    void Update()
    {
        if (!CavalryEnable)
        {
            btnCavalry.enabled = false;
            BlackPC.SetActive(true);
        }
        else
        {
            btnCavalry.enabled = true;
            BlackPC.SetActive(false);
        }
        if (!SpearEnable)
        {
            btnSpear.enabled = false;
            BlackPS.SetActive(true);
        }
        else
        {
            btnSpear.enabled = true;
            BlackPS.SetActive(false);
        }
        if (!BowEnable)
        {
            btnBow.enabled = false;
            BlackPB.SetActive(true);
        }
        else
        {
            btnBow.enabled = true;
            BlackPB.SetActive(false);
        }

        if (Round >= 4)
        {
            Countdown -= Time.deltaTime;
        }
        if (Countdown <= 0)
        {
            Transition.GetComponent<TransportRenew>().Village();
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

    void OnClickCavalry()
    {
        InitCombatUI();
        CavalryEnable = false;
        ChoiceDisplay.SetActive(true);
        PChoiceCavalryDisplay.SetActive(true);
        Combat(PlayerStats.TroopsTypes.Cavalry, EnemyChoice());
        PlayerStats.DecreaseTroops(PlayerStats.TroopsTypes.Cavalry, 10);
    }

    void OnClickSpear()
    {
        InitCombatUI();
        SpearEnable = false;
        ChoiceDisplay.SetActive(true);
        PChoiceSpearDisplay.SetActive(true);
        Combat(PlayerStats.TroopsTypes.Spear, EnemyChoice());
        PlayerStats.DecreaseTroops(PlayerStats.TroopsTypes.Spear, 10);
    }

    void OnClickBow()
    {
        InitCombatUI();
        BowEnable = false;
        ChoiceDisplay.SetActive(true);
        PChoiceBowDisplay.SetActive(true);
        Combat(PlayerStats.TroopsTypes.Bow, EnemyChoice());
        PlayerStats.DecreaseTroops(PlayerStats.TroopsTypes.Bow, 10);
    }

    private EnemyStats.TroopsTypes EnemyChoiceRandom()
    {
        EnemyStats.TroopsTypes enemytroop = (EnemyStats.TroopsTypes)Random.Range(0, 3);
        if (enemytroop == EnemyStats.TroopsTypes.Cavalry && !CavalryEnemyEnable)
        {
            return EnemyChoiceRandom();
        }
        else if (enemytroop == EnemyStats.TroopsTypes.Spear && !SpearEnemyEnable)
        {
            return EnemyChoiceRandom();
        }
        else if (enemytroop == EnemyStats.TroopsTypes.Bow && !BowEnemyEnable)
        {
            return EnemyChoiceRandom();
        }
        else
        {
            return enemytroop;
        }
    }

    private EnemyStats.TroopsTypes EnemyChoice()
    {
        switch (EnemyChoiceRandom())
        {
            case EnemyStats.TroopsTypes.Cavalry:
                EChoiceCavalryDisplay.SetActive(true);
                EnemyStats.DecreaseTroops(EnemyStats.TroopsTypes.Cavalry, 10);
                CavalryEnemyEnable = false;
                BlackEC.SetActive(true);
                return EnemyStats.TroopsTypes.Cavalry;
            case EnemyStats.TroopsTypes.Spear:
                EChoiceSpearDisplay.SetActive(true);
                EnemyStats.DecreaseTroops(EnemyStats.TroopsTypes.Spear, 10);
                SpearEnemyEnable = false;
                BlackES.SetActive(true);
                return EnemyStats.TroopsTypes.Spear;
            case EnemyStats.TroopsTypes.Bow:
                EChoiceBowDisplay.SetActive(true);
                EnemyStats.DecreaseTroops(EnemyStats.TroopsTypes.Bow, 10);
                BowEnemyEnable = false;
                BlackEB.SetActive(true);
                return EnemyStats.TroopsTypes.Bow;
        }
        return EnemyChoice();
    }

    void InitCombatUI()
    {
        PChoiceCavalryDisplay.SetActive(false);
        PChoiceSpearDisplay.SetActive(false);
        PChoiceBowDisplay.SetActive(false);
        EChoiceCavalryDisplay.SetActive(false);
        EChoiceSpearDisplay.SetActive(false);
        EChoiceBowDisplay.SetActive(false);
    }

    void Combat(PlayerStats.TroopsTypes PlayerChoice, EnemyStats.TroopsTypes EnemyChoice)
    {
        if (PlayerChoice == PlayerStats.TroopsTypes.Cavalry)
        {
            switch (EnemyChoice)
            {
                case EnemyStats.TroopsTypes.Cavalry:
                    if (PlayerStats.CavalryTroops >= EnemyStats.CavalryTroops)
                    {
                        victory += 1;
                        WhoWin = PlayerStats.user;
                    }
                    else
                    {
                        WhoWin = "Enemy";
                        WhoWin = PlayerStats.user;
                    }
                    break;
                case EnemyStats.TroopsTypes.Spear:
                    WhoWin = "Enemy";
                    break;
                case EnemyStats.TroopsTypes.Bow:
                    victory += 1;
                    WhoWin = PlayerStats.user;
                    break;
            }
        }
        else if (PlayerChoice == PlayerStats.TroopsTypes.Spear)
        {
            switch (EnemyChoice)
            {
                case EnemyStats.TroopsTypes.Cavalry:
                    victory += 1;
                    WhoWin = PlayerStats.user;
                    break;
                case EnemyStats.TroopsTypes.Spear:
                    if (PlayerStats.SpearTroops >= EnemyStats.SpearTroops)
                    {
                        victory += 1;
                        WhoWin = PlayerStats.user;
                    }
                    else
                    {
                        WhoWin = "Enemy";
                    }
                    break;
                case EnemyStats.TroopsTypes.Bow:
                    WhoWin = "Enemy";
                    break;
            }
        }
        else if (PlayerChoice == PlayerStats.TroopsTypes.Bow)
        {
            switch (EnemyChoice)
            {
                case EnemyStats.TroopsTypes.Cavalry:
                    WhoWin = "Enemy";
                    break;
                case EnemyStats.TroopsTypes.Spear:
                    victory += 1;
                    WhoWin = PlayerStats.user;
                    break;
                case EnemyStats.TroopsTypes.Bow:
                    if (PlayerStats.BowTroops >= EnemyStats.BowTroops)
                    {
                        victory += 1;
                        WhoWin = PlayerStats.user;
                    }
                    else
                    {
                        WhoWin = "Enemy";
                    }
                    break;
            }
        }
        
        if (WhoWin == PlayerStats.user)
        {
            switch (Round)
            {
                case 1:
                    Round1Display.GetComponent<Image>().sprite = CheckMark;
                    break;
                case 2:
                    Round2Display.GetComponent<Image>().sprite = CheckMark;
                    break;
                case 3:
                    Round3Display.GetComponent<Image>().sprite = CheckMark;
                    break;
            }
        }
        else if (WhoWin == "Enemy")
        {
            switch (Round)
            {
                case 1:
                    Round1Display.GetComponent<Image>().sprite = CrossMark;
                    break;
                case 2:
                    Round2Display.GetComponent<Image>().sprite = CrossMark;
                    break;
                case 3:
                    Round3Display.GetComponent<Image>().sprite = CrossMark;
                    break;
            }
        }
        WhoWin = "";
        Round += 1;
        if (Round == 4)
        {
            if (victory >= 2)
            {
                VictoryText.GetComponent<Text>().text = "Victoire";
            }
            else
            {
                VictoryText.GetComponent<Text>().text = "Défaite";
            }
        }
    }
}

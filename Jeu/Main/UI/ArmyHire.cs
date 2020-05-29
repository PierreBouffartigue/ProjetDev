using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyHire : MonoBehaviour
{
    public GameObject armyRecruitUI;
    public GameObject armyDisplay;
    public Button BoutonCavalry;
    public Button BoutonSpear;
    public Button BoutonBow;
    public Button BoutonClose;
    private Button btnCavalry;
    private Button btnSpear;
    private Button btnBow;
    private Button btnClose;

    void Start()
    {
        btnCavalry = BoutonCavalry.GetComponent<Button>();
        btnCavalry.onClick.AddListener(OnClickCavalry);
        btnSpear = BoutonSpear.GetComponent<Button>();
        btnSpear.onClick.AddListener(OnClickSpear);
        btnBow = BoutonBow.GetComponent<Button>();
        btnBow.onClick.AddListener(OnClickBow);
        btnClose = BoutonClose.GetComponent<Button>();
        btnClose.onClick.AddListener(OnClickClose);
    }

    void Update()
    {
     
    }

    void OnClickCavalry()
    {
        if(PlayerStats.money > 0)
        {
            PlayerStats.IncreaseTroops(PlayerStats.TroopsTypes.Cavalry, 20);
            PlayerStats.DecreaseMoney(1);
        }
    }

    void OnClickSpear()
    {
        if (PlayerStats.money > 0)
        {
            PlayerStats.IncreaseTroops(PlayerStats.TroopsTypes.Spear, 20);
            PlayerStats.DecreaseMoney(1);
        }
    }

    void OnClickBow()
    {
        if (PlayerStats.money > 0)
        {
            PlayerStats.IncreaseTroops(PlayerStats.TroopsTypes.Bow, 20);
            PlayerStats.DecreaseMoney(1);
        }
    }

    void OnClickClose()
    {
        armyRecruitUI.SetActive(false);
    }
}

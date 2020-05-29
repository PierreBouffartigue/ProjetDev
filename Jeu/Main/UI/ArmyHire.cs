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
        // Récupère le composant bouton cavalerie
        btnCavalry = BoutonCavalry.GetComponent<Button>();
        // Ecoute le bouton cavalerie
        btnCavalry.onClick.AddListener(OnClickCavalry);
        // Récupère le composant bouton lancier
        btnSpear = BoutonSpear.GetComponent<Button>();
        // Ecoute le bouton lancier
        btnSpear.onClick.AddListener(OnClickSpear);
        // Récupère le composant bouton archer
        btnBow = BoutonBow.GetComponent<Button>();
        // Ecoute le bouton archer
        btnBow.onClick.AddListener(OnClickBow);
        // Récupère le composant bouton fermer
        btnClose = BoutonClose.GetComponent<Button>();
        // Ecoute le bouton fermer
        btnClose.onClick.AddListener(OnClickClose);
    }

    // Quand le bouton de cavalerie est cliqué
    void OnClickCavalry()
    {
        // Si argent du joueur est supérieur à 0
        if(PlayerStats.money > 0)
        {
            // Augmente de 20 les cavaliers
            PlayerStats.IncreaseTroops(PlayerStats.TroopsTypes.Cavalry, 20);
            // Diminue de 1 l'argent
            PlayerStats.DecreaseMoney(1);
        }
    }

    // Quand le bouton de lancier est cliqué
    void OnClickSpear()
    {
        // Si argent du joueur est supérieur à 0
        if (PlayerStats.money > 0)
        {
            // Augmente de 20 les lanciers
            PlayerStats.IncreaseTroops(PlayerStats.TroopsTypes.Spear, 20);
            // Diminue de 1 l'argent
            PlayerStats.DecreaseMoney(1);
        }
    }

    // Quand le bouton d'archer est cliqué
    void OnClickBow()
    {
        // Si argent du joueur est supérieur à 0
        if (PlayerStats.money > 0)
        {
            // Augmente de 20 les archers
            PlayerStats.IncreaseTroops(PlayerStats.TroopsTypes.Bow, 20);
            // Diminue de 1 l'argent
            PlayerStats.DecreaseMoney(1);
        }
    }

    void OnClickClose()
    {
        // Ferme la fenêtre de recrutement d'armée
        armyRecruitUI.SetActive(false);
    }
}

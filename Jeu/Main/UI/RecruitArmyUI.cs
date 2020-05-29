using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitArmyUI : MonoBehaviour
{
    public GameObject armyRecruitUI;
    public Button BoutonForge;
    private Button btn;

    void Start()
    {
        // Récupère le composant bouton forge
        btn = BoutonForge.GetComponent<Button>();
        // Ecoute le bouton forge
        btn.onClick.AddListener(TaskOnClick);
    }

    // Quand le bouton de forge est cliqué
    void TaskOnClick()
    {
        // Affiche l'interface de recrutement
        armyRecruitUI.SetActive(true);
    }
}

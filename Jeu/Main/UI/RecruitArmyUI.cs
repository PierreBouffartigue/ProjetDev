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
        btn = BoutonForge.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        
    }

    void TaskOnClick()
    {
        armyRecruitUI.SetActive(true);
    }
}

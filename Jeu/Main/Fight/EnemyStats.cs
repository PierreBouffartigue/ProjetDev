﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Types de troupes
    public enum TroopsTypes { Cavalry, Spear, Bow };
    // Nombre de cavaliers
    public static int CavalryTroops = 100;
    // Nombre de lanciers
    public static int SpearTroops = 150;
    // Nombre d'archers
    public static int BowTroops = 50;

    // Augmenter le nombre de troupes
    public static void IncreaseTroops(TroopsTypes type, int nb)
    {
        switch (type)
        {
            // Si le type est cavalerie
            case TroopsTypes.Cavalry:
                // Ajoute nb cavaliers
                CavalryTroops += nb;
                break;
            // Si le type est lancier
            case TroopsTypes.Spear:
                // Ajoute nb lanciers
                SpearTroops += nb;
                break;
            // Si le type est archer
            case TroopsTypes.Bow:
                // Ajoute nb archers
                BowTroops += nb;
                break;
        }
    }

    // Diminuer le nombre de troupes
    public static void DecreaseTroops(TroopsTypes type, int nb)
    {
        switch (type)
        {
            // Si le type est cavalerie
            case TroopsTypes.Cavalry:
                // Dimunue nb cavaliers
                CavalryTroops -= nb;
                break;
            // Si le type est lancier
            case TroopsTypes.Spear:
                // Dimunue nb lancier
                SpearTroops -= nb;
                break;
            // Si le type est archer
            case TroopsTypes.Bow:
                // Dimunue nb archers
                BowTroops -= nb;
                break;
        }

        // Le nombre de troupes ne peut pas être négatif
        if (CavalryTroops < 0)
        {
            CavalryTroops = 0;
        }
        if (SpearTroops < 0)
        {
            SpearTroops = 0;
        }
        if (BowTroops < 0)
        {
            BowTroops = 0;
        }
    }
}

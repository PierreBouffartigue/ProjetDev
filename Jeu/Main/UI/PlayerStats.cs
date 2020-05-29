using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static string user = "Player 1";
    public static int money = 5;
    public enum TroopsTypes { Cavalry, Spear, Bow };
    public static int CavalryTroops = 100;
    public static int SpearTroops = 100;
    public static int BowTroops = 100;

    public static void IncreaseTroops(TroopsTypes type, int nb)
    {
        switch (type)
        {
            case TroopsTypes.Cavalry:
                CavalryTroops += nb;
                break;
            case TroopsTypes.Spear:
                SpearTroops += nb;
                break;
            case TroopsTypes.Bow:
                BowTroops += nb;
                break;
        }
    }

    public static void DecreaseTroops(TroopsTypes type, int nb)
    {
        switch (type)
        {
            case TroopsTypes.Cavalry:
                CavalryTroops -= nb;
                break;
            case TroopsTypes.Spear:
                SpearTroops -= nb;
                break;
            case TroopsTypes.Bow:
                BowTroops -= nb;
                break;
        }
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

    public static void IncreaseMoney(int nb)
    {
        money += nb;
    }

    public static void DecreaseMoney(int nb)
    {
        money -= nb;
    }
}

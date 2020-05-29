using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailleEcran : MonoBehaviour {
    public void Reso()
    {
        // Définie la résolution à 640x480 et en plein écran
        Screen.SetResolution(640, 480, true);
    }
}

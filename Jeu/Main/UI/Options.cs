using UnityEngine;

public class Options : MonoBehaviour
{
    public void Full()
    {
        // Change la fenêtre de plein écran à fenêtré et inversement
        Screen.fullScreen = !Screen.fullScreen;
    }
}

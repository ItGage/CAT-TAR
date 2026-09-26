using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    // Set your desired dimensions in the Unity Inspector
    public int targetWidth = 1920;
    public int targetHeight = 1080;
    public bool isFullscreen = false;

    void Awake()
    {
        // Enforce the resolution immediately as the game starts up
        Screen.SetResolution(targetWidth, targetHeight, isFullscreen);
    }
}
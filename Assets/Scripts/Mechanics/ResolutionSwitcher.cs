using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    // Example method to set a specific lower resolution (e.g., 800x600 windowed)
    public void SetLowResolution()
    {
        // Set resolution to 800x600 in windowed mode
        Screen.SetResolution(640, 360, false);
    }

    // Example method to dynamically switch resolutions from a dropdown/button in an options menu
    public void SetResolution(int width, int height)
    {
        // You can maintain a list of supported resolutions and pass the desired width and height
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    // A more advanced script would retrieve all supported resolutions and let the user pick from a list.
}


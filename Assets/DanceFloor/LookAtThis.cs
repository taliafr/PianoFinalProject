using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    public Light strobeLight;
    public float strobeSpeed = 1.0f; // Speed of the strobe effect

    private bool isStrobing = false;

    void Start()
    {
        if (strobeLight == null)
        {
            // If the Light component is not assigned, try to find one on the same GameObject
            strobeLight = GetComponent<Light>();
        }

        if (strobeLight == null)
        {
            // If still not found, log an error and disable the script
            Debug.LogError("StrobeLight script requires a reference to a Light component.");
            enabled = false;
        }
    }

    void Update()
    {
        // Toggle the strobe effect on/off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStrobing = !isStrobing;
        }

        // Update the light intensity based on the strobe effect
        if (isStrobing)
        {
            float intensity = Mathf.PingPong(Time.time * strobeSpeed, 1.0f);
            strobeLight.intensity = intensity;
        }
        else
        {
            // Reset the light intensity when not strobing
            strobeLight.intensity = 100.0f;
        }
    }
}
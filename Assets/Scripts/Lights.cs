using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public float delay;
    public float minIntensity;
    public float maxIntensity;
    public bool startAtMin;
   
    private Light myLight; //allows reference to light in code
   
    private float timeElapsed;

    private void Awake()
    {
        myLight = GetComponent<Light>();

        if (myLight != null) 
        {
    
            myLight.intensity = startAtMin ? minIntensity : maxIntensity; //decides what intensity it starts at
        }
    }

    private void Update()
    {
        if (myLight != null)
        {
            timeElapsed += Time.deltaTime;//accounts for time interval specificed in public variables

            if (timeElapsed >= delay) //if time interval is reached, then set off strobe through ToggleLight method
            {
                timeElapsed = 0;
                ToggleLight(); 
            }
        }
    }
    public void ToggleLight() // provides the strobe effect by changing the light's intensity
    {
        if (myLight != null)
        {
            if (myLight.intensity == minIntensity) // if the intensity is min 
            {
                myLight.intensity = maxIntensity; // switch to max
            }
            else if (myLight.intensity == maxIntensity) // if the intensity is max
            {
                myLight.intensity = minIntensity; // switch to min 
            }
        }
    }
}



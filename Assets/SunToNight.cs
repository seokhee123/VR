using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunToNight : MonoBehaviour
{
    private float dayFogDensity;
    private float currentFogDensity;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RenderSettings.fogDensity = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RenderSettings.fogDensity = 0.01f;
        }
    }
}

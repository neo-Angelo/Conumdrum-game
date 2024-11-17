using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIUFIU_EVENT : MonoBehaviour
{
    public List<Light> Lights = new List<Light>();



    // Public variables for start and end event colors
    public Color startEventColor;
    public Color endEventColor;

    public AudioSource audiosource;

    public void startEvent()
    {
        audiosource.Play();
        // Change the color of all the lights in the list to the start event color
        for (int i = 0; i < Lights.Count; i++)
        {
            Lights[i].color = startEventColor;
        }
    }

    public void endEvent()
    {
        audiosource.Stop();
        // Change the color of all the lights in the list to the end event color
        for (int i = 0; i < Lights.Count; i++)
        {
            Lights[i].color = endEventColor;
        }
    }


}

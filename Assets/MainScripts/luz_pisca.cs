using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luz_pisca : MonoBehaviour
{
    public float changeIntervalMin = 2f;
    public float changeIntervalMax = 2.5f;

    private Light pointLight;

    private void Start()
    {
        pointLight = GetComponent<Light>();
        StartCoroutine(ChangeIntensity());
    }

    private IEnumerator ChangeIntensity()
    {
        while (true)
        {
            pointLight.intensity = 0f;
            yield return new WaitForSeconds(0.04f);
            pointLight.intensity = 2f;
            yield return new WaitForSeconds(0.04f);
            pointLight.intensity = 0f;
            yield return new WaitForSeconds(0.04f);
            pointLight.intensity = 2f;
            yield return new WaitForSeconds(0.01f);
            yield return new WaitForSeconds(Random.Range(changeIntervalMin, changeIntervalMax));
        }
    }
}



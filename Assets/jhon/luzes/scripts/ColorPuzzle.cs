using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{
    public List<GameObject> objects;
    public Material transparentMaterial;
    public Material normalMaterial;
    List<int> standardSequence = new List<int>();
    List<int> userInput = new List<int>();
    int stage = 0;
    bool usable = true;

    private PuzzleManager manager;

    private AudioSource audiosource;
    public GameObject luz1;
    public GameObject luz2;
    public GameObject luz3;



    public void OnInteraction()
    {
        if (!usable)
        {
            Debug.Log("not usable");
            return;
        }

        StartCoroutine(enableAfterSeconds(standardSequence.Count * 2));
        for (int i = 0; i < standardSequence.Count; i++)
        {
            StartCoroutine(lightenForSeconds(standardSequence[i], 1 + i * 2));

        }
        if (!manager.checkCompletion(4))
        {
            Renderer rend = luz1.GetComponent<Renderer>();
            rend.material = new Material(normalMaterial);
            Renderer rend2 = luz2.GetComponent<Renderer>();
            rend2.material = new Material(normalMaterial);
            Renderer rend3 = luz3.GetComponent<Renderer>();
            rend3.material = new Material(normalMaterial);

        }


    }
    public void OnComplete()
    {
        audiosource.Play();
    }

    private void OnResetState()
    {

        Renderer rend = luz1.GetComponent<Renderer>();
        rend.material = new Material(normalMaterial);
        Renderer rend2 = luz2.GetComponent<Renderer>();
        rend2.material = new Material(normalMaterial);
        Renderer rend3 = luz3.GetComponent<Renderer>();
        rend3.material = new Material(normalMaterial);

        OnInteraction();

    }

    public void OnStageComplete(int i)
    {

        switch (i)
        {
            case 1:
                Renderer rend = luz1.GetComponent<Renderer>();

                rend.material = new Material(transparentMaterial);
                rend.material.color = Color.white;
                rend.material.EnableKeyword("_EMISSION");
                rend.material.SetColor("_EmissionColor", rend.material.color * 4);
                break;
            case 2:
                Renderer rend2 = luz2.GetComponent<Renderer>();

                rend2.material = new Material(transparentMaterial);
                rend2.material.color = Color.white;
                rend2.material.EnableKeyword("_EMISSION");
                rend2.material.SetColor("_EmissionColor", rend2.material.color * 4);
                break;
            case 3:

                Renderer rend3 = luz3.GetComponent<Renderer>();

                rend3.material = new Material(transparentMaterial);
                rend3.material.color = Color.white;
                rend3.material.EnableKeyword("_EMISSION");
                rend3.material.SetColor("_EmissionColor", rend3.material.color * 4);

                OnComplete();
                manager.completePuzzle(4);
                break;

        }
    }

    public bool isUsable()
    {
        return usable;
    }


    List<int> shuffle(List<int> list)
    {
        List<int> shuffled = new List<int>();
        Random.InitState(System.DateTime.Now.Second);
        int size = list.Count;

        while (size > 0)
        {
            int position = Random.Range(0, size - 1);
            shuffled.Add(list[position]);
            list.Remove(list[position]);
            size--;
        }

        return shuffled;
    }

    public void addUserInput(GameObject obj)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (obj == objects[i])
            {
                userInput.Add(i);
                break;
            }
        }

        if (userInput.Count == standardSequence.Count)
        {
            checkCompletion();
        }
    }

    void checkCompletion()
    {

        int size = standardSequence.Count;
        Invoke("stageReset", 1f);
        switch (stage)
        {
            case 0:
                for (int i = 0; i < size; i++)
                {
                    if (userInput[i] != standardSequence[i])
                    {
                        Debug.Log("Sequencia Incorreta");
                        OnResetState();
                        return;
                    }
                }

                stage = 1;
                OnStageComplete(stage);
                break;

            case 1:

                for (int i = 0; i < size; i++)
                {
                    if (userInput[i] != standardSequence[size - i - 1])
                    {
                        Debug.Log("Sequencia Incorreta");
                        stage = 0;
                        OnResetState();
                        return;
                    }

                }

                stage = 2;
                OnStageComplete(stage);
                break;

            case 2:
                //@HARDCODED
                List<int> customSequence = new List<int>();
                customSequence.Add(standardSequence[1]);
                customSequence.Add(standardSequence[2]);
                customSequence.Add(standardSequence[3]);
                customSequence.Add(standardSequence[0]);
                customSequence.Add(standardSequence[4]);

                for (int i = 0; i < size; i++)
                {
                    if (userInput[i] != customSequence[i])
                    {
                        Debug.Log("Sequencia Incorreta");
                        stage = 0;
                        OnResetState();
                        return;
                    }
                }
                stage = 3;
                OnStageComplete(stage);
                Debug.Log("completo");
                break;
        }
    }

    void stageReset()
    {
        foreach (GameObject item in objects)
        {
            Material material = item.GetComponent<Renderer>().material;
            Light light = item.GetComponent<Light>();
            OnClickLighten lightenScript = item.GetComponent<OnClickLighten>();

            material.DisableKeyword("_EMISSION");
            light.enabled = false;
            lightenScript.enabled = true;

        }
        userInput.Clear();
    }



    private Material getTransparentColor(int value)
    {
        Material material = new Material(transparentMaterial);

        float transparency = 0.75f;
        switch (value)
        {
            case 0:
                material.color = new Color(0.75f, 0, 0, transparency);
                return material;

            case 1:
                material.color = new Color(0, 0.75f, 0, transparency);
                return material;

            case 2:
                material.color = new Color(0, 0, 0.75f, transparency);
                return material;

            case 3:
                material.color = new Color(0.75f, 0.75f, 0, transparency);
                return material;

            case 4:
                material.color = new Color(0.75f, 0, 0.75f, transparency);
                return material;

            default:
                material.color = new Color(0, 0, 0, transparency);
                return material;
        }

    }

    public void lightUp(int index)
    {

        Material material = objects[index].GetComponent<Renderer>().material;
        Light light = objects[index].GetComponent<Light>();
        OnClickLighten script = objects[index].GetComponent<OnClickLighten>();

        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", material.color * 4);
        light.color = material.color;
        light.enabled = true;
        script.enabled = false;
    }

    public void lightUp(GameObject obj)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == obj)
            {
                lightUp(i);
                return;
            }
        }
    }


    IEnumerator lightenForSeconds(int index, int seconds)
    {
        Material material = objects[index]
            .GetComponent<Renderer>()
            .material;

        Light light = objects[index].GetComponent<Light>();

        usable = false;
        yield return new WaitForSeconds(seconds);

        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", material.color * 4);
        light.color = material.color;
        light.enabled = true;

        yield return new WaitForSeconds(1);

        material.DisableKeyword("_EMISSION");
        light.enabled = false;
    }

    IEnumerator enableAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        usable = true;
    }

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        manager = FindFirstObjectByType<PuzzleManager>();

        for (int i = 0; i < objects.Count; i++)
        {
            Renderer renderer = objects[i].GetComponent<Renderer>();
            Light light = objects[i].GetComponent<Light>();
            renderer.material = getTransparentColor(i);
            light.color = GetComponent<Renderer>().material.color;
            standardSequence.Add(i);
        }

        standardSequence = shuffle(standardSequence);



    }
}

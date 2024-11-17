using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPassword : MonoBehaviour
{
    
    public int[] pass = {8, 0, 3, 1};
    public List<GameObject> layers;
    public List<PassScript> scripts;
    public int typePAD; //qual dos pads e 
    private AudioSource audioSource;

    //O que fazer quando o puzzle for completo
    public void complete()
    {
        Debug.Log("Complete");
        foreach (PassScript script in scripts)
        {
            script.enabled = false;
        }
        PuzzleManager manager = FindFirstObjectByType<PuzzleManager>();
        manager.completePuzzle(typePAD);
        audioSource.Play();
    }

    public bool checkPass()
    {       
        string password = "";
        string passAsStr = "";
        Debug.Log("size pass: "+pass.Length);

        for (int i = 0; i < pass.Length; i++)
        {
            passAsStr += pass[i];
            password += scripts[i].getValue();
        }
        
        for(int i = 0; i < pass.Length; i++)
        {
            if (scripts[i].getValue() != pass[i])
                return false;
        }
        
        return true;
    }

    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scripts = new List<PassScript>();
        foreach(GameObject layer in layers)
        {
            scripts.Add(layer.GetComponent<PassScript>());
        }

    }
}

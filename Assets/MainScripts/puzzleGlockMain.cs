using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class puzzleGlockMain : MonoBehaviour
{
    public GameObject puzzleCamera;
    public LayerMask puzzlePieceLayerMask;
    private string[] sequencia = { "F#", "G1", "B1", "E", "B1" };
    private int count = 0;
    public InventoryObject inventory;

    public List<AudioClip> notas;
    public AudioSource audioSource;
    private PuzzleManager manager;

    private void Start()
    {
         manager = FindFirstObjectByType<PuzzleManager>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (podeUsar())
            {

                Ray ray = puzzleCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Perform the raycast, checking only for collisions with the "PuzzlePieces" layer
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, puzzlePieceLayerMask))
                {
                    string meshName = hit.collider.gameObject.name;
                    Debug.Log("Clicked on puzzle piece: " + meshName);
                    verifica(meshName);
                }
            }
            else { Debug.Log("nao pode usar"); }
        }
    }
    private void verifica(string name)
    {
        if (sequencia[count] == name)
        {
            count++;
            playSound(name);
            if (count == 5)
            {
                count = 0;
                Debug.Log("correto");
                
                manager.completePuzzle(1);
                playSound("done");
                return;
            }
        }
        else
        {
            count = 0;
            playSound(name);
        }

    }

    private void playSound(string name)
    {
        switch (name)
        {

            case "A#":
                audioSource.PlayOneShot(notas[10]);
                break;
            case "C":
                audioSource.PlayOneShot(notas[0]);
                break;
            case "G1":
                audioSource.PlayOneShot(notas[7]);
                break;
            case "D#":
                audioSource.PlayOneShot(notas[3]);
                break;
            case "D":
                audioSource.PlayOneShot(notas[2]);
                break;
            case "A#1":

                break;
            case "A1":
                audioSource.PlayOneShot(notas[9]);
                break;

            case "B1":
                audioSource.PlayOneShot(notas[11]);
                break;
            case "C#":
                audioSource.PlayOneShot(notas[1]);
                break;
            case "C1":
                audioSource.PlayOneShot(notas[12]);
                break;
            case "E":
                audioSource.PlayOneShot(notas[4]);
                break;
            case "F":
                audioSource.PlayOneShot(notas[5]);
                break;
            case "F#":
                audioSource.PlayOneShot(notas[6]);
                break;
            case "G#":
                audioSource.PlayOneShot(notas[14]);
                break;
            case "G#1":
                audioSource.PlayOneShot(notas[8]);
                break;
            case "A":
                audioSource.PlayOneShot(notas[13]);
                break;
            case "done":
                audioSource.PlayOneShot(notas[15]);
                break;

            default:

                break;



        }
    }

    private bool podeUsar()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            if (inventory.Container.Items[i].nameItem == "mallets")
            {
                if (manager.inside == true) {
                    Debug.Log("gloken inside: " + manager.inside);
                    return true;
                }
                
                
            }

        }

        return false;
    }


}

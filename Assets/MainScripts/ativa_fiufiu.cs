using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ativa_fiufiu : MonoBehaviour
{
    private PuzzleManager manager;

    void Start()
    {
        manager = FindFirstObjectByType<PuzzleManager>();
        
    }


    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {

            if (other.gameObject.CompareTag("Player"))
            {
            if (manager.fiufiuState == false && manager.fiufiuPassou == false) {
                
                manager.fiufiuState = true;

            }
            }
        }
   
}

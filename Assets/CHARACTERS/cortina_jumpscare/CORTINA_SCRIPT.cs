using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CORTINA_SCRIPT : MonoBehaviour
{
    public GameObject ItemText;
    public Animator abre;
    private bool portaState = false;
    public GameObject chave;
    private AudioSource audioSource;

    void Update()
    {

    }

    void Start()
    {
        chave.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (!portaState)
            {
                ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
                ItemText.SetActive(true);
            }
                
                if (Input.GetKey(KeyCode.E))
                {

                        if (!portaState)
                        {
                            Debug.Log("abrindo");
                            portaState = true;
                            abre.SetBool("ativa", true);
                            ItemText.SetActive(false);
                            jumpscareItem();
                        }                                                          
                }          
        }
    }

    private void jumpscareItem() {
        audioSource.Play();
        chave.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);

    }
}

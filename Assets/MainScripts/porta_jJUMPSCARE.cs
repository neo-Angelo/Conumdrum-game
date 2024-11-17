using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class porta_jJUMPSCARE : MonoBehaviour
{
    public GameObject ItemText;
    public Animator abre;
    private bool portaState = false;
    private float portaTime = 1.5f;
    public GameObject esqueleto;


    private AudioSource audioSource;


    private void Start()
    {
        esqueleto.SetActive(false);
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {

        if (portaTime > 0)
        {
            portaTime -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {

            if (!portaState)
            {

                if (other.gameObject.CompareTag("Player"))
                {
                    ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
                    ItemText.SetActive(true);
                    if (portaTime <= 0)
                    {
                        if (Input.GetKey(KeyCode.E))
                        {
                            Debug.Log("abrindo");
                            portaState = true;
                            abre.SetBool("openState", true);
                            portaTime = 1.5f;
                            ItemText.SetActive(false);
                            audioSource.Stop();
                            audioSource.Play();
                            esqueleto.SetActive(true);
                            esqueleto.GetComponent<JUMPSCARE>().Jumpscare();


                        }
                    }
                }          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);

    }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class porta_script : MonoBehaviour
{
    public GameObject ItemText;
    public Animator abre;
    private bool portaState = false;
    private float portaTime = 1.5f;
    public InventoryObject inventory;
    public string chaveName;
    private AudioSource audioSource;
    public AudioClip locked;
    void Update()
    {
        if (portaTime > 0)
        {
            portaTime -= Time.deltaTime;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
            ItemText.SetActive(true);
            if (portaTime <= 0)
            {

                if (Input.GetKey(KeyCode.E))
                {
                    if (podeUsar())
                    {
                        if (!portaState)
                        {
                            Debug.Log("abrindo");
                            portaState = true;
                            abre.SetBool("openState", true);
                            abre.SetBool("CloseState", false);

                            portaTime = 1.5f;
                            audioSource.Stop();
                            audioSource.Play();

                        }
                        else
                        {
                            Debug.Log("fechando");
                            portaState = false;
                            abre.SetBool("openState", false);
                            abre.SetBool("CloseState", true);
                            portaTime = 1.5f;
                            audioSource.Stop();
                            audioSource.Play();

                        }
                        ItemText.SetActive(false);

                    }
                }

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);

    }

    private bool podeUsar()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            if (inventory.Container.Items[i].nameItem == chaveName)
            {
                return true;
            }

        }
        if (chaveName == "")
        {
            return true;
        }
        ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "i need a key maybe";
        audioSource.PlayOneShot(locked);
        portaTime = 1f;
        return false;
    }
}

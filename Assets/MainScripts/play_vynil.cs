using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class play_vynil : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject ItemText;
    private AudioSource audioSource; // Add this line to store the reference to the AudioSource.
    private bool tocar = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component.
        ItemText.SetActive(false);
        ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
            ItemText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                if (podeUsar() && tocar == false)
                {
                    tocar = true;
                    playSound();
                    Invoke("podeTocar",1f);
                    //ItemText.SetActive(false);
                }
                else
                {
                    ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "need something to play";
                }
            }
        }
    }

    private bool podeUsar()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            if (inventory.Container.Items[i].nameItem == "vinyl")
            {
                return true;
            }
        }
        return false;
    }

    private void playSound()
    {
        // Check if there is an AudioSource component attached to this GameObject
        // and if the audio is currently playing.
        if (audioSource != null && audioSource.isPlaying)
        {
            // If the sound is already playing, stop it.
            audioSource.Stop();
        }
        else
        {
            // If the sound is not playing, play it.
            audioSource.Play();
        }
    }

    private void podeTocar() {

        tocar = false;


    }
    private void OnTriggerExit(Collider other)
    {
        ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
        ItemText.SetActive(false);
    }
}

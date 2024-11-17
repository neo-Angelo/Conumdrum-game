using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class teleport_player : MonoBehaviour
{
    public Transform teleportDestination; // Assign the destination object in the Inspector
    public GameObject ItemText;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
            ItemText.SetActive(true);
            if (Input.GetKey(KeyCode.E)) // Use GetKeyDown to teleport only once when 'E' is pressed
            {
                Debug.Log("entrou teleporte");
                TeleportPlayer(other.gameObject);
                ItemText.SetActive(false);
            }
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // Teleport the player to the destination position

        //player.transform.position = new Vector3(-69.6f, 5.9f, 57.72f);
        player.transform.position = teleportDestination.transform.position;

    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);

    }
}





using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class porao_script : MonoBehaviour
{
    public Transform teleportDestination;
    public GameObject ItemText;
    public InventoryObject inventory;
    // Start is called before the first frame update


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
            ItemText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                if (podeUsar())
                {
                    Debug.Log("entrou teleporte");
                    TeleportPlayer(other.gameObject);
                    ItemText.SetActive(false);

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
            if (inventory.Container.Items[i].nameItem == "basement key")
            {
                return true;
            }

        }
        ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "I need a key to unlock this.";
        return false;
    }

    private void TeleportPlayer(GameObject player)
    {
        // Teleport the player to the destination position

        //player.transform.position = new Vector3(-69.6f, 5.9f, 57.72f);
        player.transform.position = teleportDestination.transform.position;

    }
}


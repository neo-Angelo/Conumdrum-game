using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class quintal_item : MonoBehaviour
{
    public GameObject ItemText;
    public itemObject item;
    private PuzzleManager manager;
    public InventoryObject inventory;
    private AudioSource audioSource;
    bool cantake = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        manager = FindFirstObjectByType<PuzzleManager>();

        if (manager.hasItem(item.id))
        {
            Destroy(gameObject);
        }
        ItemText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (cantake)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
                ItemText.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    if (podeUsar())
                    {
                        cantake = false;
                        ItemText.SetActive(false);
                        // Call a method in the player script to handle the item pickup
                        other.GetComponent<ControllerPlayer>().PickUpItem(item);
                        manager.obtainItem(item.id);
                        // Remove the item from the scene
                        itemTake();

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
            if (inventory.Container.Items[i].nameItem == "shovel")
            {
                return true;
            }

        }
        ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "I need something to dig with";
        return false;
    }

    private void DestroyItem()
    {

        Destroy(gameObject);
    }


    private void itemTake()
    {
        audioSource.Play();
        Invoke("DestroyItem", audioSource.clip.length - 0.9f);

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    public GameObject ItemText;
    public itemObject item;
    public int itemNumber;
    private PuzzleManager manager;
    private AudioSource audioSource;
    bool cantake = true;


    void Start()
    {
        manager = FindFirstObjectByType<PuzzleManager>();
        audioSource = GetComponent<AudioSource>();

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

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);

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
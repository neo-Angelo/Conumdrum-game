using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class filme : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject ItemText;
    private bool podeAtivar;
    public GameObject tela;
    private AudioSource audioFilme;
    private bool tocar = false;

    void Start()
    {
          audioFilme = GetComponent<AudioSource>();
          tela.SetActive(false);
          podeAtivar = false;
          ItemText.SetActive(false);
          ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "aperte 'E' para interagir";
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
            ItemText.SetActive(true);

            ItemText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                if (podeUsar() && tocar == false)
                {
                    tocar = true;
                    tela.SetActive(true);
                    ItemText.SetActive(false);
                    audioFilme.Play();
                    Invoke("podeTocar", 1f);
                }
                else
                {
                    ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "i need something to play";
                }
            }
        }
    }

    private bool podeUsar()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            if (inventory.Container.Items[i].nameItem == "film")
            {
                return true;
            }
        }
        return false;
    }

    private void podeTocar()
    {

        tocar = false;

    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);
        tocar = false;
    }


}

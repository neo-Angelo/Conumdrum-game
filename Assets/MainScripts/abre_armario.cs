using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class abre_armario : MonoBehaviour
{
    public GameObject ItemText;
    public Animator abre;
    private bool portaState = false;
    private float portaTime = 1.5f;
    private PuzzleManager manager;
    public int numeroPuzzle;
    public bool vazia = false;
    public itemObject? item;
    public bool isGaveta = false;
    public string needItem;
    public bool noNeed; //se precisa de item no iventario ou nao
    //TALVEZ DE UM ERRO INESPERADO, SE ACONTECER ALGO DE BUG CHEQUE ISSO :)
    public AudioClip itemSound;
    public GameObject itemMesh;
    private AudioSource audioSource;


    private void Start()
    {
        manager = FindFirstObjectByType<PuzzleManager>();
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
        if (manager.checkCompletion(numeroPuzzle) || vazia || (isGaveta && noNeed) || (isGaveta && other.GetComponent<ControllerPlayer>().podeUsar(needItem)))
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
                            if (!vazia)
                            {
                                addItem(other);

                                Invoke("somItem", 1f);

                            }
                            portaState = true;
                            abre.SetBool("openState", true);
                            portaTime = 1.5f;
                            ItemText.SetActive(false);
                            audioSource.Stop();
                            audioSource.Play();


                        }
                    }
                }
            }
        }
        else
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "For some reason, I can't open it.";
            ItemText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);

    }
    private void addItem(Collider other)
    {
        Debug.Log("inseriu ");

        if (isGaveta)
        {
            other.GetComponent<ControllerPlayer>().PickUpItem(item);
            manager.obtainItem(item.id);


        }
        else
        {
            other.GetComponent<ControllerPlayer>().PickUpItem(item);
            manager.obtainItem(item.id);

        }



    }

    private void somItem()
    {
        audioSource.PlayOneShot(itemSound);
        Destroy(itemMesh);
    }


}

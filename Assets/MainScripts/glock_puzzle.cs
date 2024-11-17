using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class glock_puzzle : MonoBehaviour
{
    public GameObject cameraPuzzle;
    public GameObject ItemText;
    private PuzzleManager manager;
    public int numeroPuzzle;
    public int tipoPuzzle;
    private bool puzzleState = false;
    public InventoryObject Inventory;
    public bool needItem;
    private bool showText = false;
    public GameObject playerMove;

    void Start()
    {
        manager = FindFirstObjectByType<PuzzleManager>();
        cameraPuzzle.SetActive(false);
        ItemText.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (showText == false) {
                ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
                ItemText.SetActive(true);
            }          

            if (Input.GetKey(KeyCode.E))
            {

                if (!manager.checkCompletion(numeroPuzzle))
                {
                    if (!needItem)
                    {
                        ItemText.SetActive(false);
                        if (numeroPuzzle == 1)
                        {
                            manager.inside = true;
                            Debug.Log("gloken inside: " + manager.inside);
                        }
                        puzzleStart(other);
                        showText = true;
                    }
                    else
                    {
                        if (podeUsar())
                        {
                            Debug.Log("tem item");
                            puzzleStart(other);
                            ItemText.SetActive(false);
                            showText = true;


                        }
                        else
                        {

                            Debug.Log("nao tem item");
                            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "I need something to turn this on.";
                            ItemText.SetActive(true);
                            showText = true;
                        }

                    }

                }
                else
                {
                    GameObject camera = other.GetComponent<ControllerPlayer>().cameraMain;
                    camera.SetActive(true);
                    cameraPuzzle.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    finalizaPuzzle();
                }
            }
            if (Input.GetKey(KeyCode.Q))
            {
                GameObject camera = other.GetComponent<ControllerPlayer>().cameraMain;
                camera.SetActive(true);
                cameraPuzzle.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                ItemText.SetActive(true);
                playerMove.GetComponent<characterMove>().canmove = true;
                if (numeroPuzzle == 1)
                {
                    manager.inside = false;
                }
            }

        }
    }

    private void puzzleStart(Collider other)
    {
        GameObject camera = other.GetComponent<ControllerPlayer>().cameraMain;
        camera.SetActive(false);
        cameraPuzzle.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        puzzleState = true;
        ItemText.SetActive(false);
        playerMove.GetComponent<characterMove>().canmove = false;
        if (numeroPuzzle == 4)
        {
            puzzleLuzes();
        }
    }
    private void finalizaPuzzle()
    {
        switch (tipoPuzzle)
        {

            case 2:
                SceneManager.LoadScene("level3");
                break;
            case 3:
                SceneManager.LoadScene("final");
                break;
            default: break;

        }
    }

    private void puzzleLuzes()
    {
        ColorPuzzle puzzle = GetComponentInChildren<ColorPuzzle>();
        puzzle.OnInteraction();

    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.SetActive(false);
        showText = false;

    }

    private bool podeUsar()
    {
        for (int i = 0; i < Inventory.Container.Items.Count; i++)
        {
            if (Inventory.Container.Items[i].id == 4)
            {
                return true;
            }

        }

        return false;
    }

}

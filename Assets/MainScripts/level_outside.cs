using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class level_outside : MonoBehaviour
{
    // Public variable to set the level name from the Inspector
    public string levelToLoad;
    private Animator transition;
    public Canvas transitionCanvas;
    public float transitionTime = 1f;
    public GameObject ItemText;

    private void Start()
    {
        transition = transitionCanvas.GetComponent<Animator>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
            ItemText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                loadScene();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemText.GetComponentInChildren<TextMeshProUGUI>().text = "'E' to interact";
        ItemText.SetActive(false);
    }

    private void loadScene()
    {

        StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {

        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelToLoad);

    }
}

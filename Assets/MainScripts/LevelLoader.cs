using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Public variable to set the level name from the Inspector
    public string levelToLoad;
    private Animator transition;
    public Canvas transitionCanvas;
    public float transitionTime = 1f;

    private void Start()
    {
        transition = transitionCanvas.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger is triggered by the player (you can modify this condition as per your setup)
        if (other.CompareTag("Player"))
        {
            // Load the specified level
            loadScene();


        }
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
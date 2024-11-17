using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject intro;

    private void Start()
    {
        intro.SetActive(false);
    }
    public void playGame()
    {
        intro.SetActive(true);
        intro.GetComponent<INTRO>().inicia();


    }

    public void quitGame()
    {

        Application.Quit();
    }
}

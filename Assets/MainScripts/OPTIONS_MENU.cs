using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPTIONS_MENU : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update

    public void backMenu()
    {

        SceneManager.LoadScene("MainMenu");


    }

    public void resume()
    {
        menu.GetComponent<OPTIONS_MAIN>().voltaTela();
        
        //gameObject.SetActive(false);
    }

    public void quitGame()
    {

        Application.Quit();
    }

}

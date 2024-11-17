using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_Final : MonoBehaviour
{
    public Animator anim;
    public int tempo;
    private bool podeMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("screen", tempo);
    }

    private void screen() {
        Debug.Log("final");
        anim.SetBool("final", true);
        Invoke("carregarMenu", 5f);

    }

    private void carregarMenu() {

        podeMenu = true;


    }

    void Update()
    {
        if (podeMenu == true) {

            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("MainMenu");

            }
        }
        
    }
}

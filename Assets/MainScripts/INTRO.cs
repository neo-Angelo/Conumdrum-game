using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INTRO : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float time;
    public GameObject menu;
 
    public void inicia() {
        Debug.Log("iniciou");
       
        animator.SetBool("intro",true);
        Invoke("levelLoader", time);
        Invoke("disableMenu", 1f);

    }

    private void levelLoader() {
        SceneManager.LoadScene("newScene");

    }

     void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            SceneManager.LoadScene("newScene");
        }
            
    }
    private void disableMenu() {
        menu.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OPTIONS_MAIN : MonoBehaviour
{
    public GameObject menu;
    public bool pode = false;
    // Start is called before the first frame update
    void Start()
    {
        pode = false;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pode == false)
            {
                menu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                pode = true;

            }
            else {
                voltaTela();
            }
           
        }
    }

    public void voltaTela() {
        pode = false;
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}

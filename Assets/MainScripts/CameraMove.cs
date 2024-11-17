using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public bool canMove;
    public GameObject menuTela;


    public Transform orientation;
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        menuTela.SetActive(false);
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            canMove = !canMove;
            Cursor.visible = !canMove;
            Cursor.lockState = CursorLockMode.Confined;
            menuTela.SetActive(!canMove);
        }

        if (canMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0f);


        }
    }

}

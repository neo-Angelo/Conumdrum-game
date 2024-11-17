using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private AudioSource footstep;

    [Header("Movement")]

    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    bool hasMoved = false;
    public bool canmove = true;

    Vector3 movementDirection;

    Rigidbody rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        footstep = GetComponent<AudioSource>();
        footstep.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (canmove)
        {
            MyInput();
            SpeedControl();
        }
        else {
            footstep.enabled = false;
        }
       

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        //checa se o player moveu

        if (hasMoved)
        {
 
            footstep.enabled = true;
        }
        else
        {

            footstep.enabled = false;
        }


    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        hasMoved = (horizontalInput != 0 || verticalInput != 0);
    }

    private void MovePlayer()
    {
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(movementDirection.normalized * moveSpeed * 10f, ForceMode.Force);


    }

    private void FixedUpdate()
    {
        if (canmove)
        {
            MovePlayer();
        }
        
    }

    private void SpeedControl()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
}

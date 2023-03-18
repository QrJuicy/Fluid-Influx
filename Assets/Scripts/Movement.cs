using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    Rigidbody myRigidbody;
    private bool isOnGround = true;
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] float fallSpeed = 0f;

    private float horizontalInput;
    [SerializeField] Transform orientation;

    
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        //Moving the x axis position
        movingXaxis();


        //Jumping
        jumpUp();

        //Jump falling
        jumpFall();
    }

    private void jumpFall()
    {
        if (myRigidbody.velocity.y < 0)
        {
            myRigidbody.AddForce(Vector3.down * fallSpeed, ForceMode.Force);
        }
        isOnGround = false;
    }

    private void jumpUp()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true)
        {
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void movingXaxis()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    private void MovePlayer()
    {
        myRigidbody.AddForce(orientation.right.normalized * horizontalInput * movSpeed * 10f, ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
        isOnGround = true; 
        Debug.Log("istouching ground");
        }   
    }
}

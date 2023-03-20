using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    Rigidbody myRigidbody;

    [Header("Movement")] //to know what type of variables do we use
    [SerializeField] float movSpeed;
    [SerializeField] float jumpForce;
    private float horizontalInput;
    [SerializeField] Transform orientation;
    

    [Header("Ground checking")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask Ground;
    [SerializeField] float groundDrag;
    private bool grounded;

    [Header("fucking gravity (set to 0 if default)")]
    [SerializeField] float customgravity;

    
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        groundChecking();
        dragWhenMoving();
        movingXaxis();
        airMoveLimit();
    }

    void FixedUpdate()
    {
        myRigidbody.AddForce(new Vector3(0, -1.0f, 0)*myRigidbody.mass*customgravity);
        MovePlayer();
        
        jumpUp();
    }

    //Jumping

    private void jumpUp()
    {
        if (grounded && (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Jump") > 0))
        {
            myRigidbody.drag = 0;
            myRigidbody.velocity =new Vector3(myRigidbody.velocity.x , 0f , myRigidbody.velocity.z);
            myRigidbody.AddForce(transform.up * jumpForce , ForceMode.Impulse);
        }
    }

    private void airMoveLimit()
    {
        if(!grounded && (myRigidbody.velocity.x > movSpeed|| myRigidbody.velocity.x < -movSpeed ))
        {

                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x * 0.8f , myRigidbody.velocity.y , myRigidbody.velocity.z);

        }
    }

    //detecting if you are grounded
    private void groundChecking()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down,playerHeight * 0.5f + 0.2f , Ground);
    }

    private void dragWhenMoving()
    {
        if(grounded)
        {
            myRigidbody.drag = groundDrag; 
        } else
        {
            myRigidbody.drag = 0;
        }
    }

    //x axis movement
  
    private void movingXaxis()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    private void MovePlayer()
    {
        myRigidbody.AddForce(orientation.right.normalized * horizontalInput * movSpeed  *  10f , ForceMode.Force);
    }

}

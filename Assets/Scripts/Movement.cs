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
    [SerializeField] float airMultiplier;
    [SerializeField] float fallSpeed;
    private float horizontalInput;
    [SerializeField] Transform orientation;


    [Header("Ground checking")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask Ground;
    [SerializeField] float groundDrag;
    private bool grounded;

    
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        groundChecking();

        //Jumping
        jumpUp();

        dragWhenMoving();
        //Moving the x axis position
        movingXaxis();
        SpeedControl();

        

        //Jump falling
        //jumpFall();
    }

    //Jumping
    private void jumpFall()
    {
        if (myRigidbody.velocity.y < 0)
        {
            myRigidbody.AddForce(Vector3.down * fallSpeed, ForceMode.Force);
        }
        
    }

    //Pat help it doesnt detect grounded????? it keeps jumping
    private void jumpUp()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            myRigidbody.drag = 0;
            myRigidbody.velocity =new Vector3(myRigidbody.velocity.x , 0f , myRigidbody.velocity.z);
            myRigidbody.AddForce(transform.up *jumpForce, ForceMode.Impulse);
        }
    }

    //detecting if you are grounded
    private void groundChecking()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down,playerHeight * 0.5f + 0.2f , Ground);
    }

    //But it detects grounded on this one??????
    private void dragWhenMoving()
    {
        if(grounded)
        {
            myRigidbody.drag = groundDrag;
            Debug.Log("grounded");
            
        } else
        {
            myRigidbody.drag = 0;
        }
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3 (myRigidbody.velocity.x , myRigidbody.velocity.y, 0f);
        if(flatVel.magnitude > movSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movSpeed;
            myRigidbody.velocity = new Vector3(limitedVel.x , myRigidbody.velocity.y, myRigidbody.velocity.z);
        }
    }

    //x axis movement
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
        if(grounded)
        {
        myRigidbody.AddForce(orientation.right.normalized * horizontalInput * movSpeed * 10f, ForceMode.Force);
        } else if(!grounded)
        {
            myRigidbody.AddForce(orientation.right.normalized * horizontalInput * movSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        
    }

}

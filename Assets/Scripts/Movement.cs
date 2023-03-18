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


    
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        //Moving the x axis position
        transform.Translate(Vector3.right * Time.deltaTime * movSpeed * Input.GetAxis("Horizontal"));

        //Jumping
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true)
        {
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

}

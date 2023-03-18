using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    Rigidbody myRigidbody;
    [SerializeField] float movSpeed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void XMovement()
    {
        /*if
        (
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow)
        )*/
        //{
            float xValue =  Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
           // float zValue =  Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;

            transform.Translate(xValue, 0, 0/*zValue*/);
        //}
    }
}

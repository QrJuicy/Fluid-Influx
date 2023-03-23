using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConveyorBelts : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator conveyorSpeed;
    [SerializeField] float animationSpeed;

    [SerializeField] Vector3 direction;
    [SerializeField] List<GameObject> onBelt;


    //private Material material;
    
    private void Update()
    {
       conveyorSpeed.speed =  animationSpeed;
    }
    
    private void FixedUpdate()
    {
         for (int i = 0 ; i <= onBelt.Count - 1; i++)
        {
            Debug.Log("moving");
            onBelt[i].GetComponent<Rigidbody>().AddForce(speed * direction);
            
            onBelt[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }


    private void OnCollisionExit(Collision collision)
    {
           for (int i = 0 ; i <= onBelt.Count - 1; i++)
        {
           onBelt[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            onBelt.Remove(collision.gameObject);
            
           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelts : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] float conveyorSpeed;
    [SerializeField] Vector3 direction;
    [SerializeField] List<GameObject> onBelt;

    //private Material material;
    
     
    
    private void FixedUpdate()
    {
         for (int i = 0 ; i <= onBelt.Count - 1; i++)
        {
            Debug.Log("moving");
            onBelt[i].GetComponent<Rigidbody>().AddForce(speed * direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }


    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
    }
}

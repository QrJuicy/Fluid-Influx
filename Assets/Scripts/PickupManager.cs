using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //todo add particle with switch statements and objectTag
    }



    void OnTriggerEnter(Collider other)
    {
        string objectTag = other.gameObject.tag;
        if (objectTag == "Player")
        {
            Debug.Log("Picked up");
        }
    }
}

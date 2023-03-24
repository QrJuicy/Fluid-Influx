using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] bool isDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //todo add particle with switch statements and objectTag
        if(isDisabled)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string objectTag = other.gameObject.tag;
        if (objectTag == "Player")
        {
            isDisabled = true;
            Debug.Log("Picked up");
        }
    }
}

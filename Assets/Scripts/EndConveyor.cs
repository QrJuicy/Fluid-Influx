using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndConveyor : MonoBehaviour
{
    
    [SerializeField] List<GameObject> onBelt;


    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
    }

    
}

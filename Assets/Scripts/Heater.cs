using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{
    [SerializeField] float upTime = 0f;
    [SerializeField] float activateEvery = 0f;
    [SerializeField] float activationProgress = 0f;
    [SerializeField] float activationRate = 0f;
    [SerializeField] bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HeaterActivation();
        if(!isActivated)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    private void HeaterActivation()
    {
        if (activationProgress <= activateEvery)
        {
            activationProgress += activationRate * Time.deltaTime;
        }

        if (activationProgress >= activateEvery)
        {
            activationProgress = 0;

            if (!isActivated)
            {
                isActivated = true;
            }
        }
        if (isActivated)
        {
            Invoke("ActivateHeater", upTime);
        }
    }

    void ActivateHeater()
    {
        isActivated = false;
    }
}

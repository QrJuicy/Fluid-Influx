using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    //GetComponent
    Transform objectPosition;

    [Header("Timer")]
    [SerializeField] float winTimer = 0f;
    [SerializeField] float deathTimer = 0f;


    [Header("Fluidity Control")]
    [SerializeField] float maxFluidity = 0f;
    [SerializeField] float fluidity = 0f;
    [SerializeField] float increaseRate = 0f;
    [SerializeField] float staticIncreaseRate = 0f;


    [Header("Effects Strenght")] 
    [SerializeField] float heatPower = 0f;
    [SerializeField] float heatDuration = 0f;
    [SerializeField] float coldPower = 0f;
    [SerializeField] float coldDuration = 0f;
    [SerializeField] float heaterDamage = 0f;

    [Header("Max Height to Live")]
    [SerializeField] float fallToDeath = 0f;


    [Header("Boolean Tests")]
    [SerializeField] bool isAlive = true;
    [SerializeField] bool transitioning = false;// to stop player from interacting with others while on timer
    [SerializeField] bool isHeating = false;
    [SerializeField] bool isCooling = false;



    // Start is called before the first frame update
    void Start()
    {
        objectPosition = gameObject.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        FallToDeath();
        FluidControl();
        if(fluidity <=0)
        {
            fluidity = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        string objectTag = other.gameObject.tag;
        if(!transitioning)
        {
            switch(objectTag)
            {
                case "Heater":
                    fluidity += heaterDamage;
                    break;

                case "B_Switch":
                    isCooling = true;
                    CoolingUp();
                    break;

                case "R_Switch":
                    isHeating = true;
                    HeatingUp();
                    break;
            }
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        string objectTag = other.gameObject.tag;
        //todo add take damage when collide with heaters
        //todo add lightbulb interaction
        if(!transitioning)
        {
            switch(objectTag)
            {
                case "Dispenser":
                    DeclareWin();
                    break;
                case "Piston":
                    Crush();
                    break;
            }
        }
    }

    void HeatingUp()
    {
        if (isHeating)
        {
            isCooling = false;
            increaseRate += heatPower;
            Invoke("StopHeating", heatDuration);
        }
    }
    void StopHeating()
    {
        isHeating = false;
        increaseRate = staticIncreaseRate;
    }
    void CoolingUp()
    {
        if (isCooling)
        {
            isHeating = false;
            increaseRate -= coldPower;
            Invoke("StopHeating", coldDuration);
        }
    }
    void StopCooling()
    {
        isCooling = false;
        increaseRate = staticIncreaseRate;
    }

    private void Crush()
    {
        if (Movement.grounded == true)
        {
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(gameObject.GetComponent<Movement>());
            DeclareDeath();
        }
    }



    //Fluid Control
    private void FluidControl()
    {
        if (fluidity <= maxFluidity)
        {
            fluidity += increaseRate * Time.deltaTime;
        }

        if (fluidity >= maxFluidity)
        {
            DeclareDeath();
        }
    }



    private void FallToDeath()
    {
        if (objectPosition.position.y <= fallToDeath)
        {
            DeclareDeath();
        }
    }


    //Progress conditions
    private void DeclareDeath()
    {
        if (isAlive)
        {
            isAlive = false;
            Invoke("ReloadScene", deathTimer);
            Debug.Log("You Died");
        }
    }

    private void DeclareWin()
    {
        Invoke("NextScene", winTimer);
        Debug.Log("ENtering Next Level");
    }
    
    

    //Scene management
    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
        if(currentScene == SceneManager.sceneCountInBuildSettings)
        {
            currentScene = 0;
        }
    }


}
